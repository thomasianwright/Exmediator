using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
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
        private readonly ITaskExecutor _taskExecutor;

        public HandlerActivatorFactory(IExmediatorServiceResolver exmediatorServiceResolver, IExmediatorTypeStore exmediatorTypeStore, ITaskExecutor taskExecutor)
        {
            _exmediatorServiceResolver = exmediatorServiceResolver;
            _exmediatorTypeStore = exmediatorTypeStore;
            _taskExecutor = taskExecutor;
        }
        
        public async ValueTask<TResponse> ActivateAsync<TEvent, TResponse>(TEvent @event,
            CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            var eventType = @event.GetType();
            var handlerMetadata = _exmediatorTypeStore.Get(eventType);

            if (@event is ICallbackEvent)
            {
                var handler = _exmediatorServiceResolver.GetService(handlerMetadata.HandlerType);
                
                return await (ValueTask<TResponse>) handlerMetadata.HandleAsyncMethod.Invoke(handler, new object[] {@event, cancellationToken});
            }
            
            _taskExecutor.Execute(new Task(async () =>
            {
                var handler = _exmediatorServiceResolver.GetService(handlerMetadata.HandlerType);
                
                await ((ValueTask<Unit>)handlerMetadata.HandleAsyncMethod.Invoke(handler,
                    new object[] { @event, cancellationToken }));
            }), cancellationToken);
            
            return default;
        }
    }
}