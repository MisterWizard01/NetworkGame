using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using NetworkGame.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkGame.Server.Commands;
using NetworkGame.Server.Managers;
using NetworkGame.Server.MyEventArgs;
using NetworkGame.Server.Util;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace NetworkGame.Server;

public class GameServer
{
    public event EventHandler<NewPlayerEventArgs> NewPlayer;
    public event EventHandler<RemovePlayerEventArgs> RemovePlayer;
    public event EventHandler<ChangeLabelEventArgs> ShowPhysicsUPS;
    private readonly LogManager logManager;
    private PlayerManager playerManager;
    private NetPeerConfiguration config;

    private DateTime lastPhysicsUpdate, lastNetworkUpdate;

    public NetServer NetServer { get; private set; }

    public GameServer(LogManager logManager)
    {
        this.logManager = logManager;
        playerManager = new PlayerManager();
        config = new NetPeerConfiguration("networkGame") { Port = 9981 };
        config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
        NetServer = new NetServer(config);
    }

    public void Start()
    {
        NetServer.Start();
        logManager.AddLogMessage("Server", "Server started.");
    }

    public void Stop()
    {
        NetServer.Shutdown("Requested by user.");
        logManager.AddLogMessage("Server", "Server stopped.");
    }

    public void Run()
    { 
        HandleIncomingMessages();

        TimeSpan physicsUpdateInterval = DateTime.Now - lastPhysicsUpdate;
        //while(physicsUpdateInterval.TotalMilliseconds < 5)
        //{
        //    Thread.Sleep(1);
        //    physicsUpdateInterval = DateTime.Now - lastPhysicsUpdate;
        //}

        playerManager.Update(physicsUpdateInterval);
        lastPhysicsUpdate = DateTime.Now;

        double phsyicsUPS = 1.0 / physicsUpdateInterval.TotalSeconds;
        ShowPhysicsUPS(this, new ChangeLabelEventArgs(phsyicsUPS.ToString("#.##")));

        if ((DateTime.Now - lastNetworkUpdate).TotalMilliseconds > 100)
        {
            var command = new AllPlayersCommand();
            command.Run(logManager, this, null, null, playerManager);
            lastNetworkUpdate = DateTime.Now;
        }
    }

    private void HandleIncomingMessages()
    {
        NetIncomingMessage inMessage;
        while ((inMessage = NetServer.ReadMessage()) != null)
        {
            switch (inMessage.MessageType)
            {
                case NetIncomingMessageType.ConnectionApproval:
                    var login = new LoginCommand();
                    login.Run(logManager, this, inMessage, null, playerManager);
                    break;

                case NetIncomingMessageType.Data:
                    Data(inMessage);
                    break;

                case NetIncomingMessageType.StatusChanged:
                    NetConnectionStatus status = (NetConnectionStatus)inMessage.ReadByte();

                    string reason = inMessage.ReadString();
                    logManager.AddLogMessage(new LogMessage()
                    {
                        Id = NetUtility.ToHexString(inMessage.SenderConnection.RemoteUniqueIdentifier),
                        Message = status.ToString() + ": " + reason,
                    });

                    if (status == NetConnectionStatus.Disconnected)
                    {
                        //find player by connection
                        var player = playerManager.GetPlayer(inMessage.SenderConnection);
                        if (player == null)
                        {
                            break;
                        }

                        KickPlayer(player); //tell remaining clients to remove this player
                        if (RemovePlayer != null) //remove this player from the server GUI
                        {
                            RemovePlayer(this, new RemovePlayerEventArgs(player.Player.Name));
                        }
                    }
                    break;
            }
            NetServer.Recycle(inMessage);
        }
    }

    private void Data(NetIncomingMessage message)
    {
        var packetType = (PacketType)message.ReadByte();
        var command = PacketFactory.GetCommand(packetType);
        command.Run(logManager, this, message, null, playerManager);
    }

    public void SendNewPlayerEvent(string username)
    {
        if (NewPlayer != null)
        {
            NewPlayer(this, new NewPlayerEventArgs(username));
        }
    }

    public void KickPlayer(int playerIndex)
    {
        KickPlayer(playerManager.GetPlayer(playerIndex));
    }

    public void KickPlayer(PlayerAndConnection player)
    {
        var command = PacketFactory.GetCommand(PacketType.Kick);
        command.Run(logManager, this, null, player, playerManager);
        playerManager.RemovePlayer(player);
    }

    public static void WritePlayer(Player p, NetOutgoingMessage outMessage)
    {
        outMessage.Write(p.Name);
        outMessage.Write(p.X);
        outMessage.Write(p.Y);
    }
}
