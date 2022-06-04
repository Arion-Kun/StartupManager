namespace Dawn.Apps.StartupManager.Pages;

using System.ComponentModel;

partial class CleanupForm
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CleanupForm));
        this.@__DeleteAllButton = new System.Windows.Forms.Button();
        this.@__DeleteButton = new System.Windows.Forms.Button();
        this.@__AboutHeader = new System.Windows.Forms.Panel();
        this.@__HelpHoverButton = new System.Windows.Forms.Button();
        this.@__CancelButton = new System.Windows.Forms.Button();
        this.@__AboutLabel = new System.Windows.Forms.Label();
        this.@__EntryList = new System.Windows.Forms.ListBox();
        this.@__BorderEnforcer = new System.Windows.Forms.Panel();
        this.@__HelpInfo = new System.Windows.Forms.ToolTip(this.components);
        this.@__AboutHeader.SuspendLayout();
        this.@__BorderEnforcer.SuspendLayout();
        this.SuspendLayout();
        // 
        // __DeleteAllButton
        // 
        this.@__DeleteAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__DeleteAllButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.@__DeleteAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(114)))), ((int)(((byte)(193)))));
        this.@__DeleteAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.@__DeleteAllButton.ForeColor = System.Drawing.Color.White;
        this.@__DeleteAllButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.@__DeleteAllButton.Location = new System.Drawing.Point(486, 286);
        this.@__DeleteAllButton.Name = "__DeleteAllButton";
        this.@__DeleteAllButton.Size = new System.Drawing.Size(90, 30);
        this.@__DeleteAllButton.TabIndex = 2;
        this.@__DeleteAllButton.Text = "Delete &All";
        this.@__DeleteAllButton.UseVisualStyleBackColor = false;
        this.@__DeleteAllButton.Click += new System.EventHandler(this.@__DeleteAllButton_Click);
        // 
        // __DeleteButton
        // 
        this.@__DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.@__DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(114)))), ((int)(((byte)(193)))));
        this.@__DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.@__DeleteButton.ForeColor = System.Drawing.Color.White;
        this.@__DeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.@__DeleteButton.Location = new System.Drawing.Point(486, 45);
        this.@__DeleteButton.Name = "__DeleteButton";
        this.@__DeleteButton.Size = new System.Drawing.Size(90, 30);
        this.@__DeleteButton.TabIndex = 3;
        this.@__DeleteButton.Text = "&Delete";
        this.@__DeleteButton.UseVisualStyleBackColor = false;
        this.@__DeleteButton.Click += new System.EventHandler(this.@__DeleteButton_Click);
        // 
        // __AboutHeader
        // 
        this.@__AboutHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
        this.@__AboutHeader.Controls.Add(this.@__HelpHoverButton);
        this.@__AboutHeader.Controls.Add(this.@__CancelButton);
        this.@__AboutHeader.Controls.Add(this.@__AboutLabel);
        this.@__AboutHeader.Location = new System.Drawing.Point(3, 3);
        this.@__AboutHeader.Name = "__AboutHeader";
        this.@__AboutHeader.Size = new System.Drawing.Size(576, 36);
        this.@__AboutHeader.TabIndex = 4;
        this.@__AboutHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.@__AboutHeader_MouseDown);
        // 
        // __HelpHoverButton
        // 
        this.@__HelpHoverButton.BackColor = System.Drawing.Color.Transparent;
        this.@__HelpHoverButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(91)))), ((int)(((byte)(109)))));
        this.@__HelpHoverButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
        this.@__HelpHoverButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
        this.@__HelpHoverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.@__HelpHoverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
        this.@__HelpHoverButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(91)))), ((int)(((byte)(109)))));
        this.@__HelpHoverButton.Location = new System.Drawing.Point(3, 3);
        this.@__HelpHoverButton.Name = "__HelpHoverButton";
        this.@__HelpHoverButton.Size = new System.Drawing.Size(27, 29);
        this.@__HelpHoverButton.TabIndex = 2;
        this.@__HelpHoverButton.Text = "?";
        this.@__HelpInfo.SetToolTip(this.@__HelpHoverButton, resources.GetString("__HelpHoverButton.ToolTip"));
        this.@__HelpHoverButton.UseVisualStyleBackColor = false;
        this.@__HelpHoverButton.Click += new System.EventHandler(this.@__HelpHoverButton_Click);
        // 
        // __CancelButton
        // 
        this.@__CancelButton.BackColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.BackgroundImage = global::Dawn.Apps.StartupManager.Properties.Resources.icons8_cancel;
        this.@__CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.@__CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        this.@__CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.@__CancelButton.FlatAppearance.BorderSize = 0;
        this.@__CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.@__CancelButton.ForeColor = System.Drawing.Color.Transparent;
        this.@__CancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.@__CancelButton.Location = new System.Drawing.Point(549, 4);
        this.@__CancelButton.Name = "__CancelButton";
        this.@__CancelButton.Size = new System.Drawing.Size(24, 24);
        this.@__CancelButton.TabIndex = 1;
        this.@__CancelButton.TabStop = false;
        this.@__CancelButton.UseVisualStyleBackColor = false;
        // 
        // __AboutLabel
        // 
        this.@__AboutLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.@__AboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
        this.@__AboutLabel.ForeColor = System.Drawing.Color.White;
        this.@__AboutLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.@__AboutLabel.Location = new System.Drawing.Point(249, 10);
        this.@__AboutLabel.Name = "__AboutLabel";
        this.@__AboutLabel.Size = new System.Drawing.Size(61, 18);
        this.@__AboutLabel.TabIndex = 0;
        this.@__AboutLabel.Text = "Cleanup";
        this.@__AboutLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.@__AboutLabel_MouseDown);
        // 
        // __EntryList
        // 
        this.@__EntryList.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.@__EntryList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.@__EntryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.@__EntryList.ColumnWidth = 200;
        this.@__EntryList.ForeColor = System.Drawing.Color.White;
        this.@__EntryList.Location = new System.Drawing.Point(3, 43);
        this.@__EntryList.MultiColumn = true;
        this.@__EntryList.Name = "__EntryList";
        this.@__EntryList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        this.@__EntryList.Size = new System.Drawing.Size(477, 275);
        this.@__EntryList.Sorted = true;
        this.@__EntryList.TabIndex = 5;
        // 
        // __BorderEnforcer
        // 
        this.@__BorderEnforcer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.@__BorderEnforcer.Controls.Add(this.@__EntryList);
        this.@__BorderEnforcer.Controls.Add(this.@__AboutHeader);
        this.@__BorderEnforcer.Controls.Add(this.@__DeleteButton);
        this.@__BorderEnforcer.Controls.Add(this.@__DeleteAllButton);
        this.@__BorderEnforcer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.@__BorderEnforcer.Location = new System.Drawing.Point(3, 3);
        this.@__BorderEnforcer.Margin = new System.Windows.Forms.Padding(6);
        this.@__BorderEnforcer.Name = "__BorderEnforcer";
        this.@__BorderEnforcer.Size = new System.Drawing.Size(582, 323);
        this.@__BorderEnforcer.TabIndex = 0;
        // 
        // __HelpInfo
        // 
        this.@__HelpInfo.AutoPopDelay = 0;
        this.@__HelpInfo.InitialDelay = 50;
        this.@__HelpInfo.ReshowDelay = 200;
        // 
        // CleanupForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
        this.CancelButton = this.@__CancelButton;
        this.ClientSize = new System.Drawing.Size(588, 329);
        this.ControlBox = false;
        this.Controls.Add(this.@__BorderEnforcer);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(15, 15);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CleanupForm";
        this.Padding = new System.Windows.Forms.Padding(3);
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CleanupForm_KeyDown);
        this.@__AboutHeader.ResumeLayout(false);
        this.@__BorderEnforcer.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.ToolTip __HelpInfo;

    private System.Windows.Forms.Button __HelpHoverButton;

    private System.Windows.Forms.Button __DeleteAllButton;
    private System.Windows.Forms.Button __DeleteButton;
    private System.Windows.Forms.Panel __AboutHeader;
    private System.Windows.Forms.Label __AboutLabel;
    private System.Windows.Forms.Button __CancelButton;
    private System.Windows.Forms.ListBox __EntryList;
    private System.Windows.Forms.Panel __BorderEnforcer;

    #endregion
}