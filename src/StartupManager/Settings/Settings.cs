namespace StartupManager;

using System;
using System.Diagnostics;
using Extensions;
using Microsoft.Win32;

internal static class Settings
{
    internal static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    internal static readonly RegistryKey ApplicationRegistryKey = Registry.CurrentUser.GetCreateSubKey(@"SOFTWARE\Dawn\StartupManager");
    
    internal static bool StartWithWindows
    {
        get
        {
            var procName = Process.GetCurrentProcess().ProcessName;
            var regVal = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", false)?.GetValue(procName);
            if (regVal == null) return false;
            return regVal.ToString() == $"\"{CurrentDirectory}{procName}.exe\" /Background";
        }
        set
        {
            var procName = Process.GetCurrentProcess().ProcessName;
            var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (value)
            {
                reg!.SetValue(procName, $"\"{CurrentDirectory}{procName}.exe\" /Background");
                RegistryExtensions.StartupApproved.SetValue(procName, RegistryExtensions.StartupApprovedEnabled0);
            }
            else reg!.DeleteValue(procName);
        }
    }


}