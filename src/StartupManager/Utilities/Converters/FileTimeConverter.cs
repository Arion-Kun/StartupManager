namespace StartupManager.Converters;

using System;

internal static class FileTimeConverter
{
    internal static DateTime RegistryFileTimeToDateTime(byte[] registryValue)
    {
        if (registryValue.Length != 12)
            throw new ArgumentException("A raw registry value is 12 bytes long, the argument does not match this requirement.");
        
        // We offset the value by 4 since the first 4 bytes are the registry state.
        var fileTimeLong = BitConverter.ToInt64(registryValue, 4);
        try
        {
            return DateTime.FromFileTime(fileTimeLong);
        }
        catch
        {
            return DateTime.MinValue;
        }
    }
    internal static byte[] DateTimeToRegistryFileTime(DateTime dateTime)
    {
        var fileTimeLong = dateTime.ToFileTime();
        var fileTimeBytes = BitConverter.GetBytes(fileTimeLong);
        return fileTimeBytes;
    }
    internal static byte[] DateTimeToRegistryFileTime(long fileTimeLong)
    {
        var fileTimeBytes = BitConverter.GetBytes(fileTimeLong);
        return fileTimeBytes;
    }
}