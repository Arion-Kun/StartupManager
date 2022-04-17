namespace StartupManager.Utilities;

using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal readonly struct TaskAwaiter : INotifyCompletion
{
    private static readonly SendOrPostCallback _postCallback = state => ((Action)state)();

    private readonly SynchronizationContext _context;
    internal TaskAwaiter(SynchronizationContext context) => _context = context;

    internal bool IsCompleted => _context == SynchronizationContext.Current;

    public void OnCompleted(Action continuation) => _context.Post(_postCallback, continuation);

    internal void GetResult() { }
    internal static SynchronizationContext Yield => SynchronizationContext.Current;
    internal static SynchronizationContext EnsureRunningOnMainThread() => SynchronizationContext.Current;
}

internal static class TaskAwaiterExtensions
{
    internal static TaskAwaiter GetAwaiter(this SynchronizationContext awaiter) => new(awaiter);
}