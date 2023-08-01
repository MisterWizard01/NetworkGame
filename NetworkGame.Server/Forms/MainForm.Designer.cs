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
            this.components = new System.ComponentModel.Container();
            this.grpServerOperations = new System.Windows.Forms.GroupBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvServerStatusLog = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPlayers = new System.Windows.Forms.GroupBox();
            this.listPlayers = new System.Windows.Forms.ListBox();
            this.cmnuPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnPlayersKick = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhysicsUPS = new System.Windows.Forms.Label();
            this.grpServerOperations.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerStatusLog)).BeginInit();
            this.grpPlayers.SuspendLayout();
            this.cmnuPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServerOperations
            // 
            this.grpServerOperations.Controls.Add(this.btnStopServer);
            this.grpServerOperations.Controls.Add(this.btnStartServer);
            this.grpServerOperations.Location = new System.Drawing.Point(12, 12);
            this.grpServerOperations.Name = "grpServerOperations";
            this.grpServerOperations.Size = new System.Drawing.Size(262, 56);
            this.grpServerOperations.TabIndex = 0;
            this.grpServerOperations.TabStop = false;
            this.grpServerOperations.Text = "Server Operations";
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(134, 22);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(122, 23);
            this.btnStopServer.TabIndex = 0;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(6, 22);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(122, 23);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvServerStatusLog);
            this.groupBox1.Location = new System.Drawing.Point(155, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 364);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Status Log";
            // 
            // dgvServerStatusLog
            // 
            this.dgvServerStatusLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServerStatusLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmMessage});
            this.dgvServerStatusLog.Location = new System.Drawing.Point(6, 22);
            this.dgvServerStatusLog.Name = "dgvServerStatusLog";
            this.dgvServerStatusLog.RowTemplate.Height = 25;
            this.dgvServerStatusLog.Size = new System.Drawing.Size(621, 331);
            this.dgvServerStatusLog.TabIndex = 0;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            // 
            // clmMessage
            // 
            this.clmMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMessage.HeaderText = "Message";
            this.clmMessage.Name = "clmMessage";
            // 
            // grpPlayers
            // 
            this.grpPlayers.Controls.Add(this.listPlayers);
            this.grpPlayers.Location = new System.Drawing.Point(12, 74);
            this.grpPlayers.Name = "grpPlayers";
            this.grpPlayers.Size = new System.Drawing.Size(137, 364);
            this.grpPlayers.TabIndex = 2;
            this.grpPlayers.TabStop = false;
            this.grpPlayers.Text = "Players";
            // 
            // listPlayers
            // 
            this.listPlayers.ContextMenuStrip = this.cmnuPlayers;
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 15;
            this.listPlayers.Location = new System.Drawing.Point(3, 19);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(128, 334);
            this.listPlayers.TabIndex = 0;
            // 
            // cmnuPlayers
            // 
            this.cmnuPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnPlayersKick});
            this.cmnuPlayers.Name = "cmnuPlayers";
            this.cmnuPlayers.Size = new System.Drawing.Size(97, 26);
            // 
            // cmnPlayersKick
            // 
            this.cmnPlayersKick.Name = "cmnPlayersKick";
            this.cmnPlayersKick.Size = new System.Drawing.Size(96, 22);
            this.cmnPlayersKick.Text = "Kick";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Physics Updates/sec.:";
            // 
            // lblPhysicsUPS
            // 
            this.lblPhysicsUPS.AutoSize = true;
            this.lblPhysicsUPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhysicsUPS.Location = new System.Drawing.Point(406, 12);
            this.lblPhysicsUPS.Name = "lblPhysicsUPS";
            this.lblPhysicsUPS.Size = new System.Drawing.Size(13, 15);
            this.lblPhysicsUPS.TabIndex = 4;
            this.lblPhysicsUPS.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPhysicsUPS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpPlayers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpServerOperations);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.grpServerOperations.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerStatusLog)).EndInit();
            this.grpPlayers.ResumeLayout(false);
            this.cmnuPlayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhysicsUPS;
    }
}