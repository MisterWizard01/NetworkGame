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
    class KickPlayerCommand : ICommand
    {
        public void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, PlayerManager playerManager)
        {
            logManager.AddLogMessage("Server", string.Format("Kicking {0}", playerAndConnection.Player.Name));
            var outMessage = server.NetServer.CreateMessage();
            outMessage.Write((byte)PacketType.Kick);
            outMessage.Write(playerAndConnection.Player.Name);
            server.NetServer.SendToAll(outMessage, NetDeliveryMethod.ReliableOrdered);

            //Kick player
            playerAndConnection.Connection.Disconnect("Bye bye, you've been kicked.");
        }
    }
}
