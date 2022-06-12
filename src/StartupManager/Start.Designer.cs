namespace Dawn.Apps.StartupManager
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this._TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TCM_menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.TCM_btn_RunOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.TCM_btn_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.PageStrip = new System.Windows.Forms.MenuStrip();
            this.StartupFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.UACBox = new System.Windows.Forms.ToolStripMenuItem();
            this.Cleanup = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formContainer = new System.Windows.Forms.Panel();
            this.TrayContextMenu.SuspendLayout();
            this.PageStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _TrayIcon
            // 
            this._TrayIcon.ContextMenuStrip = this.TrayContextMenu;
            this._TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_TrayIcon.Icon")));
            this._TrayIcon.Text = "Startup Manager";
            this._TrayIcon.Visible = true;
            this._TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TCM_menu_Settings, this.TCM_btn_Exit });
            this.TrayContextMenu.Name = "TrayContextMenu";
            this.TrayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TrayContextMenu.Size = new System.Drawing.Size(120, 48);
            // 
            // TCM_menu_Settings
            // 
            this.TCM_menu_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TCM_btn_RunOnStartup });
            this.TCM_menu_Settings.Name = "TCM_menu_Settings";
            this.TCM_menu_Settings.Size = new System.Drawing.Size(119, 22);
            this.TCM_menu_Settings.Text = " Settings";
            // 
            // TCM_btn_RunOnStartup
            // 
            this.TCM_btn_RunOnStartup.Name = "TCM_btn_RunOnStartup";
            this.TCM_btn_RunOnStartup.Size = new System.Drawing.Size(153, 22);
            this.TCM_btn_RunOnStartup.Text = "Run on Startup";
            this.TCM_btn_RunOnStartup.Click += new System.EventHandler(this.TCM_btn_RunOnStartup_Click);
            // 
            // TCM_btn_Exit
            // 
            this.TCM_btn_Exit.Name = "TCM_btn_Exit";
            this.TCM_btn_Exit.Size = new System.Drawing.Size(119, 22);
            this.TCM_btn_Exit.Text = "Exit";
            this.TCM_btn_Exit.Click += new System.EventHandler(this.TCM_btn_Exit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // PageStrip
            // 
            this.PageStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.StartupFolder, this.UACBox, this.Cleanup, this.aboutToolStripMenuItem });
            this.PageStrip.Location = new System.Drawing.Point(0, 0);
            this.PageStrip.Name = "PageStrip";
            this.PageStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.PageStrip.Size = new System.Drawing.Size(820, 24);
            this.PageStrip.TabIndex = 3;
            this.PageStrip.Text = "PageStrip";
            // 
            // StartupFolder
            // 
            this.StartupFolder.Name = "StartupFolder";
            this.StartupFolder.Size = new System.Drawing.Size(93, 20);
            this.StartupFolder.Text = "Startup Folder";
            this.StartupFolder.Click += new System.EventHandler(this.StartupFolder_Click);
            // 
            // UACBox
            // 
            this.UACBox.Image = ((System.Drawing.Image)(resources.GetObject("UACBox.Image")));
            this.UACBox.Name = "UACBox";
            this.UACBox.Size = new System.Drawing.Size(166, 20);
            this.UACBox.Text = "Include LocalMachine ❌";
            this.UACBox.Click += new System.EventHandler(this.UACBox_Click);
            // 
            // Cleanup
            // 
            this.Cleanup.Enabled = false;
            this.Cleanup.Image = global::Dawn.Apps.StartupManager.Properties.Resources.recycle_empty;
            this.Cleanup.Name = "Cleanup";
            this.Cleanup.Size = new System.Drawing.Size(79, 20);
            this.Cleanup.Text = "Cleanup";
            this.Cleanup.ToolTipText = "Cleaning up broken / old entries.";
            this.Cleanup.Click += new System.EventHandler(this.Cleanup_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // formContainer
            // 
            this.formContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formContainer.Location = new System.Drawing.Point(0, 24);
            this.formContainer.Name = "formContainer";
            this.formContainer.Size = new System.Drawing.Size(820, 397);
            this.formContainer.TabIndex = 4;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 421);
            this.Controls.Add(this.formContainer);
            this.Controls.Add(this.PageStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Start";
            this.ShowIcon = false;
            this.Text = "Startup Manager";
            this.Resize += new System.EventHandler(this.Start_Resize);
            this.TrayContextMenu.ResumeLayout(false);
            this.PageStrip.ResumeLayout(false);
            this.PageStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem Cleanup;

        private System.Windows.Forms.ToolStripMenuItem UACBox;

        private System.Windows.Forms.Panel formContainer;

        private System.Windows.Forms.ToolStripMenuItem StartupFolder;

        private System.Windows.Forms.MenuStrip PageStrip;

        private System.Windows.Forms.ToolStripButton toolStripButton1;

        internal System.Windows.Forms.ToolStripMenuItem TCM_btn_RunOnStartup;

        private System.Windows.Forms.ToolStripMenuItem TCM_btn_Exit;

        private System.Windows.Forms.ToolStripMenuItem TCM_menu_Settings;

        private System.Windows.Forms.ContextMenuStrip TrayContextMenu;

        private System.Windows.Forms.NotifyIcon _TrayIcon;

        #endregion
    }
}