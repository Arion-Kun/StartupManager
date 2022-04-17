namespace StartupManager;

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Extensions;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        if (Properties.Settings.Default.EnableLogging)
            Logging.Enable();
        if (Properties.Settings.Default.PromptUAC && !ApplicationExtensions.IsElevated)
            if (!ApplicationExtensions.TryRunAsAdministrator()) return;
        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        _ = new Start();
        Application.Run();
        
    }
}