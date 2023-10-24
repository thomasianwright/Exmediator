using System.Threading.Channels;
using Exmediator.Services;

namespace Exmediator.Demo.ConsoleApp.Services;

public class DemoTaskExecutor : ITaskExecutor
{
    private Channel<Task> _channel = Channel.CreateUnbounded<Task>();

    public DemoTaskExecutor()
    {
        new TaskFactory().StartNew(async () =>
        {
            while (await _channel.Reader.WaitToReadAsync())
            {
                while (_channel.Reader.TryRead(out var task))
                {
                    await task;
                }
            }
        });
    }
    
    public void Execute(Task task, CancellationToken cancellationToken = default)
    {
        _channel.Writer.TryWrite(task);
    }

    public void Execute<T>(Task<T> task, CancellationToken cancellationToken = default)
    {
        _channel.Writer.TryWrite(task);
    }

    public void Execute(ValueTask task, CancellationToken cancellationToken = default)
    {
        _channel.Writer.TryWrite(task.AsTask());
    }

    public void Execute<T>(ValueTask<T> task, CancellationToken cancellationToken = default)
    {
        _channel.Writer.TryWrite(task.AsTask());
    }
}