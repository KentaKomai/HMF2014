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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbxMainCamera = new System.Windows.Forms.PictureBox();
            this.lblUserGuide = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMainCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(831, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // authenticationToolStripMenuItem
            // 
            this.authenticationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trueToolStripMenuItem,
            this.falseToolStripMenuItem});
            this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.authenticationToolStripMenuItem.Text = "Authentication";
            // 
            // trueToolStripMenuItem
            // 
            this.trueToolStripMenuItem.Name = "trueToolStripMenuItem";
            this.trueToolStripMenuItem.Size = new System.Drawing.Size(123, 30);
            this.trueToolStripMenuItem.Text = "True";
            // 
            // falseToolStripMenuItem
            // 
            this.falseToolStripMenuItem.Name = "falseToolStripMenuItem";
            this.falseToolStripMenuItem.Size = new System.Drawing.Size(123, 30);
            this.falseToolStripMenuItem.Text = "False";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 814);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(96, 25);
            this.lblUserStatus.Text = "UserStatus";
            // 
            // pbxMainCamera
            // 
            this.pbxMainCamera.Location = new System.Drawing.Point(13, 39);
            this.pbxMainCamera.Name = "pbxMainCamera";
            this.pbxMainCamera.Size = new System.Drawing.Size(800, 600);
            this.pbxMainCamera.TabIndex = 2;
            this.pbxMainCamera.TabStop = false;
            // 
            // lblUserGuide
            // 
            this.lblUserGuide.AutoSize = true;
            this.lblUserGuide.BackColor = System.Drawing.Color.Transparent;
            this.lblUserGuide.Font = new System.Drawing.Font("KaiTi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserGuide.ForeColor = System.Drawing.Color.Green;
            this.lblUserGuide.Location = new System.Drawing.Point(13, 39);
            this.lblUserGuide.Name = "lblUserGuide";
            this.lblUserGuide.Size = new System.Drawing.Size(112, 40);
            this.lblUserGuide.TabIndex = 3;
            this.lblUserGuide.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 844);
            this.Controls.Add(this.lblUserGuide);
            this.Controls.Add(this.pbxMainCamera);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
    }
}