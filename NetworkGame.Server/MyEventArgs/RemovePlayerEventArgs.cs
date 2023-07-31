using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.MyEventArgs
{
    public class RemovePlayerEventArgs
    {
        public string Username { get; set; }

        public RemovePlayerEventArgs(string username)
        {
            Username = username;
        }
    }
}
