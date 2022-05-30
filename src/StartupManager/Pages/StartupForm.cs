using System.Windows.Forms;

namespace StartupManager.Pages;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DialogBoxes;
using Extensions;
using Microsoft.Win32;
using Utilities;
using Control = Control;

public partial class StartupForm : Form
{
    public StartupForm()
    {
        InitializeComponent();
        // GetData();
        StartupKeys.Visible = false;
        GetDataAsync();
        // StartupKeys.CellValueChanged += StartupKeysOnCellValueChanged;
        
        StartupKeys.CellContentClick += CellContentClicked;
        StartupKeys.CellContentDoubleClick += CellContentClicked;
        
        // StartupKeys.CellValidated += StartupKeysOnCellValueChanged;
        OnButtonClick += OnDeleteButtonClicked;
        OnCheckboxClick += OnCellCheckboxClick;
        // StartupKeys.CellContentClick += StartupKeysOnCellContentClick;
        StartupKeys.DataError += StartupKeysOnDataError;

        // if (ApplicationExtensions.IsElevated)
        //     button1.Text = "Elevated";

        Start.ApplicationRefreshCallbacks += delegate
        {
            // GetData();
            GetDataAsync();
            // Task.Run(async () =>
            // {
            //     
            //     await MainThreadAwaiter.Yield;
            // });
            //
            // async void DoTask() => await GetDataAsync();
        };
        // var controls = GetControls(this.Controls);
    }

    private void GetControls(Control.ControlCollection ctrl)
    {
        foreach (Control o in ctrl)
        {
            if (o.GetType() == typeof(VScrollBar))
            {
                var sc = (VScrollBar)o;
                
            }
            else if (o.HasChildren) 
                GetControls(o.Controls);
        }
    }

    private void OnCellCheckboxClick(DataGridViewCheckBoxCell sender,  DataGridViewCellEventArgs e)
    {
        var row = StartupKeys.Rows[e.RowIndex];
        switch (e.ColumnIndex)
        {
            case 3: // Checkbox
                // var name = row.Cells[nameof(DataKey_Name)].Value.ToString();
                var name = row.Cells[nameof(DataKey_Name)].Value.ToString();
                var enabledState = (bool)row.Cells[nameof(DataKey_Enabled)].EditedFormattedValue;
                var startupApproved = RegistryExtensions.StartupApproved;
                var isPresentInStartupApproved = startupApproved.GetValueNames().Contains(name);
                if (isPresentInStartupApproved)
                {
                    var isDisabled = RegistryExtensions.IsDisabled(name);
                    if (!(enabledState ^ !isDisabled))
                        return; // If there's no change, do nothing.
                    if (enabledState)
                    {
                        startupApproved.SetValue(name, RegistryExtensions.StartupApprovedEnabled0);
                        row.Cells[nameof(DataKey_DisabledDate)].Value = "";
                    }
                    else
                    {
                        RegistryExtensions.DisableValue(name);
                        var disableTime = RegistryExtensions.GetDisabledDate(name);
                        row.Cells[nameof(DataKey_DisabledDate)].Value = disableTime == DateTime.MinValue ? string.Empty : disableTime.ToShortDateString();
                    }
                }
                else
                {
                    if (enabledState)
                    {
                        startupApproved.SetValue(name, RegistryExtensions.StartupApprovedEnabled0);
                        row.Cells[nameof(DataKey_DisabledDate)].Value = "";
                    }
                    else
                    {
                        RegistryExtensions.DisableValue(name);
                        var disableTime = RegistryExtensions.GetDisabledDate(name);
                        row.Cells[nameof(DataKey_DisabledDate)].Value = disableTime == DateTime.MinValue ? string.Empty : disableTime.ToShortDateString();
                    }
                }
                break;
        }
    }
    private void CellContentClicked(object sender,   DataGridViewCellEventArgs e)
    {
    
        if (e.ColumnIndex is -1 || e.RowIndex is -1 || sender is null) return; // Header Click
        //0 | Icon
        //1 | Name
        //2 | Path
        //3 | Enabled
        //4 | Disabled Date
        //5 | Delete
        var whitelistedColumns = new [] { 0, 2, 3, 5 };
        if (!whitelistedColumns.Contains(e.ColumnIndex)) return;
        // var row = StartupKeys.Rows[e.RowIndex];
        switch (e.ColumnIndex)
        {
            case 0: // Icon
                var path2 = StartupKeys.Rows[e.RowIndex].Cells[nameof(DataKey_Path)].Value.ToString();
                // Open to the directory of the path
                var dirPath = Path.GetDirectoryName(RegistryExtensions.RemoveArguments(path2));
                if (Directory.Exists(dirPath))
                    Process.Start(dirPath);
                break;
            case 2: // Path
                var path = StartupKeys.Rows[e.RowIndex].Cells[nameof(DataKey_Path)].Value.ToString();
                var pathDirectory = Path.GetDirectoryName(RegistryExtensions.RemoveArguments(path));
                
                if (string.IsNullOrWhiteSpace(pathDirectory)) return;
                var startInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    WorkingDirectory = pathDirectory,
                    FileName = "cmd.exe",
                    Arguments = "/C " + path,
                    CreateNoWindow = true,
                };
                Process.Start(startInfo);
                break;
            case 3:
                OnCheckboxClick(sender as DataGridViewCheckBoxCell, e);
                break;
            case 5:
                OnButtonClick((DataGridViewButtonCell)((DataGridView)sender).Rows[e.RowIndex].Cells[nameof(DataKey_Delete)], e);
                break;
        }
    }

    private void OnDeleteButtonClicked(DataGridViewButtonCell sender, DataGridViewCellEventArgs e)
    {
        var value = StartupKeys.Rows[e.RowIndex].Cells[nameof(DataKey_Name)].Value.ToString();
        var confirm = ConfirmDialogBox.ShowDialog($"'{value}' Deletion Prompt", "Are you sure you want to delete this value?");

        if (!confirm) return;
        if (value == Process.GetCurrentProcess().ProcessName)
        {
            Start.Instance.SetStartupCheck(false);
        }
        RegistryExtensions.DeleteValue(value);
        StartupKeys.Rows.RemoveAt(e.RowIndex);
    }
    

    private Action<DataGridViewButtonCell, DataGridViewCellEventArgs> OnButtonClick;
    private Action<DataGridViewCheckBoxCell,  DataGridViewCellEventArgs> OnCheckboxClick;

    private void StartupKeysOnDataError(object sender, DataGridViewDataErrorEventArgs e) => throw e.Exception;

    private readonly HashSet<IDisposable> _Disposables = new();

    private void RefreshDisposables()
    {
        StartupKeys.Rows.Clear();
        foreach (var disposable in _Disposables)
            disposable?.Dispose();
        _Disposables.Clear();
    }
    private void GetData()
    {
        // var dt = new DataTable();
        // dt.Columns.Add("Icon", typeof(DataGridViewImageCell));
        // dt.Columns.Add("Name", typeof(DataGridViewTextBoxCell));
        // dt.Columns.Add("Path", typeof(DataGridViewLinkCell));
        // dt.Columns.Add("Enabled", typeof(DataGridViewCheckBoxCell));
        // dt.Columns.Add("Delete", typeof(DataGridViewButtonCell));
        RefreshDisposables();
        

        foreach (var valueName in RegistryExtensions.Startup.GetValueNames())
            IterateRegistryValue(RegistryExtensions.Startup, valueName);
        if (!ApplicationExtensions.HasRelevantPermission()) return;
        {
            foreach (var valueName in RegistryExtensions.StartupLM64.GetValueNames())
                    IterateRegistryValue(RegistryExtensions.StartupLM64, valueName);
            foreach (var valueName in RegistryExtensions.StartupLM.GetValueNames())
                IterateRegistryValue(RegistryExtensions.StartupLM, valueName);
        }
    }

    /// <summary>
    /// This will throw an exception if trying to add when the UI thread is excessively getting refreshed.
    /// But that only occurred in testing when spamming refreshes.
    /// The row or icon is disposed during the adding of the row. Causing an exception.
    /// </summary>
    private async void GetDataAsync()
    {
        // await MainThreadAwaiter.Yield;
        RefreshDisposables();

        var row = new List<DataGridViewRow>();

        var tasks = RegistryExtensions.Startup.GetValueNames().Select(valueName 
            => Task.Run(async () 
                => row.Add(
                    await IterateRegistryValueAsync(RegistryExtensions.Startup, valueName)))).ToList();

        if (ApplicationExtensions.HasRelevantPermission())
        {
            tasks.AddRange(RegistryExtensions.StartupLM64.GetValueNames().Select(valueName 
                => Task.Run(async () 
                    => row.Add(
                        await IterateRegistryValueAsync(RegistryExtensions.StartupLM64, valueName)))));
            tasks.AddRange(RegistryExtensions.StartupLM.GetValueNames().Select(valueName 
                => Task.Run(async () 
                    => row.Add(
                        await IterateRegistryValueAsync(RegistryExtensions.StartupLM, valueName)))));
        }

        await Task.WhenAll(tasks);

        var retVal = row.Where(x => x != null).ToArray();
        await TaskAwaiter.Yield;
        StartupKeys.Rows.AddRange(retVal);
        Theme.DarkMode(this);
        StartupKeys.Visible = true;
    }

    private void IterateRegistryValue(RegistryKey key, string valueName)
    {
        var dgr = CreateIterationRow(key, valueName);
        StartupKeys.Rows.Add(dgr);
    }

    private DataGridViewRow CreateIterationRow(RegistryKey key, string valueName)
    {
        var dgr = new DataGridViewRow();
        var name = new DataGridViewTextBoxCell();
        name.ValueType = typeof(string);
        name.Value = valueName;
        var path = new DataGridViewLinkCell();
        path.ValueType = typeof(string);
        path.Value = key.GetValue(valueName);
        var enabled = new DataGridViewCheckBoxCell();
        if (RegistryExtensions.TryGetStartupApproved(valueName, out var approvedValue))
        {
            var val = approvedValue as byte[];
            var enabledValue = val![0];
            enabled.Value = enabledValue is 0x02 or 0x06;
        }
        else enabled.Value = false;


        // var midnightBlue = Color.FromArgb(27, 34, 46);
        // var slateGray = Color.FromArgb(95, 126, 151);

        var delete = new DataGridViewButtonCell();
        delete.FlatStyle = FlatStyle.Popup;
        // if (delete.Style.ForeColor == Color.White)
        //     delete.Style.ForeColor = slateGray;
        // delete.Style.BackColor = midnightBlue;
        delete.ValueType = typeof(string);
        delete.Value = "Delete";

        var image = new DataGridViewImageCell();
        var iconValue = RegistryExtensions.GetIcon(key.GetValue(valueName));
        if (iconValue != null)
        {
            var imageVal = new Bitmap(iconValue.ToBitmap(), 20, 20);
            iconValue.Dispose(); // The value is already cloned, so we dispose of the latter.
            image.ValueIsIcon = true;
            image.ValueType = typeof(Bitmap);
            image.Value = imageVal;
            image.ImageLayout = DataGridViewImageCellLayout.Normal;
            image.ToolTipText = valueName;

            _Disposables.Add(imageVal);
        }

        var disabledDate = new DataGridViewTextBoxCell();
        disabledDate.ValueType = typeof(string);
        if (enabled.Value is true)
            disabledDate.Value = string.Empty;
        else
        {
            var disabledDateValue = RegistryExtensions.GetDisabledDate(valueName);
            disabledDate.Value = disabledDateValue == default ? string.Empty : disabledDateValue.ToShortDateString();
            // This check here is to prevent the default value of DateTime from being shown if there is no StartupApproved value,
            // this would usually occur when an app is freshly installed and the PC has not yet restarted to set an approved value.
        }

        dgr.Cells.Add(image);
        dgr.Cells.Add(name);
        dgr.Cells.Add(path);
        dgr.Cells.Add(enabled);
        dgr.Cells.Add(disabledDate);
        dgr.Cells.Add(delete);
        return dgr;
    }

    private async Task<DataGridViewRow> IterateRegistryValueAsync(RegistryKey key, string valueName) =>
        await Task.Run(() => CreateIterationRow(key, valueName));

}