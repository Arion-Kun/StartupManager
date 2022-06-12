namespace Dawn.Apps.StartupManager.Extensions;

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Converters;
using Helpers;
using Microsoft.Win32;

internal static class RegistryEx
{
    internal static RegistryKey StartupApproved { get; } = Registry.CurrentUser.GetCreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run");
    internal static RegistryKey Startup { get; } = Registry.CurrentUser.GetCreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
    
    // internal static RegistryKey StartupFolder => Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\StartupFolder", true);

    private static RegistryKey _StartupLM;

    internal static RegistryKey StartupLM => _StartupLM ??= 
        RegistryHelpers.GetRegistryKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

    private static RegistryKey _StartupLM64;

    internal static RegistryKey StartupLM64 => _StartupLM64 ??=
        RegistryHelpers.GetRegistryKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run", true);

    private static RegistryKey _StartupApprovedLM;
    internal static RegistryKey StartupApprovedLM => _StartupApprovedLM ??=
        RegistryHelpers.GetRegistryKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run", true);

    private static RegistryKey _StartupApprovedLM32;
    internal static RegistryKey StartupApprovedLM32 => _StartupApprovedLM32 ??=
        RegistryHelpers.GetRegistryKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run32",
            true);
    

    // The bool for a StartupKey being true is the first byte either being a 2 or a 6 in the first index, the trailing bytes could be a timestamp for when it was disabled.
    internal static readonly byte[] StartupApprovedEnabled0 = { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0 };
    internal static readonly byte[] StartupApprovedEnabled1 = { 6, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0 };

    internal static void DisableValue(string key)
    {
        // if (!StartupApproved.GetValueNames().Contains(key)) return false;

        var valueArray = new byte[12];
        var fileTimeInBytes = FileTimeConverter.DateTimeToRegistryFileTime(DateTime.Now);
        var disabledValue = new byte[] { 3, 0, 0, 0 };
        Array.Copy(fileTimeInBytes, 0, valueArray, 4, fileTimeInBytes.Length);
        Array.Copy(disabledValue, 0, valueArray, 0, disabledValue.Length);
        //                                         |-------->| is the marker for disabled
        // The end value would be something like { 3, 0, 0, 0, 11, 12, 13, 14, 15, 16, 17, 1 }
        //                                                     |-------------------------->| is the timestamp in bytes that we convert to a long.
        //                                                                                   DateTime converts the long ToFileTime via DateTime.ToFileTime(long longval)
        // We set the current time (DateTime.Now) as the timestamp for when the key was disabled.
        
        // if (StartupApproved.GetValueNames().Contains(key))
        // {
        //     StartupApproved.SetValue(key, valueArray);
        // } else

        if (StartupApproved.GetValueNames().Contains(key))
            StartupApproved.SetValue(key, valueArray);
        else if (ApplicationEx.HasRelevantPermission())
        {
            if (StartupApprovedLM32.GetValueNames().Contains(key))
                StartupApprovedLM32.SetValue(key, valueArray);
            else StartupApprovedLM.SetValue(key, valueArray);
        }
        

        // return true;
    }
    
    internal static DateTime GetDisabledDate(string key)
    {
        var valueArray = StartupApproved.GetValue(key) as byte[];
        if (valueArray == null && ApplicationEx.HasRelevantPermission())
        {
            valueArray = StartupApprovedLM.GetValue(key) as byte[]
                         ?? StartupApprovedLM32.GetValue(key) as byte[];
        }

        return valueArray == null ? DateTime.MinValue : FileTimeConverter.RegistryFileTimeToDateTime(valueArray);
    }

    internal static bool IsDisabled(string key)
    {
        if (StartupApproved.GetValueNames().Contains(key))
            return ((byte[])StartupApproved.GetValue(key))[0] == 3;

        if (!ApplicationEx.HasRelevantPermission()) return false;
        if (StartupApprovedLM.GetValueNames().Contains(key))
            return ((byte[])StartupApprovedLM.GetValue(key))[0] == 3;
        
        if (StartupApprovedLM32.GetValueNames().Contains(key))
            return ((byte[])StartupApprovedLM32.GetValue(key))[0] == 3;
        return false;
    }
    internal static bool TryGetStartupApproved(string key, out object value)
    {
        value = null;
        if (string.IsNullOrWhiteSpace(key)) return false;
        
        if (StartupApproved.GetValueNames().Contains(key))
            value = StartupApproved.GetValue(key);
        else if (ApplicationEx.HasRelevantPermission())
        {
            if (StartupApprovedLM.GetValueNames().Contains(key))
                value = StartupApprovedLM.GetValue(key);
            else if (StartupApprovedLM32.GetValueNames().Contains(key))
                value = StartupApprovedLM32.GetValue(key);
        }
        
        else return false;
        return value != null;
    }

    internal static void DeleteValue(string valueName)
    {
        if (Startup.GetValueNames().Contains(valueName))
            Startup.DeleteValue(valueName);
        if (StartupApproved.GetValueNames().Contains(valueName))
            StartupApproved.DeleteValue(valueName);

        if (!ApplicationEx.HasRelevantPermission()) return;
        if (StartupLM.GetValueNames().Contains(valueName))
            StartupLM.DeleteValue(valueName);
        if (StartupApprovedLM.GetValueNames().Contains(valueName))
            StartupApprovedLM.DeleteValue(valueName);
        if (StartupApprovedLM32.GetValueNames().Contains(valueName))
            StartupApprovedLM32.DeleteValue(valueName);
        
        if (StartupLM64.GetValueNames().Contains(valueName))
            StartupLM64.DeleteValue(valueName);

    }
}