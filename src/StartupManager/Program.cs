namespace StartupManager;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using Utilities;

internal static class Program
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
        // This initializes the instance, otherwise it would only be initialized once used.
        _ = Task.Run(() => GithubUpdateOperation.Instance);
        Application.Run();
        
    }
}