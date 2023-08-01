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
        public void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, PlayerManager playerManager)
        {
            logManager.AddLogMessage("Server", "Recieved new input.");
            var name = message.ReadString();
            playerAndConnection = playerManager.GetPlayer(name);
            if (playerAndConnection == null)
            {
                Console.WriteLine("Could not find player with name {0}", name);
                return;
            }

            InputState inputState = new InputState();
            inputState.Read(message);
            playerManager.SetInputState(playerAndConnection, inputState);
        }
    }
}
