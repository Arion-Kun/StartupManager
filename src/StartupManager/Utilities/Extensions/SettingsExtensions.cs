namespace StartupManager.Extensions;

using System;
using Microsoft.Win32;
using Newtonsoft.Json;

internal static class SettingsExtensions
{
    internal static T GetValue<T>(this RegistryKey key, string name, T defaultValue)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        var value = key.GetValue(name);
        if (value is not null) return (T)Convert.ChangeType(value, typeof(T));
        key.SetValue(name, defaultValue);
        return defaultValue;
    }
    internal static RegistryKey GetCreateSubKey(this RegistryKey key, string name) => key.OpenSubKey(name, true) ?? key.CreateSubKey(name);
    internal static string ToJson(this object obj, Formatting format = Formatting.Indented) => JsonConvert.SerializeObject(obj, format);
}