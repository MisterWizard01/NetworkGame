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
        public void Run(LogManager logManager, GameServer server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, PlayerManager playerManager)
        {
            //logManager.AddLogMessage("Server", "Sending full player list.");
            var outMessage = server.NetServer.CreateMessage();
            outMessage.Write((byte)PacketType.AllPlayers);
            outMessage.Write(playerManager.PlayerCount);
            playerManager.WriteAllPlayers(outMessage);
            server.NetServer.SendToAll(outMessage, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
