// The reason for the project is to alleviate unnecessary process restarts which cause a UI refresh.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32.TaskScheduler;
using Dawn.Apps.StartupManager.Extensions;


Trace.Listeners.Add(new ConsoleTraceListener());
Trace.Listeners.Add(new TextWriterTraceListener("StartupManager.log", "Elevator"));
Trace.AutoFlush = true;
AppDomain.CurrentDomain.UnhandledException += (_, e) => Trace.WriteLine((e.ExceptionObject as Exception)?.ToString());

if (!args.Contains("/DeleteTask"))
{
    Trace.TraceError("Incorrect arguments. Use /DeleteTask <task names>");
    Environment.Exit(-1);
}

if (ApplicationEx.IsElevated)
{
    Trace.WriteLine("Elevated");
    // 1 = Path
    // 2 = /DeleteTask
    // 3... = Task names
    var taskNames = args.Skip(2).ToList();
    
    var ts = TaskService.Instance;
    RecursiveDelete(ts.RootFolder, taskNames);
}
else
{
    Trace.TraceError("Failed to Elevate Task, the program was not run as Administrator");
    Environment.Exit(-1);
}


void RecursiveDelete(TaskFolder folder, ICollection<string> taskNames)
{
    foreach (var task in folder.Tasks)
    {
        try
        {
            if (taskNames.Count == 0) return;
            if (!taskNames.Contains(task.Name)) continue;
            folder.DeleteTask(task.Name);
            taskNames.Remove(task.Name);
        }
        catch (Exception ex) { Console.Error.WriteLine(ex.Message); }
    }
    foreach (var subFolder in folder.SubFolders) 
        RecursiveDelete(subFolder, taskNames);
}