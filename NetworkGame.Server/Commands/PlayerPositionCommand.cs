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
    class PlayerPositionCommand : ICommand
    {
        public void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, PlayerManager playerManager)
        {
            logManager.AddLogMessage("Server", "Sending out new player position.");
            var outMessage = server.NetServer.CreateMessage();
            outMessage.Write((byte)PacketType.PlayerPosition);
            Server.WritePlayer(playerAndConnection.Player, outMessage);
            server.NetServer.SendToAll(outMessage, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
