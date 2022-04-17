namespace StartupManager.Utilities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.Win32;

public class CleanupEntry
{
    private CleanupEntry() {}

    internal static bool Create(RegistryKey key, string entryName, out CleanupEntry entry)
    {
        entry = null;
        if (key == null || string.IsNullOrEmpty(entryName))
            return false;

        if (!key.GetValueNames().Contains(entryName))
            return false;

        entry = new CleanupEntry
        {
            RegistryObject = new(entryName, key)
        };
        return true;
    }
    
    private KeyValuePair<string, RegistryKey> RegistryObject;
    public override string ToString() => RegistryObject.Key;

    internal bool Remove()
    {
        try
        {
            RegistryObject.Value.DeleteValue(RegistryObject.Key);
            return true;
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.ToJson(), "Remove Errors");
            return false;
        }
    }
}