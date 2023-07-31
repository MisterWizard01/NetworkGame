using Lidgren.Network;
using NetworkGame.Library;
using NetworkGame.Server.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.Commands
{
    class AllPlayersCommand : ICommand
    {
        public void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, List<PlayerAndConnection> players)
        {
            logManager.AddLogMessage("Server", "Sending full player list.");
            var outMessage = server.NetServer.CreateMessage();
            outMessage.Write((byte)PacketType.AllPlayers);
            outMessage.Write(players.Count);
            foreach (var p in players)
            {
                Server.WritePlayer(p.Player, outMessage);
            }
            server.NetServer.SendToAll(outMessage, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
