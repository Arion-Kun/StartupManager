namespace Dawn.Apps.StartupManager.Extensions;

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

internal static class PathEx
{
    internal static string GetDirectoryName(string path) => Path.GetDirectoryName(path.Replace("\"", string.Empty));

    private static readonly Regex ExtensionStrippingRegex = new(@"(\..*?) ", RegexOptions.Compiled);

    internal static string StripPathArguments(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            // throw new ArgumentNullException(nameof(path));
            return null;
        if (File.Exists(path))
            return path;
        var sanitizedString = path.Replace("\"", string.Empty);
        if (File.Exists(sanitizedString))
            return sanitizedString;


        var pathWithoutExtension = Path.Combine(GetDirectoryName(sanitizedString)!,
            Path.GetFileNameWithoutExtension(sanitizedString));

        var
            fileExtension // Here we Separate the Path from the extension C:\...\file.extension and we remove the part from "C:\...\file" to only keep ".extension"
                = ExtensionStrippingRegex.Match(sanitizedString.Substring(pathWithoutExtension.Length,
                    sanitizedString.Length - pathWithoutExtension.Length)).Groups[1].Value;
        var retVal = pathWithoutExtension + fileExtension;

        if (File.Exists(retVal)) return retVal;
        
        var legacyStrip = LegacyStripArguments(sanitizedString);
        if (File.Exists(legacyStrip)) 
            return legacyStrip;
        Trace.TraceError($"Could not find file: {path}");
        return retVal;
    }


    private static readonly Regex VaguePathRegex = new("\"(.+)\"|(.*?\\..*?) ");

    internal static string LegacyStripArguments(string path)
    {
        var regexMatch = VaguePathRegex.Match(path);
        var match = regexMatch.Groups.Cast<Group>().FirstOrDefault(regexMatchGroup => regexMatchGroup is not Match && !string.IsNullOrWhiteSpace(regexMatchGroup.Value));
        return match?.Value;
    }
    
    internal static Icon GetIcon(object valuePath)
    {
        if (valuePath == null) return null;
        var path = StripPathArguments(valuePath.ToString());
        
        return !File.Exists(path) 
            ? null 
            : Icon.ExtractAssociatedIcon(path);
    }
}