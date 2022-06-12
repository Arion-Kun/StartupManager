namespace Dawn.Apps.StartupManager.Pages;

using System.ComponentModel;
using System.Windows.Forms;

partial class AboutForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
        this.@__AboutHeader = new System.Windows.Forms.Panel();
        this.@__CancelButton = new System.Windows.Forms.Button();
        this.@__AboutLabel = new System.Windows.Forms.Label();
        this.@__BorderEnforcer = new System.Windows.Forms.Panel();
        this.@__DescriptionBox = new System.Windows.Forms.TextBox();
        this.@__ProjectLinkLabel = new System.Windows.Forms.LinkLabel();
        this.@__LatestBuildLabel = new System.Windows.Forms.Label();
        this.@__CurrentBuildDate = new System.Windows.Forms.Label();
        this.@__VersionLabel = new System.Windows.Forms.Label();
        this.@__UpdateButton = new System.Windows.Forms.Button();
        this.@__OkButton = new System.Windows.Forms.Button();
        this.@__AboutHeader.SuspendLayout();
        this.@__BorderEnforcer.SuspendLayout();
        this.SuspendLayout();
        // 
        // __AboutHeader
        // 
        this.@__AboutHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
        this.@__AboutHeader.Controls.Add(this.@__CancelButton);
        this.@__AboutHeader.Controls.Add(this.@__AboutLabel);
        resources.ApplyResources(this.@__AboutHeader, "__AboutHeader");
        this.@__AboutHeader.Name = "__AboutHeader";
        this.@__AboutHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.@__AboutHeader_MouseDown);
        // 
        // __CancelButton
        // 
        this.@__CancelButton.BackColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.BackgroundImage = global::Dawn.Apps.StartupManager.Properties.Resources.icons8_cancel;
        resources.ApplyResources(this.@__CancelButton, "__CancelButton");
        this.@__CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        this.@__CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.@__CancelButton.FlatAppearance.BorderSize = 0;
        this.@__CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.ForeColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.Name = "__CancelButton";
        this.@__CancelButton.TabStop = false;
        this.@__CancelButton.UseVisualStyleBackColor = false;
        // 
        // __AboutLabel
        // 
        resources.ApplyResources(this.@__AboutLabel, "__AboutLabel");
        this.@__AboutLabel.ForeColor = System.Drawing.Color.White;
        this.@__AboutLabel.Name = "__AboutLabel";
        this.@__AboutLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.@__AboutLabel_MouseDown);
        // 
        // __BorderEnforcer
        // 
        this.@__BorderEnforcer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.@__BorderEnforcer.Controls.Add(this.@__AboutHeader);
        this.@__BorderEnforcer.Controls.Add(this.@__DescriptionBox);
        this.@__BorderEnforcer.Controls.Add(this.@__ProjectLinkLabel);
        this.@__BorderEnforcer.Controls.Add(this.@__LatestBuildLabel);
        this.@__BorderEnforcer.Controls.Add(this.@__CurrentBuildDate);
        this.@__BorderEnforcer.Controls.Add(this.@__VersionLabel);
        this.@__BorderEnforcer.Controls.Add(this.@__UpdateButton);
        this.@__BorderEnforcer.Controls.Add(this.@__OkButton);
        resources.ApplyResources(this.@__BorderEnforcer, "__BorderEnforcer");
        this.@__BorderEnforcer.Name = "__BorderEnforcer";
        // 
        // __DescriptionBox
        // 
        this.@__DescriptionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.@__DescriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.@__DescriptionBox.ForeColor = System.Drawing.Color.White;
        resources.ApplyResources(this.@__DescriptionBox, "__DescriptionBox");
        this.@__DescriptionBox.Name = "__DescriptionBox";
        this.@__DescriptionBox.ReadOnly = true;
        // 
        // __ProjectLinkLabel
        // 
        this.@__ProjectLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
        this.@__ProjectLinkLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
        resources.ApplyResources(this.@__ProjectLinkLabel, "__ProjectLinkLabel");
        this.@__ProjectLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
        this.@__ProjectLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__ProjectLinkLabel.Name = "__ProjectLinkLabel";
        this.@__ProjectLinkLabel.TabStop = true;
        this.@__ProjectLinkLabel.VisitedLinkColor = System.Drawing.Color.White;
        this.@__ProjectLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.@__ProjectLinkLabel_LinkClicked);
        // 
        // __LatestBuildLabel
        // 
        this.@__LatestBuildLabel.ForeColor = System.Drawing.Color.White;
        resources.ApplyResources(this.@__LatestBuildLabel, "__LatestBuildLabel");
        this.@__LatestBuildLabel.Name = "__LatestBuildLabel";
        // 
        // __CurrentBuildDate
        // 
        this.@__CurrentBuildDate.ForeColor = System.Drawing.Color.White;
        resources.ApplyResources(this.@__CurrentBuildDate, "__CurrentBuildDate");
        this.@__CurrentBuildDate.Name = "__CurrentBuildDate";
        // 
        // __VersionLabel
        // 
        this.@__VersionLabel.ForeColor = System.Drawing.Color.White;
        resources.ApplyResources(this.@__VersionLabel, "__VersionLabel");
        this.@__VersionLabel.Name = "__VersionLabel";
        // 
        // __UpdateButton
        // 
        this.@__UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__UpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(114)))), ((int)(((byte)(193)))));
        resources.ApplyResources(this.@__UpdateButton, "__UpdateButton");
        this.@__UpdateButton.ForeColor = System.Drawing.Color.White;
        this.@__UpdateButton.Name = "__UpdateButton";
        this.@__UpdateButton.UseVisualStyleBackColor = false;
        this.@__UpdateButton.Click += new System.EventHandler(this.@__UpdateButton_Click);
        // 
        // __OkButton
        // 
        this.@__OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.@__OkButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(114)))), ((int)(((byte)(193)))));
        resources.ApplyResources(this.@__OkButton, "__OkButton");
        this.@__OkButton.ForeColor = System.Drawing.Color.White;
        this.@__OkButton.Name = "__OkButton";
        this.@__OkButton.UseVisualStyleBackColor = false;
        // 
        // AboutForm
        // 
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
        this.Controls.Add(this.@__BorderEnforcer);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AboutForm";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutForm_KeyDown);
        this.@__AboutHeader.ResumeLayout(false);
        this.@__BorderEnforcer.ResumeLayout(false);
        this.@__BorderEnforcer.PerformLayout();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox __DescriptionBox;

    private System.Windows.Forms.LinkLabel __ProjectLinkLabel;

    private System.Windows.Forms.Label __CurrentBuildDate;
    private System.Windows.Forms.Label __LatestBuildLabel;

    private System.Windows.Forms.Label __VersionLabel;

    private System.Windows.Forms.Button __UpdateButton;

    private System.Windows.Forms.Button __OkButton;

    private System.Windows.Forms.Panel __BorderEnforcer;

    private System.Windows.Forms.Button __CancelButton;

    private System.Windows.Forms.Label __AboutLabel;

    private System.Windows.Forms.Panel __AboutHeader;

    #endregion
}