namespace Dawn.Apps.StartupManager.Extensions;

using System.Security.Principal;
using Microsoft.Win32.TaskScheduler;

internal static class TaskSchedulerEx
{
    internal static LogonTrigger AsCurrentUser(this LogonTrigger trigger)
    {
        trigger.UserId = WindowsIdentity.GetCurrent().Name;
        return trigger;
    }

    internal static Task RegisterAsCurrentUser(this TaskFolder folder, string path, TaskDefinition definition, TaskCreation creationType = TaskCreation.CreateOrUpdate) 
        => folder.RegisterTaskDefinition(path, definition, creationType, WindowsIdentity.GetCurrent().Name, TaskService.Instance.UserPassword, TaskLogonType.InteractiveToken);
}