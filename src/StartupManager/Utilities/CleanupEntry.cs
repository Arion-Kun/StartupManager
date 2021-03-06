namespace Dawn.Apps.StartupManager.Utilities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.Win32;

public class CleanupEntry
{
    private CleanupEntry() {}

    internal static bool Create(RegistryKey key, string entryName, ObjectIrregularityType type, out CleanupEntry entry)
    {
        entry = null;
        if (key == null || string.IsNullOrEmpty(entryName))
            return false;

        if (!key.GetValueNames().Contains(entryName))
            return false;

        entry = new CleanupEntry
        {
            RegistryObject = new(entryName, key),
            IrregularityType = type
        };
        return true;
    }
    
    private KeyValuePair<string, RegistryKey> RegistryObject;
    internal ObjectIrregularityType IrregularityType { get; private set; }

    internal enum ObjectIrregularityType
    {
        Type,
        Relationship,
        Abandonment,
        Null
    }
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
            Trace.TraceError(e.ToJson(), "Remove Errors");
            return false;
        }
    }
}