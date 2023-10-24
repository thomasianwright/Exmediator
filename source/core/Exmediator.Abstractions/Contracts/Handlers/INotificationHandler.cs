using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;

namespace Exmediator.Handlers
{
    public interface INotificationHandler<in TNotification> : IHandler
        where TNotification : INotification
    {
        ValueTask<Unit> HandleAsync(TNotification notification, CancellationToken cancellationToken = default);
        
        ValueTask<Unit> HandleErrorAsync(TNotification notification, Exception exception, CancellationToken cancellationToken = default);
    }
}