using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;

namespace Exmediator.Factories
{
    public interface IHandlerActivatorFactory
    {
        ValueTask<TResponse> ActivateAsync<TEvent, TResponse>(TEvent @event,
            CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}