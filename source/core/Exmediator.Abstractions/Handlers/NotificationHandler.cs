using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;

namespace Exmediator.Handlers
{
    public abstract class NotificationHandler<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        public abstract ValueTask<Unit> HandleAsync(TNotification notification,
            CancellationToken cancellationToken = default);

        public abstract ValueTask<Unit> HandleErrorAsync(TNotification notification, Exception exception,
            CancellationToken cancellationToken = default);
    }
}