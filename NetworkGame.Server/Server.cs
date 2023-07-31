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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NetworkGame.Server
{
    class Server
    {
        public event EventHandler<NewPlayerEventArgs> NewPlayer;
        public event EventHandler<RemovePlayerEventArgs> RemovePlayer;
        private readonly LogManager logManager;
        private List<PlayerAndConnection> players;
        private NetPeerConfiguration _configuration;
        public NetServer NetServer { get; private set; }

        public Server(LogManager logManager)
        {
            this.logManager = logManager;
            players = new List<PlayerAndConnection>();
            _configuration = new NetPeerConfiguration("networkGame") { Port = 9981 };
            _configuration.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            NetServer = new NetServer(_configuration);
        }

        public void Run()
        {
            NetServer.Start();
            Console.WriteLine("Server started...");
            logManager.AddLogMessage("Server", "Server Started.");
            while (true)
            {
                NetIncomingMessage message;
                if ((message = NetServer.ReadMessage()) == null)
                {
                    continue;
                }

                switch (message.MessageType)
                {
                    case NetIncomingMessageType.ConnectionApproval:
                        var login = new LoginCommand();
                        login.Run(logManager, this, message, null, players);
                        break;

                    case NetIncomingMessageType.Data:
                        Data(message);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)message.ReadByte();

                        string reason = message.ReadString();
                        logManager.AddLogMessage(new LogMessage()
                        {
                            Id = NetUtility.ToHexString(message.SenderConnection.RemoteUniqueIdentifier),
                            Message = status.ToString() + ": " + reason,
                        });

                        if (status == NetConnectionStatus.Disconnected)
                        {
                            //find player by connection
                            var player = players.FirstOrDefault(p => p.Connection == message.SenderConnection);
                            if (player == null)
                            {
                                break;
                            }

                            
                            if (RemovePlayer != null)
                            {
                                RemovePlayer(this, new RemovePlayerEventArgs(player.Player.Name));
                            }
                        }
                        break;
                }
            }
        }

        private void Data(NetIncomingMessage message)
        {
            var packetType = (PacketType)message.ReadByte();
            var command = PacketFactory.GetCommand(packetType);
            command.Run(logManager, this, message, null, players);
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
            var command = PacketFactory.GetCommand(PacketType.Kick);
            command.Run(logManager, this, null, players[playerIndex], players);
            players.RemoveAt(playerIndex);
        }

        public static void WritePlayer(Player p, NetOutgoingMessage outMessage)
        {
            outMessage.Write(p.Name);
            outMessage.Write(p.X);
            outMessage.Write(p.Y);
        }
    }
}
