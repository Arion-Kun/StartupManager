using System.Windows.Forms;

namespace Dawn.Apps.StartupManager.Pages;

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Native;
using Properties;
using Utilities;

public partial class AboutForm : Form
{
    private GithubUpdateOperation _UpdateOperation => GithubUpdateOperation.Instance;

    public AboutForm()
    {
        InitializeComponent();
        KeyPreview = true;
        __VersionLabel.Text = $"Version: {Application.ProductVersion}";

        var descriptionAttribute = GetType().Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
            .OfType<AssemblyDescriptionAttribute>().FirstOrDefault();

        if (descriptionAttribute != null) 
            __DescriptionBox.Text = descriptionAttribute.Description + ADDITIONAL_DESCRIPTION;
         
        SyncUpdateResponse();
    }
    // CRLF standard
    private const string ADDITIONAL_DESCRIPTION =
        "\r\n\r\nThe Startup Folder contents are not included in the list as they're for the user themselves.";
    
    private async void SyncUpdateResponse()
    {
        var updateNeeded = await _UpdateOperation.IsUpdateAvailable();
        var currentBuildDate = await _UpdateOperation.GetBuildDateToShortDateString(GithubUpdateOperation.Versioning.Current);
        var latestBuildDate = await _UpdateOperation.GetBuildDateToShortDateString(GithubUpdateOperation.Versioning.Latest);

        await TaskAwaiter.Yield; // The rest is done in the UI thread
        if (!string.IsNullOrWhiteSpace(currentBuildDate))
        {
            __CurrentBuildDate.Text = $"Build Date: {currentBuildDate}";
            __CurrentBuildDate.Visible = true;
        }
        if (!updateNeeded) return;
        __UpdateButton.Visible = true;
        __LatestBuildLabel.Text = $"Latest Build: {latestBuildDate}";
        __LatestBuildLabel.Visible = true;
    }


    
    
    private void AboutForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Escape) return;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void __UpdateButton_Click(object sender, EventArgs e) => Task.Run(_UpdateOperation.OpenDownloadLinkURL);

    private void __ProjectLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
        Process.Start(Settings.Default.Github);
    
    private void Drag()
    {
        NativeMethods.ReleaseCapture();
        NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION,  0);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == NativeMethods.WM_NCHITTEST)
            m.Result = (IntPtr)NativeMethods.HT_CAPTION;
    }

    private void __AboutLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        Drag();
    }

    private void __AboutHeader_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        Drag();
    }
}