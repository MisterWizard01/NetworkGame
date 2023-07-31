﻿using Lidgren.Network;
using NetworkGame.Library;
using NetworkGame.Server.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.Commands
{
    interface ICommand
    {
        void Run(LogManager logManager, Server server, NetIncomingMessage message, PlayerAndConnection playerAndConnection, List<PlayerAndConnection> players);
    }
}
