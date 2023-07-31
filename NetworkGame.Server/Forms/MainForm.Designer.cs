namespace NetworkGame.Server.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpServerOperations = new System.Windows.Forms.GroupBox();
            btnStopServer = new System.Windows.Forms.Button();
            btnStartServer = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            dgvServerStatusLog = new System.Windows.Forms.DataGridView();
            clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clmMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpPlayers = new System.Windows.Forms.GroupBox();
            listPlayers = new System.Windows.Forms.ListBox();
            cmnuPlayers = new System.Windows.Forms.ContextMenuStrip(components);
            cmnPlayersKick = new System.Windows.Forms.ToolStripMenuItem();
            grpServerOperations.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServerStatusLog).BeginInit();
            grpPlayers.SuspendLayout();
            cmnuPlayers.SuspendLayout();
            SuspendLayout();
            // 
            // grpServerOperations
            // 
            grpServerOperations.Controls.Add(btnStopServer);
            grpServerOperations.Controls.Add(btnStartServer);
            grpServerOperations.Location = new System.Drawing.Point(12, 12);
            grpServerOperations.Name = "grpServerOperations";
            grpServerOperations.Size = new System.Drawing.Size(262, 56);
            grpServerOperations.TabIndex = 0;
            grpServerOperations.TabStop = false;
            grpServerOperations.Text = "Server Operations";
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new System.Drawing.Point(134, 22);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new System.Drawing.Size(122, 23);
            btnStopServer.TabIndex = 0;
            btnStopServer.Text = "Stop Server";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new System.Drawing.Point(6, 22);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new System.Drawing.Size(122, 23);
            btnStartServer.TabIndex = 0;
            btnStartServer.Text = "Start Server";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvServerStatusLog);
            groupBox1.Location = new System.Drawing.Point(155, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(633, 364);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Server Status Log";
            // 
            // dgvServerStatusLog
            // 
            dgvServerStatusLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServerStatusLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clmId, clmMessage });
            dgvServerStatusLog.Location = new System.Drawing.Point(6, 22);
            dgvServerStatusLog.Name = "dgvServerStatusLog";
            dgvServerStatusLog.RowTemplate.Height = 25;
            dgvServerStatusLog.Size = new System.Drawing.Size(621, 331);
            dgvServerStatusLog.TabIndex = 0;
            // 
            // clmId
            // 
            clmId.HeaderText = "Id";
            clmId.Name = "clmId";
            // 
            // clmMessage
            // 
            clmMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            clmMessage.HeaderText = "Message";
            clmMessage.Name = "clmMessage";
            // 
            // grpPlayers
            // 
            grpPlayers.Controls.Add(listPlayers);
            grpPlayers.Location = new System.Drawing.Point(12, 74);
            grpPlayers.Name = "grpPlayers";
            grpPlayers.Size = new System.Drawing.Size(137, 364);
            grpPlayers.TabIndex = 2;
            grpPlayers.TabStop = false;
            grpPlayers.Text = "Players";
            // 
            // listPlayers
            // 
            listPlayers.ContextMenuStrip = cmnuPlayers;
            listPlayers.FormattingEnabled = true;
            listPlayers.ItemHeight = 15;
            listPlayers.Location = new System.Drawing.Point(3, 19);
            listPlayers.Name = "listPlayers";
            listPlayers.Size = new System.Drawing.Size(128, 334);
            listPlayers.TabIndex = 0;
            // 
            // cmnuPlayers
            // 
            cmnuPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { cmnPlayersKick });
            cmnuPlayers.Name = "cmnuPlayers";
            cmnuPlayers.Size = new System.Drawing.Size(97, 26);
            // 
            // cmnPlayersKick
            // 
            cmnPlayersKick.Name = "cmnPlayersKick";
            cmnPlayersKick.Size = new System.Drawing.Size(96, 22);
            cmnPlayersKick.Text = "Kick";
            cmnPlayersKick.Click += cmnPlayersKick_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(grpPlayers);
            Controls.Add(groupBox1);
            Controls.Add(grpServerOperations);
            Name = "MainForm";
            Text = "MainForm";
            grpServerOperations.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServerStatusLog).EndInit();
            grpPlayers.ResumeLayout(false);
            cmnuPlayers.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpServerOperations;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvServerStatusLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMessage;
        private System.Windows.Forms.GroupBox grpPlayers;
        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.ContextMenuStrip cmnuPlayers;
        private System.Windows.Forms.ToolStripMenuItem cmnPlayersKick;
    }
}