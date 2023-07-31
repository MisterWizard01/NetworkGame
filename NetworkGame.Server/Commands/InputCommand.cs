using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NetworkGame.Library;
using NetworkGame.Server.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.Commands
{
    class InputCommand : ICommand
    {
        public void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, List<PlayerAndConnection> players)
        {
            logManager.AddLogMessage("Server", "Recieved new input.");
            var name = message.ReadString();
            playerAndConnection = players.FirstOrDefault(p => p.Player.Name == name);
            if (playerAndConnection == null)
            {
                Console.WriteLine("Could not find player with name {0}", name);
                return;
            }

            float[] signals = new float[Enum.GetNames(typeof(InputSignal)).Length];
            for (int i = 0; i < signals.Length; i++)
            {
                signals[i] = message.ReadFloat();
            }

            Vector2 inputVector = new Vector2(signals[(int)InputSignal.HorizontalMovement], signals[(int)InputSignal.VerticalMovement]);
            if (inputVector.LengthSquared() > 0)
            {
                playerAndConnection.Player.Position += Vector2.Normalize(inputVector) * 2;
            }

            var command = new PlayerPositionCommand();
            command.Run(logManager, server, message, playerAndConnection, players);
        }
    }
}
