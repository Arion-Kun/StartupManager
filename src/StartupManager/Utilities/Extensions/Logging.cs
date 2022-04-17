namespace StartupManager.Extensions;

using System;
using System.Diagnostics;

internal static class Logging
{
    internal static void Enable()
    {
        Trace.Listeners.Add(new TextWriterTraceListener("StartupManager.log"));
        Trace.AutoFlush = true;
        AppDomain.CurrentDomain.UnhandledException += (_, e) => Trace.WriteLine((e.ExceptionObject as Exception)?.ToString());
    }
}