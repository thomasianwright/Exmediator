using Exmediator.Handlers;

namespace Exmediator.Demo.ConsoleApp.Events.Notify;

public class NotifyNotificationHandler : NotificationHandler<NotifyNotification>
{
    public override async ValueTask<Unit> HandleAsync(NotifyNotification notification, CancellationToken cancellationToken = default)
    {
        Console.WriteLine(notification.Message);
        return await ValueTask.FromResult(Unit.Value);
    }

    public override async ValueTask<Unit> HandleErrorAsync(NotifyNotification notification, Exception exception,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine(exception.Message);
        
        return await ValueTask.FromResult(Unit.Value);
    }
}