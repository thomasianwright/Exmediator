using Exmediator.Services;

namespace Exmediator.Demo.ConsoleApp.Services;

public class DemoTaskExecutor : ITaskExecutor
{
    public void Execute(Task task, CancellationToken cancellationToken = default)
    {
        new TaskFactory(cancellationToken).StartNew(() => task, cancellationToken);
    }

    public void Execute<T>(Task<T> task, CancellationToken cancellationToken = default)
    {
        new TaskFactory(cancellationToken).StartNew(() => task, cancellationToken);
    }

    public void Execute(ValueTask task, CancellationToken cancellationToken = default)
    {
        new TaskFactory(cancellationToken).StartNew(() => task, cancellationToken);
    }

    public void Execute<T>(ValueTask<T> task, CancellationToken cancellationToken = default)
    {
        new TaskFactory(cancellationToken).StartNew(() => task, cancellationToken);
    }
}