using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
using Exmediator.Exceptions;
using Exmediator.Factories;
using Exmediator.Handlers;
using Exmediator.Services;
using Exmediator.Stores;

namespace Exmediator.Core.Factories
{
    public class HandlerActivatorFactory : IHandlerActivatorFactory
    {
        private readonly IExmediatorServiceResolver _exmediatorServiceResolver;
        private readonly IExmediatorTypeStore _exmediatorTypeStore;

        public HandlerActivatorFactory(IExmediatorServiceResolver exmediatorServiceResolver,
            IExmediatorTypeStore exmediatorTypeStore)
        {
            _exmediatorServiceResolver = exmediatorServiceResolver;
            _exmediatorTypeStore = exmediatorTypeStore;
            
        }

        public async ValueTask<TResponse> ActivateAsync<TEvent, TResponse>(TEvent @event,
            CancellationToken cancellationToken = default) where TEvent : ICallbackEvent
        {
            var eventType = @event.GetType();
            var handlerMetadata = _exmediatorTypeStore.Get(eventType);

            var handler = _exmediatorServiceResolver.GetService(handlerMetadata.HandlerType);

            return await (ValueTask<TResponse>)handlerMetadata.HandleAsyncMethod.Invoke(handler,
                new object[] { @event, cancellationToken });
        }

        public async ValueTask<Unit> ActivateAsync<TEvent>(TEvent @event,
            CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            var eventType = @event.GetType();
            var handlerMetadata = _exmediatorTypeStore.Get(eventType);

            var handler = _exmediatorServiceResolver.GetService(handlerMetadata.HandlerType);

            await (ValueTask)handlerMetadata.HandleAsyncMethod.Invoke(handler, new object[] { @event, cancellationToken });

            return Unit.Value;
        }
    }
}