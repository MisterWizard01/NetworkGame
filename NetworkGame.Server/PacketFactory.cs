using NetworkGame.Library;
using NetworkGame.Server.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server
{
    class PacketFactory
    {
        public static ICommand GetCommand(PacketType packetType)
        {
            switch (packetType)
            {
                case PacketType.Login:
                    return new LoginCommand();
                case PacketType.PlayerPosition:
                    return new PlayerPositionCommand();
                case PacketType.AllPlayers:
                    return new AllPlayersCommand();
                case PacketType.Input:
                    return new InputCommand();
                case PacketType.Kick:
                    return new KickPlayerCommand();
                default:
                    throw new ArgumentOutOfRangeException(packetType.ToString());
            }
        }
    }
}
