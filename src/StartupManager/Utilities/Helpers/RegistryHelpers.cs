namespace StartupManager.Helpers;

using System;
using Microsoft.Win32;

// https://stackoverflow.com/a/13190185
public static class RegistryHelpers
{
    public static RegistryKey GetRegistryKey(string keyPath, bool writable )
    {
        var localMachineRegistry
            = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                Environment.Is64BitOperatingSystem
                    ? RegistryView.Registry64
                    : RegistryView.Registry32);

        return string.IsNullOrEmpty(keyPath)
            ? localMachineRegistry
            : localMachineRegistry.OpenSubKey(keyPath, writable);
    }

    public static object GetRegistryValue(string keyPath, string keyName, bool writable)
    {
        var registry = GetRegistryKey(keyPath, writable);
        return registry.GetValue(keyName);
    }
}