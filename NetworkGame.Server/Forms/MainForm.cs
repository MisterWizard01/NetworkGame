using NetworkGame.Server.Managers;
using NetworkGame.Server.MyEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkGame.Server.Forms
{
    public partial class MainForm : Form
    {
        private Task _task;
        private Server _server;
        private LogManager _logManager;
        private CancellationTokenSource _cancellationTokenSource;

        public MainForm()
        {
            _logManager = new LogManager();
            _logManager.NewLogMessageEvent += NewLogMessageEvent;
            _server = new Server(_logManager);
            _server.NewPlayer += NewPlayerEvent;
            _server.RemovePlayer += RemovePlayerEvent;
            _server.ShowPhysicsUPS += SetPhysicsUPSEvent;
            InitializeComponent();
        }

        private void NewPlayerEvent(object? sender, NewPlayerEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<NewPlayerEventArgs>(NewPlayerEvent), sender, e);
                return;
            }

            listPlayers.Items.Add(e.Username);
        }

        private void RemovePlayerEvent(object? sender, RemovePlayerEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<RemovePlayerEventArgs>(RemovePlayerEvent), sender, e);
                return;
            }

            listPlayers.Items.Remove(e.Username);
        }

        private void NewLogMessageEvent(object? sender, LogMessageEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<LogMessageEventArgs>(NewLogMessageEvent), sender, e);
                return;
            }
            dgvServerStatusLog.Rows.Add(new[] { e.LogMessage.Id, e.LogMessage.Message });
        }

        public void SetPhysicsUPSEvent(object? sender, ChangeLabelEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<ChangeLabelEventArgs>(SetPhysicsUPSEvent), sender, e);
                return;
            }
            lblPhysicsUPS.Text = e.Value;
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;

            _cancellationTokenSource = new CancellationTokenSource();
            _task = new Task(_server.Run);
            _task.Start();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (_task != null && _cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                btnStartServer.Enabled = true;
                btnStopServer.Enabled = false;
            }
        }

        #region Context Menu Players
        private void cmnPlayersKick_Click(object sender, EventArgs e)
        {
            if (listPlayers.SelectedIndex < 0)
            {
                MessageBox.Show("Select a player first.");
                return;
            }

            _server.KickPlayer(listPlayers.SelectedIndex);
            listPlayers.Items.RemoveAt(listPlayers.SelectedIndex);
        }

        #endregion
    }
}
