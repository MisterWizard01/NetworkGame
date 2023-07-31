using Lidgren.Network;
using Microsoft.Xna.Framework.Input;
using NetworkGame.Library;
using NetworkGame.MyEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Managers;

public class NetworkManager
{
    private NetClient _client;
    public string Username { get; set; }
    public bool Active { get; set; }

    public event EventHandler<PlayerUpdateEventArgs> PlayerUpdateEvent;
    public event EventHandler<KickPlayerEventArgs> KickPlayerEvent;
    //public event EventHandler<EnemyUpdateEventArgs> EnemyUpdateEvent;

    public bool Start()
    {
        var random = new Random();
        _client = new NetClient(new NetPeerConfiguration("networkGame"));
        _client.Start();

        Username = "name_" + random.Next(0, 100);

        var outMessage = _client.CreateMessage();
        outMessage.Write((byte)PacketType.Login);
        outMessage.Write(Username);
        _client.Connect("127.0.0.1", 9981, outMessage);
        return EstablishInfo();
    }

    private bool EstablishInfo()
    {
        var time = DateTime.Now;
        NetIncomingMessage message;
        while (true)
        {
            if (DateTime.Now.Subtract(time).Seconds > 5)
            {
                return false;
            }

            if ((message = _client.ReadMessage()) == null) continue;

            switch (message.MessageType)
            {
                case NetIncomingMessageType.Data:
                    var data = message.ReadByte();
                    if (data == (byte)PacketType.Login)
                    {
                        Active = message.ReadBoolean();
                        if (Active)
                        {
                            RecieveAllPlayers(message);
                            return true;
                        }
                        return false;
                    }
                    return false;

                case NetIncomingMessageType.DebugMessage:
                    string debugMessage = message.ReadString();
                    Console.WriteLine(debugMessage);
                    break;

                default:
                    break;
            }
        }
    }

    public void Update()
    {
        NetIncomingMessage message;
        while ((message = _client.ReadMessage()) != null)
        {
            switch (message.MessageType)
            {
                case NetIncomingMessageType.Data:
                    Data(message);
                    break;

                case NetIncomingMessageType.StatusChanged:
                    StatusChanged(message);
                    break;
            }
        }
    }

    private void StatusChanged(NetIncomingMessage message)
    {
        switch ((NetConnectionStatus)message.ReadByte())
        {
            case NetConnectionStatus.Disconnected:
                Active = false;
                break;
        }
    }

    private void Data(NetIncomingMessage message)
    {
        var packetType = (PacketType)message.ReadByte();
        switch (packetType)
        {
            case PacketType.PlayerPosition:
                var player = ReadPlayer(message);
                if (PlayerUpdateEvent != null)
                {
                    PlayerUpdateEvent(this, new PlayerUpdateEventArgs(new List<Player> { player }, false));
                }
                break;

            case PacketType.AllPlayers:
                RecieveAllPlayers(message);
                break;

            case PacketType.Kick:
                ReceiveKick(message);
                break;

            default:
                break;
        }
    }

    private void RecieveAllPlayers(NetIncomingMessage message)
    {
        var list = new List<Player>();
        var count = message.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            list.Add(ReadPlayer(message));
        }

        if (PlayerUpdateEvent != null)
        {
            PlayerUpdateEvent(this, new PlayerUpdateEventArgs(list, false));
        }
    }

    private Player ReadPlayer(NetIncomingMessage message)
    {
        var player = new Player();
        player.Name = message.ReadString();
        player.X = message.ReadFloat();
        player.Y = message.ReadFloat();
        return player;
    }

    private void ReceiveKick(NetIncomingMessage inc)
    {
        var username = inc.ReadString();
        if (KickPlayerEvent != null)
        {
            KickPlayerEvent(this, new KickPlayerEventArgs(username));
        }
    }

    public void SendInputs(float[] signals)
    {
        var outMessage = _client.CreateMessage();
        outMessage.Write((byte)PacketType.Input);
        outMessage.Write(Username);
        foreach (var signal in signals)
        {
            outMessage.Write(signal);
        }
        _client.SendMessage(outMessage, NetDeliveryMethod.ReliableOrdered);
    }

    public void Disconnect(string message)
    {
        _client.Disconnect(message);
    }
}
