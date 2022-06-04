namespace Dawn.Apps.StartupManager.Extensions;

using System;
using System.Collections.Generic;

internal static class EnumEx
{
    internal static IReadOnlyCollection<string> GetNames<T>() where T: Enum => Enum.GetNames(typeof(T));
    
    internal static T Parse<T>(string value) where T: Enum => (T)Enum.Parse(typeof(T), value);
}