namespace Dawn.Apps.StartupManager.DialogBoxes;

using System.ComponentModel;

partial class ConfirmDialogBox
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
        this.MessageLabel = new System.Windows.Forms.Label();
        this.@__BorderEnforcer = new System.Windows.Forms.Panel();
        this.@__CancelButton = new System.Windows.Forms.Button();
        this.@__AcceptButton = new System.Windows.Forms.Button();
        this.@__AboutHeader = new System.Windows.Forms.Panel();
        this.button1 = new System.Windows.Forms.Button();
        this.TitleLabel = new System.Windows.Forms.Label();
        this.@__BorderEnforcer.SuspendLayout();
        this.@__AboutHeader.SuspendLayout();
        this.SuspendLayout();
        // 
        // MessageLabel
        // 
        this.MessageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.MessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.MessageLabel.Location = new System.Drawing.Point(98, 50);
        this.MessageLabel.Name = "MessageLabel";
        this.MessageLabel.Size = new System.Drawing.Size(250, 50);
        this.MessageLabel.TabIndex = 2;
        this.MessageLabel.Text = "{Message}";
        this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.MessageLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageLabel_MouseDown);
        // 
        // __BorderEnforcer
        // 
        this.@__BorderEnforcer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.@__BorderEnforcer.Controls.Add(this.@__CancelButton);
        this.@__BorderEnforcer.Controls.Add(this.@__AcceptButton);
        this.@__BorderEnforcer.Controls.Add(this.@__AboutHeader);
        this.@__BorderEnforcer.Controls.Add(this.MessageLabel);
        this.@__BorderEnforcer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.@__BorderEnforcer.Location = new System.Drawing.Point(3, 3);
        this.@__BorderEnforcer.Margin = new System.Windows.Forms.Padding(6);
        this.@__BorderEnforcer.Name = "__BorderEnforcer";
        this.@__BorderEnforcer.Size = new System.Drawing.Size(444, 194);
        this.@__BorderEnforcer.TabIndex = 4;
        // 
        // __CancelButton
        // 
        this.@__CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.@__CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(114)))), ((int)(((byte)(193)))));
        this.@__CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.@__CancelButton.ForeColor = System.Drawing.Color.White;
        this.@__CancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.@__CancelButton.Location = new System.Drawing.Point(346, 158);
        this.@__CancelButton.Name = "__CancelButton";
        this.@__CancelButton.Size = new System.Drawing.Size(90, 30);
        this.@__CancelButton.TabIndex = 8;
        this.@__CancelButton.Text = "&Cancel";
        this.@__CancelButton.UseVisualStyleBackColor = false;
        // 
        // __AcceptButton
        // 
        this.@__AcceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.@__AcceptButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(114)))), ((int)(((byte)(193)))));
        this.@__AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.@__AcceptButton.ForeColor = System.Drawing.Color.White;
        this.@__AcceptButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.@__AcceptButton.Location = new System.Drawing.Point(12, 158);
        this.@__AcceptButton.Name = "__AcceptButton";
        this.@__AcceptButton.Size = new System.Drawing.Size(90, 30);
        this.@__AcceptButton.TabIndex = 7;
        this.@__AcceptButton.Text = "&OK";
        this.@__AcceptButton.UseVisualStyleBackColor = false;
        // 
        // __AboutHeader
        // 
        this.@__AboutHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
        this.@__AboutHeader.Controls.Add(this.button1);
        this.@__AboutHeader.Controls.Add(this.TitleLabel);
        this.@__AboutHeader.Location = new System.Drawing.Point(3, 3);
        this.@__AboutHeader.Name = "__AboutHeader";
        this.@__AboutHeader.Size = new System.Drawing.Size(440, 36);
        this.@__AboutHeader.TabIndex = 6;
        this.@__AboutHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
        // 
        // button1
        // 
        this.button1.BackColor = System.Drawing.Color.Transparent;
        this.button1.BackgroundImage = global::Dawn.Apps.StartupManager.Properties.Resources.icons8_cancel;
        this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button1.FlatAppearance.BorderSize = 0;
        this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.ForeColor = System.Drawing.Color.Transparent;
        this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.button1.Location = new System.Drawing.Point(409, 4);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(24, 24);
        this.button1.TabIndex = 1;
        this.button1.TabStop = false;
        this.button1.UseVisualStyleBackColor = false;
        // 
        // TitleLabel
        // 
        this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
        this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
        this.TitleLabel.ForeColor = System.Drawing.Color.White;
        this.TitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.TitleLabel.Location = new System.Drawing.Point(37, 7);
        this.TitleLabel.Name = "TitleLabel";
        this.TitleLabel.Size = new System.Drawing.Size(366, 21);
        this.TitleLabel.TabIndex = 0;
        this.TitleLabel.Text = "{Title}";
        this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
        // 
        // ConfirmDialogBox
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(450, 200);
        this.Controls.Add(this.@__BorderEnforcer);
        this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(216)))), ((int)(((byte)(170)))));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Location = new System.Drawing.Point(15, 15);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ConfirmDialogBox";
        this.Padding = new System.Windows.Forms.Padding(3);
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmDialogBox_KeyDown);
        this.@__BorderEnforcer.ResumeLayout(false);
        this.@__AboutHeader.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button __CancelButton;

    private System.Windows.Forms.Button __AcceptButton;

    private System.Windows.Forms.Panel __AboutHeader;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label TitleLabel;

    private System.Windows.Forms.Panel __BorderEnforcer;


    private System.Windows.Forms.Label MessageLabel;
    

    #endregion
}