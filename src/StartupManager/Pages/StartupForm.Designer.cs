namespace StartupManager.Pages;

using System.ComponentModel;

partial class StartupForm
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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        this.StartupKeys = new System.Windows.Forms.DataGridView();
        this.DataKey_Icon = new System.Windows.Forms.DataGridViewImageColumn();
        this.DataKey_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.DataKey_Path = new System.Windows.Forms.DataGridViewLinkColumn();
        this.DataKey_Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.DataKey_DisabledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.DataKey_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
        this.FormMainPanel = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.StartupKeys)).BeginInit();
        this.FormMainPanel.SuspendLayout();
        this.SuspendLayout();
        // 
        // StartupKeys
        // 
        this.StartupKeys.AllowUserToAddRows = false;
        this.StartupKeys.AllowUserToDeleteRows = false;
        this.StartupKeys.AllowUserToOrderColumns = true;
        this.StartupKeys.AllowUserToResizeRows = false;
        this.StartupKeys.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.StartupKeys.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.StartupKeys.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.StartupKeys.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        this.StartupKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.StartupKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.DataKey_Icon, this.DataKey_Name, this.DataKey_Path, this.DataKey_Enabled, this.DataKey_DisabledDate, this.DataKey_Delete });
        dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ScrollBar;
        dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
        dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.StartupKeys.DefaultCellStyle = dataGridViewCellStyle5;
        this.StartupKeys.Dock = System.Windows.Forms.DockStyle.Fill;
        this.StartupKeys.Location = new System.Drawing.Point(0, 0);
        this.StartupKeys.Name = "StartupKeys";
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
        dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.StartupKeys.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
        this.StartupKeys.RowHeadersVisible = false;
        this.StartupKeys.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.StartupKeys.Size = new System.Drawing.Size(820, 400);
        this.StartupKeys.TabIndex = 0;
        // 
        // DataKey_Icon
        // 
        this.DataKey_Icon.Frozen = true;
        this.DataKey_Icon.HeaderText = "Icon";
        this.DataKey_Icon.Image = ((System.Drawing.Image)(resources.GetObject("DataKey_Icon.Image")));
        this.DataKey_Icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
        this.DataKey_Icon.MinimumWidth = 35;
        this.DataKey_Icon.Name = "DataKey_Icon";
        this.DataKey_Icon.Width = 35;
        // 
        // DataKey_Name
        // 
        this.DataKey_Name.HeaderText = "Name";
        this.DataKey_Name.Name = "DataKey_Name";
        this.DataKey_Name.Width = 250;
        // 
        // DataKey_Path
        // 
        this.DataKey_Path.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(126)))), ((int)(((byte)(151)))));
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
        this.DataKey_Path.DefaultCellStyle = dataGridViewCellStyle1;
        this.DataKey_Path.HeaderText = "Path";
        this.DataKey_Path.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(126)))), ((int)(((byte)(151)))));
        this.DataKey_Path.MinimumWidth = 300;
        this.DataKey_Path.Name = "DataKey_Path";
        this.DataKey_Path.Width = 300;
        // 
        // DataKey_Enabled
        // 
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        dataGridViewCellStyle2.NullValue = false;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
        this.DataKey_Enabled.DefaultCellStyle = dataGridViewCellStyle2;
        this.DataKey_Enabled.HeaderText = "Enabled";
        this.DataKey_Enabled.MinimumWidth = 50;
        this.DataKey_Enabled.Name = "DataKey_Enabled";
        this.DataKey_Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.DataKey_Enabled.Width = 50;
        // 
        // DataKey_DisabledDate
        // 
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(139)))), ((int)(((byte)(184)))));
        this.DataKey_DisabledDate.DefaultCellStyle = dataGridViewCellStyle3;
        this.DataKey_DisabledDate.HeaderText = "Disabled Date";
        this.DataKey_DisabledDate.MinimumWidth = 100;
        this.DataKey_DisabledDate.Name = "DataKey_DisabledDate";
        this.DataKey_DisabledDate.ReadOnly = true;
        // 
        // DataKey_Delete
        // 
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkOrange;
        dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
        this.DataKey_Delete.DefaultCellStyle = dataGridViewCellStyle4;
        this.DataKey_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        this.DataKey_Delete.HeaderText = "";
        this.DataKey_Delete.MinimumWidth = 62;
        this.DataKey_Delete.Name = "DataKey_Delete";
        this.DataKey_Delete.Width = 62;
        // 
        // FormMainPanel
        // 
        this.FormMainPanel.Controls.Add(this.StartupKeys);
        this.FormMainPanel.Location = new System.Drawing.Point(0, 0);
        this.FormMainPanel.Name = "FormMainPanel";
        this.FormMainPanel.Size = new System.Drawing.Size(820, 400);
        this.FormMainPanel.TabIndex = 2;
        // 
        // StartupForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(821, 423);
        this.ControlBox = false;
        this.Controls.Add(this.FormMainPanel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "StartupForm";
        this.Text = "StartupForm";
        ((System.ComponentModel.ISupportInitialize)(this.StartupKeys)).EndInit();
        this.FormMainPanel.ResumeLayout(false);
        this.ResumeLayout(false);
    }
    
    private System.Windows.Forms.Panel FormMainPanel;

    private System.Windows.Forms.DataGridViewTextBoxColumn DataKey_DisabledDate;

    private System.Windows.Forms.DataGridViewLinkColumn DataKey_Path;

    private System.Windows.Forms.DataGridViewTextBoxColumn DataKey_Name;

    private System.Windows.Forms.DataGridViewCheckBoxColumn DataKey_Enabled;
    private System.Windows.Forms.DataGridViewButtonColumn DataKey_Delete;
    private System.Windows.Forms.DataGridViewImageColumn DataKey_Icon;

    public System.Windows.Forms.DataGridView StartupKeys;
    

    #endregion
}