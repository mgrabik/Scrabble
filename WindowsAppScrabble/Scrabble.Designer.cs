namespace WindowsAppScrabble
{
    partial class Scrabble
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainBoard_panel = new System.Windows.Forms.Panel();
            this.playerBoard_panel = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCheat = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblPlayer1Points = new System.Windows.Forms.Label();
            this.lblPlayer2Points = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu1Player = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu2Players = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu3Players = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu4Players = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.lblPlayer3Points = new System.Windows.Forms.Label();
            this.lblPlayer4Points = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainBoard_panel
            // 
            this.mainBoard_panel.Location = new System.Drawing.Point(50, 30);
            this.mainBoard_panel.Name = "mainBoard_panel";
            this.mainBoard_panel.Size = new System.Drawing.Size(750, 750);
            this.mainBoard_panel.TabIndex = 0;
            this.mainBoard_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // playerBoard_panel
            // 
            this.playerBoard_panel.Location = new System.Drawing.Point(260, 800);
            this.playerBoard_panel.Name = "playerBoard_panel";
            this.playerBoard_panel.Size = new System.Drawing.Size(400, 50);
            this.playerBoard_panel.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 800);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.startEvent);
            // 
            // btnCheat
            // 
            this.btnCheat.Location = new System.Drawing.Point(820, 800);
            this.btnCheat.Name = "btnCheat";
            this.btnCheat.Size = new System.Drawing.Size(80, 40);
            this.btnCheat.TabIndex = 3;
            this.btnCheat.Text = "Cheat";
            this.btnCheat.UseVisualStyleBackColor = true;
            this.btnCheat.Click += new System.EventHandler(this.cheatEvent);
            this.btnCheat.Enabled = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(820, 35);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 40);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.confirmEvent);
            this.btnConfirm.Enabled = false;
            // 
            // Player1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(51)))));
            this.lblPlayer1.Location = new System.Drawing.Point(823, 700);
            this.lblPlayer1.Name = "Player1";
            this.lblPlayer1.Size = new System.Drawing.Size(51, 15);
            this.lblPlayer1.TabIndex = 5;
            this.lblPlayer1.Text = "Player 1:";
            this.lblPlayer1.Visible = false;
            // 
            // Player2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.lblPlayer2.Location = new System.Drawing.Point(823, 720);
            this.lblPlayer2.Name = "Player2";
            this.lblPlayer2.Size = new System.Drawing.Size(51, 15);
            this.lblPlayer2.TabIndex = 6;
            this.lblPlayer2.Text = "Player 2:";
            this.lblPlayer2.Visible = false;
            // 
            // Points
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPoints.ForeColor = System.Drawing.Color.Red;
            this.lblPoints.Location = new System.Drawing.Point(823, 675);
            this.lblPoints.Name = "Points";
            this.lblPoints.Size = new System.Drawing.Size(61, 24);
            this.lblPoints.TabIndex = 7;
            this.lblPoints.Text = "Points";
            // 
            // Player1Points
            // 
            this.lblPlayer1Points.AutoSize = true;
            this.lblPlayer1Points.Location = new System.Drawing.Point(880, 700);
            this.lblPlayer1Points.Name = "Player1Points";
            this.lblPlayer1Points.Size = new System.Drawing.Size(13, 15);
            this.lblPlayer1Points.TabIndex = 8;
            this.lblPlayer1Points.Text = "0";
            this.lblPlayer1Points.Visible = false;
            // 
            // Player2Points
            // 
            this.lblPlayer2Points.AutoSize = true;
            this.lblPlayer2Points.Location = new System.Drawing.Point(880, 720);
            this.lblPlayer2Points.Name = "Player2Points";
            this.lblPlayer2Points.Size = new System.Drawing.Size(13, 15);
            this.lblPlayer2Points.TabIndex = 9;
            this.lblPlayer2Points.Text = "0";
            this.lblPlayer2Points.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.rulesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPlayersToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // setPlayersToolStripMenuItem
            // 
            this.setPlayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu1Player,
            this.toolStripMenu2Players,
            this.toolStripMenu3Players,
            this.toolStripMenu4Players});
            this.setPlayersToolStripMenuItem.Name = "setPlayersToolStripMenuItem";
            this.setPlayersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setPlayersToolStripMenuItem.Text = "Set Players";
            // 
            // toolStripMenuPlayer1
            // 
            this.toolStripMenu1Player.Name = "toolStripMenuPlayer1";
            this.toolStripMenu1Player.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenu1Player.Text = "1";
            this.toolStripMenu1Player.Click += new System.EventHandler(this.toolStripMenuPlayer1_Click);
            // 
            // toolStripMenuPlayer2
            // 
            this.toolStripMenu2Players.Name = "toolStripMenuPlayer2";
            this.toolStripMenu2Players.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenu2Players.Text = "2";
            this.toolStripMenu2Players.Click += new System.EventHandler(this.toolStripMenuPlayer2_Click);
            // 
            // toolStripMenuPlayer3
            // 
            this.toolStripMenu3Players.Name = "toolStripMenuPlayer3";
            this.toolStripMenu3Players.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenu3Players.Text = "3";
            this.toolStripMenu3Players.Click += new System.EventHandler(this.toolStripMenuPlayer3_Click);
            // 
            // toolStripMenuPlayer4
            // 
            this.toolStripMenu4Players.Name = "toolStripMenuPlayer4";
            this.toolStripMenu4Players.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenu4Players.Text = "4";
            this.toolStripMenu4Players.Click += new System.EventHandler(this.toolStripMenuPlayer4_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // Player3
            // 
            this.lblPlayer3.AutoSize = true;
            this.lblPlayer3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(186)))), ((int)(((byte)(3)))));
            this.lblPlayer3.Location = new System.Drawing.Point(823, 740);
            this.lblPlayer3.Name = "Player3";
            this.lblPlayer3.Size = new System.Drawing.Size(51, 15);
            this.lblPlayer3.TabIndex = 11;
            this.lblPlayer3.Text = "Player 3:";
            this.lblPlayer3.Visible = false;
            // 
            // Player4
            // 
            this.lblPlayer4.AutoSize = true;
            this.lblPlayer4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(73)))), ((int)(((byte)(3)))));
            this.lblPlayer4.Location = new System.Drawing.Point(823, 760);
            this.lblPlayer4.Name = "Player4";
            this.lblPlayer4.Size = new System.Drawing.Size(51, 15);
            this.lblPlayer4.TabIndex = 13;
            this.lblPlayer4.Text = "Player 4:";
            this.lblPlayer4.Visible = false;
            // 
            // Player3Points
            // 
            this.lblPlayer3Points.AutoSize = true;
            this.lblPlayer3Points.Location = new System.Drawing.Point(880, 738);
            this.lblPlayer3Points.Name = "Player3Points";
            this.lblPlayer3Points.Size = new System.Drawing.Size(13, 15);
            this.lblPlayer3Points.TabIndex = 12;
            this.lblPlayer3Points.Text = "0";
            this.lblPlayer3Points.Visible = false;
            // 
            // Player4Points
            // 
            this.lblPlayer4Points.AutoSize = true;
            this.lblPlayer4Points.Location = new System.Drawing.Point(880, 758);
            this.lblPlayer4Points.Name = "Player4Points";
            this.lblPlayer4Points.Size = new System.Drawing.Size(13, 15);
            this.lblPlayer4Points.TabIndex = 14;
            this.lblPlayer4Points.Text = "0";
            this.lblPlayer4Points.Visible = false;
            // 
            // Scrabble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 880);
            this.Controls.Add(this.lblPlayer3);
            this.Controls.Add(this.lblPlayer4);
            this.Controls.Add(this.lblPlayer3Points);
            this.Controls.Add(this.lblPlayer4Points);
            this.Controls.Add(this.lblPlayer2Points);
            this.Controls.Add(this.lblPlayer1Points);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCheat);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.playerBoard_panel);
            this.Controls.Add(this.mainBoard_panel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scrabble";
            this.Text = "Scrabble";
            this.Load += new System.EventHandler(this.Scrabble_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainBoard_panel;
        private System.Windows.Forms.Panel playerBoard_panel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCheat;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer4;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblPlayer1Points;
        private System.Windows.Forms.Label lblPlayer2Points;
        private System.Windows.Forms.Label lblPlayer3Points;
        private System.Windows.Forms.Label lblPlayer4Points;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu1Player;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu2Players;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu3Players;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu4Players;
    }
}

