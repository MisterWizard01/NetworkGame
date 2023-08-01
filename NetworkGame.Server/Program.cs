using Lidgren.Network;
using NetworkGame.Library;
using NetworkGame.Server.Forms;
using SamplesCommon;
using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;

namespace NetworkGame.Server
{
    static class Program
    {
        private static MainForm mainForm;
        private static GameServer server;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            server = new GameServer(new Managers.LogManager());
            mainForm = new MainForm(server);


            Application.Idle += new EventHandler(Application_Idle);
            Application.Run(mainForm);
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            while(NativeMethods.AppStillIdle)
            {
                server.Run();
                Thread.Sleep(1);
            }
        }
    }
}