namespace WindowsAppScrabble
{
    using System.Windows.Forms;
    partial class CheatsInfo : Form
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
            Scrabble.cheatIsOpen = false;
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelword3 = new System.Windows.Forms.Label();
            this.labelword2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelword3);
            this.panel1.Controls.Add(this.labelword2);
            this.panel1.Location = new System.Drawing.Point(20, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 540);
            this.panel1.TabIndex = 0;
            // 
            // labelword3
            // 
            this.labelword3.AutoSize = true;
            this.labelword3.Location = new System.Drawing.Point(180, 0);
            this.labelword3.Name = "labelword3";
            this.labelword3.Size = new System.Drawing.Size(0, 15);
            this.labelword3.TabIndex = 1;
            // 
            // labelword2
            // 
            this.labelword2.AutoSize = true;
            this.labelword2.Location = new System.Drawing.Point(0, 0);
            this.labelword2.Name = "labelword2";
            this.labelword2.Size = new System.Drawing.Size(150, 540);
            this.labelword2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Possible Words:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.refresh);
            // 
            // CheatsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "CheatsInfo";
            this.Text = "Cheats";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label labelword2;
        private Label labelword3;
        private Button button1;
    }
}