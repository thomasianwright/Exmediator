using Exmediator.Handlers;

namespace Exmediator.Demo.ConsoleApp.Events.Notify;

public class NotifyNotificationHandler : INotificationHandler<NotifyNotification>
{
    public async ValueTask<Unit> HandleAsync(NotifyNotification notification, CancellationToken cancellationToken = default)
    {
        Console.WriteLine(notification.Message);
        return await ValueTask.FromResult(Unit.Value);
    }

    public async ValueTask<Unit> HandleErrorAsync(NotifyNotification notification, Exception exception,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine(exception.Message);
        
        return await ValueTask.FromResult(Unit.Value);
    }
}