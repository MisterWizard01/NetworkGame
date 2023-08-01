using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.MyEventArgs
{
    public class ChangeLabelEventArgs
    {
        public string Value{ get; set; }

        public ChangeLabelEventArgs(string value)
        {
            Value = value;
        }
    }
}
