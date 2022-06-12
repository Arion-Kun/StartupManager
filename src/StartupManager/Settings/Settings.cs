namespace Dawn.Apps.StartupManager;

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dawn.Apps.StartupManager.Annotations;
using Extensions;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using Task = Microsoft.Win32.TaskScheduler.Task;

internal static class Settings
{
    internal static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    internal static readonly RegistryKey ApplicationRegistryKey = Registry.CurrentUser.GetCreateSubKey(@"SOFTWARE\Dawn\StartupManager");
    private const string TaskSchedulerName = "StartupManager";

    public static bool StartWithWindows
    {
        get => TaskService.Instance.GetTask(TaskSchedulerName) != null;
        set
        {
            // If the user has the app elevated on their own accord as a setting then the task that is scheduled should be an elevated one too.
            // If the user has not elevated the app then the task should not be elevated.
            // An exception is likely if the user tries to remove 'Start with Windows' when unelevated when trying to remove the elevated task.
            var isAdmin = ApplicationEx.HasRelevantPermission();
            if (value)
                CreateStartupTask(isAdmin);
            else
                RemoveStartupTask(isAdmin);
        }
    }

    private static void CreateStartupTask(bool isAdmin)
    {
        System.Threading.Tasks.Task.Run(() =>
        {
            using var ts = TaskService.Instance;
            var td = ts.NewTask();
            
            // StartupManager is registered to Start with Windows just as it currently is, if the current access level of the program is administrator it registers it as administrator
            // if the current access level of the program is not administrator it registers it as user
            // isAdmin is a bool that the user authorizes, this is two bools, 1) the user agrees, 2) the process is elevated.
            //###
            if (isAdmin)
            {
                td.Principal.RunLevel = TaskRunLevel.Highest;
                td.Triggers.Add(new LogonTrigger()); // The logon trigger is applied to all users of the machine, this might become an option if people request it.
            }
            else
                td.Triggers.Add(new LogonTrigger().AsCurrentUser()); // The logon trigger is applied to the current user only.
            //###


            // Start even when on Battery Power
            td.Settings.DisallowStartIfOnBatteries = false;
            td.Settings.StopIfGoingOnBatteries = false;
            
            td.Actions.Add(
                new ExecAction($"{Process.GetCurrentProcess().ProcessName}.exe","/Background", $"{CurrentDirectory}"));

            var registrationInfo = td.RegistrationInfo;
            registrationInfo.Author = "Github.com/Arion-Kun";
            registrationInfo.Description =
                $"A logon task that allows StartupManager in {CurrentDirectory} to start when the user logs in. " +
                $"To disable this run the StartupManager program and click the tray icon, select 'Settings' -> 'Run on Startup'";

            ts.RootFolder.RegisterAsCurrentUser(TaskSchedulerName, td);

        });
    }
    private static void RemoveStartupTask(bool isAdmin)
    {
        System.Threading.Tasks.Task.Run(() =>
        {
            var taskFolder = TaskService.Instance.RootFolder;
            var startupTask = taskFolder.Tasks.FirstOrDefault(t => t.Name == TaskSchedulerName);
            if (startupTask != null)
                DeleteTask(isAdmin, startupTask);
            else
            {
                var managerFolder = taskFolder.SubFolders.FirstOrDefault(m =>
                    m.Tasks.FirstOrDefault(s => s.Name == TaskSchedulerName) != null);
                if (managerFolder != null)
                    DeleteTask(isAdmin, managerFolder.Tasks.First(ft => ft.Name == TaskSchedulerName));
            }
        });
    }

    
    private static void DeleteTask(bool isAdmin, [NotNull] Task task)
    {
        try { RemovePriorVersionStartup(); } catch (Exception e) { Trace.TraceError(e.ToString()); }
        
        // Check if the Task is elevated
        if (task.Definition.Principal.RunLevel == TaskRunLevel.Highest)
        {
            // If the user has the app elevated on their own accord as a setting then the task that is scheduled should be an elevated one too.
            // If the user has not elevated the app then the task should not be elevated.
            // An exception is likely if the user tries to remove 'Start with Windows' when unelevated when trying to remove the elevated task.
            if (isAdmin)
                task.Folder.DeleteTask(task.Name);
            else
                TryElevateDeleteTask(task.Name);
        }
        else
            task.Folder.DeleteTask(task.Name);
    }

    private static void TryElevateDeleteTask([NotNull] string taskName)
    {
        if (taskName == null) throw new ArgumentNullException(nameof(taskName));
        if (!File.Exists(Path.Combine(CurrentDirectory, "Elevator.exe")))
            return;
        try
        {
            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = CurrentDirectory,
                    FileName = "Elevator.exe",
                    Verb = "runas",
                    Arguments = $"/DeleteTask {taskName}",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
        }
        catch (Exception e)
        {
            Trace.TraceError(e.ToString());
        }
    }


    private static bool _Removed;
    private static void RemovePriorVersionStartup()
    {
        if (_Removed)
            return;
        _Removed = true;
        var procName = Process.GetCurrentProcess().ProcessName;
        var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
        
        if (reg == null || !reg.GetValueNames().Contains(procName)) return;
        reg.DeleteValue(procName);
        Start.ApplicationRefreshCallbacks();
    }

    // internal static bool StartWithWindows
    // {
    //     get
    //     {
    //         
    //         var procName = Process.GetCurrentProcess().ProcessName;
    //         var regVal = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", false)?.GetValue(procName);
    //         if (regVal == null) return false;
    //         return regVal.ToString() == $"\"{CurrentDirectory}{procName}.exe\" /Background";
    //     }
    //     set
    //     {
    //         var procName = Process.GetCurrentProcess().ProcessName;
    //         var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
    //         if (value)
    //         {
    //             reg!.SetValue(procName, $"\"{CurrentDirectory}{procName}.exe\" /Background");
    //             RegistryEx.StartupApproved.SetValue(procName, RegistryEx.StartupApprovedEnabled0);
    //         }
    //         else reg!.DeleteValue(procName);
    //     }
    // }


}