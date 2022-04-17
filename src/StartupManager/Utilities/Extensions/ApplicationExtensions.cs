namespace StartupManager.Extensions;

using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

internal static class ApplicationExtensions
{
    internal static bool IsElevated
    {
        get
        {
            var identity = WindowsIdentity.GetCurrent();
            return identity.Owner != identity.User;
        }
    }

    internal static bool HasRelevantPermission() => IsElevated && Properties.Settings.Default.PromptUAC;

    internal static bool TryRunAsAdministrator()
    {
        //False = don't continue running this instance of the application (Elevated access is requested and suceeded)
        //True = continue running this instance of the application (Elevated access is requested and failed)
        //This is in the case where the user has declined the elevation request but has accepted in the past, which might cause a restart loop.
        // We return true and reset the setting that the user wants to run the program with elevated access.
        #if !DEBUG
        var startInfo = new ProcessStartInfo
        {
            UseShellExecute = true,
            WorkingDirectory = Environment.CurrentDirectory,
            FileName = Application.ExecutablePath,
            Verb = "runas",
            Arguments = "/Show"
        };
        try
        {
            var p = Process.Start(startInfo);
            if (p != null)
            {
                Application.Exit();
                return false;
            }

            Properties.Settings.Default.PromptUAC = false;
            Properties.Settings.Default.Save();
            return true;
        }
        catch (System.ComponentModel.Win32Exception)
        {
            MessageBox.Show("This utility requires elevated priviledges to complete correctly.", "Error: UAC Authorization Required", MessageBoxButtons.OK);
            Properties.Settings.Default.PromptUAC = false;
            Properties.Settings.Default.Save();
            return true;
        }
        #else
        return true;
        #endif
    }
}