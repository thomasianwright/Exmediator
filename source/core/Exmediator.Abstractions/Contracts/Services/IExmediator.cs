using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;

namespace Exmediator.Services
{
    public interface IExmediator
    {
        ValueTask<TResponse> SendAsync<TEvent, TResponse>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : ICallbackEvent;

        ValueTask PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IEvent;
    }
}