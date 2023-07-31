using Lidgren.Network;
using NetworkGame.Library;
using NetworkGame.Server.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkGame.Server.Commands
{
    class LoginCommand : ICommand
    {
        public void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, List<PlayerAndConnection> players)
        {
            logManager.AddLogMessage("Server", "New connection...");
            var data = message.ReadByte();
            if (data == (byte)PacketType.Login)
            {
                logManager.AddLogMessage("Server", "...connection accepted.");
                playerAndConnection = CreatePlayer(message, players);
                message.SenderConnection.Approve();

                Thread.Sleep(1000);

                var outMessage = server.NetServer.CreateMessage();
                outMessage.Write((byte)PacketType.Login);
                outMessage.Write(true);
                outMessage.Write(players.Count);
                for (int i = 0; i < players.Count; i++)
                {
                    outMessage.WriteAllProperties(players[i].Player);
                }
                server.NetServer.SendMessage(outMessage, message.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                var command = new PlayerPositionCommand();
                command.Run(logManager, server, message, playerAndConnection, players);
                server.SendNewPlayerEvent(playerAndConnection.Player.Name);
            }
            else
            {
                message.SenderConnection.Deny("Didn't send correct information.");
                logManager.AddLogMessage("Server", "...connection denied.");
            }
        }

        private PlayerAndConnection CreatePlayer(NetIncomingMessage message, List<PlayerAndConnection> players)
        {
            var player = new Player()
            {
                Name = message.ReadString(),
            };
            var playerAndConnection = new PlayerAndConnection(player, message.SenderConnection);
            players.Add(playerAndConnection);
            return playerAndConnection;
        }
    }
}
