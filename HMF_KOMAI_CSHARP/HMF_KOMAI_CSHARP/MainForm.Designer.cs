namespace HMF_KOMAI_CSHARP
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.falseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblUserStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.pbxMainCamera = new System.Windows.Forms.PictureBox();
			this.lblUserGuide = new System.Windows.Forms.Label();
			this.voiceMemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxMainCamera)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.testToolStripMenuItem,
            this.recordToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(499, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// applicationToolStripMenuItem
			// 
			this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
			this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.applicationToolStripMenuItem.Text = "Application";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// authenticationToolStripMenuItem
			// 
			this.authenticationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trueToolStripMenuItem,
            this.falseToolStripMenuItem});
			this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
			this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.authenticationToolStripMenuItem.Text = "Authentication";
			// 
			// trueToolStripMenuItem
			// 
			this.trueToolStripMenuItem.Name = "trueToolStripMenuItem";
			this.trueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.trueToolStripMenuItem.Text = "True";
			// 
			// falseToolStripMenuItem
			// 
			this.falseToolStripMenuItem.Name = "falseToolStripMenuItem";
			this.falseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.falseToolStripMenuItem.Text = "False";
			// 
			// recordToolStripMenuItem
			// 
			this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.voiceMemoToolStripMenuItem});
			this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
			this.recordToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
			this.recordToolStripMenuItem.Text = "VoiceRecord";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 478);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
			this.statusStrip1.Size = new System.Drawing.Size(499, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblUserStatus
			// 
			this.lblUserStatus.Name = "lblUserStatus";
			this.lblUserStatus.Size = new System.Drawing.Size(62, 17);
			this.lblUserStatus.Text = "UserStatus";
			// 
			// pbxMainCamera
			// 
			this.pbxMainCamera.Location = new System.Drawing.Point(8, 26);
			this.pbxMainCamera.Margin = new System.Windows.Forms.Padding(2);
			this.pbxMainCamera.Name = "pbxMainCamera";
			this.pbxMainCamera.Size = new System.Drawing.Size(480, 400);
			this.pbxMainCamera.TabIndex = 2;
			this.pbxMainCamera.TabStop = false;
			// 
			// lblUserGuide
			// 
			this.lblUserGuide.AutoSize = true;
			this.lblUserGuide.BackColor = System.Drawing.Color.Transparent;
			this.lblUserGuide.Font = new System.Drawing.Font("KaiTi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblUserGuide.ForeColor = System.Drawing.Color.Green;
			this.lblUserGuide.Location = new System.Drawing.Point(8, 26);
			this.lblUserGuide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblUserGuide.Name = "lblUserGuide";
			this.lblUserGuide.Size = new System.Drawing.Size(78, 27);
			this.lblUserGuide.TabIndex = 3;
			this.lblUserGuide.Text = "label1";
			// 
			// voiceMemoToolStripMenuItem
			// 
			this.voiceMemoToolStripMenuItem.Name = "voiceMemoToolStripMenuItem";
			this.voiceMemoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.voiceMemoToolStripMenuItem.Text = "VoiceMemo";
			this.voiceMemoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlayVoiceMemo);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 500);
			this.Controls.Add(this.lblUserGuide);
			this.Controls.Add(this.pbxMainCamera);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MAIN FORM";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxMainCamera)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem falseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserStatus;
        private System.Windows.Forms.PictureBox pbxMainCamera;
        private System.Windows.Forms.Label lblUserGuide;
		private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem voiceMemoToolStripMenuItem;
    }
}