namespace Core;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public sealed class TaskQueue : IDisposable
{
    private readonly ConcurrentQueue<Func<Task>> _queue;
    private readonly SemaphoreSlim _signal;
    private readonly CancellationTokenSource _cts;
    private readonly Task _worker;

    public static TaskQueue Instance { get; } = new TaskQueue();

    private TaskQueue()
    {
        _queue = new ConcurrentQueue<Func<Task>>();
        _signal = new SemaphoreSlim(0);
        _cts = new CancellationTokenSource();

        // Start background worker
        _worker = Task.Run(ProcessQueueAsync);
    }

    public void Enqueue(Func<Task> workItem)
    {
        if (workItem == null)
            throw new ArgumentNullException(nameof(workItem));

        _queue.Enqueue(workItem);
        _signal.Release();
    }

    private async Task ProcessQueueAsync()
    {
        while (!_cts.IsCancellationRequested)
        {
            await _signal.WaitAsync(_cts.Token);

            if (_queue.TryDequeue(out var task))
            {
                try
                {
                    await task();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Queue Error] {ex.Message}");
                }
            }
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _signal.Dispose();
        _cts.Dispose();
    }
}
