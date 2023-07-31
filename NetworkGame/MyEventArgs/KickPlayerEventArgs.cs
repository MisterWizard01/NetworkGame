using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.MyEventArgs
{
    public class KickPlayerEventArgs : EventArgs
    {
        public string Username { get; set; }

        public KickPlayerEventArgs(string username)
        {
            Username = username;
        }
    }
}
