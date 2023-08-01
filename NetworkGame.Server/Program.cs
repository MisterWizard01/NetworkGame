using Lidgren.Network;
using NetworkGame.Library;
using NetworkGame.Server.Forms;
using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Windows.Forms;

namespace NetworkGame.Server
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //var server = new Server();
            //server.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }
    }
}