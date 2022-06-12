namespace Dawn.Apps.StartupManager;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using DialogBoxes;
using Extensions;
using Pages;
using Resources;
using Utilities;
using Timer = System.Timers.Timer;

public sealed partial class Start : Form
{
    public static Start Instance { get; private set; }
    public Start()
    {
        try
        {
            Instance = this;
            InitializeComponent();
            SetUACBoxState(Properties.Settings.Default.PromptUAC);
            AppDomain.CurrentDomain.ProcessExit += delegate { if (_TrayIcon != null) _TrayIcon.Visible = false; };
            //If the user closes the application from the tray or the form, the application will close
            FormClosing += (_, _) => {
                //Graceful Tray Icon Exit
                _TrayIcon.Visible = false;
                Environment.Exit(0);
            };
            var _startupForm = new StartupForm();
            _startupForm.TopLevel = false;
            formContainer.Controls.Add(_startupForm);
            _subforms.Add(_startupForm);

            Theme.Initialize(this);
            _startupForm.Show();
            Resize += delegate
            {
                foreach (var subform in _subforms)
                    subform.Size = Size;
            };

        
        
            var x = new Timer(TimeSpan.FromMinutes(60).TotalMilliseconds);
            x.Elapsed += (_, _) => Task.Run(PerformCleanupCheck);
            Task.Run(PerformCleanupCheck);
            TCM_btn_RunOnStartup.Image = Settings.StartWithWindows
                ? Properties.Resources.icons8_checked_checkbox
                : Properties.Resources.icons8_unchecked_checkbox;

            if (ApplicationEx.IsElevated)
                Text = "Startup Manager - Administrator";
        }
        finally
        {
            Visible = !Environment.GetCommandLineArgs().Contains("/Background");
        }
    }

    private async Task PerformCleanupCheck()
    {
        var entries = await CleanupForm.EntriesCount();
        var cleanupMenuItem = PageStrip.Items.OfType<ToolStripMenuItem>().First(a => a.Name == "Cleanup");

        await TaskAwaiter.EnsureRunningOnMainThread();
        if (entries == 0)
        {
            cleanupMenuItem.Enabled = false;
            cleanupMenuItem.Image = Properties.Resources.recycle_empty;
        }
        else
        {
            cleanupMenuItem.Enabled = true;
            cleanupMenuItem.Image = Properties.Resources.recycle_full;
        }
    }

    private readonly HashSet<Form> _subforms = new();

    private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (Visible)
            Hide();
        else
        {
            Show();
            WindowState = FormWindowState.Normal;
            Task.Run(PerformCleanupCheck);
        }
    }

    // ReSharper disable once ConvertToAutoPropertyWhenPossible
    public NotifyIcon TrayIcon => _TrayIcon;

    private void TCM_btn_Exit_Click(object sender, EventArgs e)
    {
        Visible = false;
        _TrayIcon.Visible = false;
        Environment.Exit(0);
    }

    private void StartupFolder_Click(object sender, EventArgs e)
    {
        ConfirmDialogBox.ShowDialog("Startup Folder", "Choose a startup folder to open", 
            ("User Startup", ()=> Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup))), 
            ("System Startup", ()=> Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup))));
    }

    private void SetUACBoxState(bool state)
    {
        if (state)
        {
            UACBox.Checked = true;
            UACBox.Text = Strings.INCLUDE_LOCALMACHINE;
        }
        else
        {
            UACBox.Checked = false;
            UACBox.Text = Strings.NOT_INCLUDE_LOCALMACHINE;
        }
    }
    private void UACBox_Click(object sender, EventArgs e)
    {
        if (UACBox.Checked)
        {
            UACBox.Checked = false;
            UACBox.Text = Strings.NOT_INCLUDE_LOCALMACHINE;
            Properties.Settings.Default.PromptUAC = false;
            Properties.Settings.Default.Save();
            ApplicationRefreshCallbacks();
        }
        else
        {
            UACBox.Checked = true;
            UACBox.Text = Strings.INCLUDE_LOCALMACHINE;
            Properties.Settings.Default.PromptUAC = true;
            Properties.Settings.Default.Save();
            if (!ApplicationEx.HasRelevantPermission())
                ApplicationEx.TryRunAsAdministrator();
            else ApplicationRefreshCallbacks();
        }
    }

    internal static Action ApplicationRefreshCallbacks;

    private void TCM_btn_RunOnStartup_Click(object sender, EventArgs e)
    {
        // if (TCM_btn_RunOnStartup.Checked)
        if (StartupState)
        {
            // TCM_btn_RunOnStartup.Checked = false;
            SetStartupCheck(false);
            Settings.StartWithWindows = false;
        }
        else
        {
            // TCM_btn_RunOnStartup.Checked = true;
            SetStartupCheck(true);
            Settings.StartWithWindows = true;
        }
    }

    private static bool _StartupState;
    private bool StartupState
    {
        get
        {
            _StartupState = !_StartupState;
            return _StartupState;
        }
    }
    internal void SetStartupCheck(bool @checked) => TCM_btn_RunOnStartup.Image = @checked ? Properties.Resources.icons8_checked_checkbox : Properties.Resources.icons8_unchecked_checkbox;

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var aboutMenu = new AboutForm();
        aboutMenu.ShowDialog();
    }

    private void Start_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            Hide();
            Task.Run(PerformCleanupCheck);
        }
    }

    private void Cleanup_Click(object sender, EventArgs e)
    {
        var cleanupForm = new CleanupForm();
        cleanupForm.ShowDialog();
        cleanupForm.Dispose();
        Task.Run(PerformCleanupCheck);
    }
}