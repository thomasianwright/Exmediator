using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
using Exmediator.Factories;
using Exmediator.Services;

namespace Exmediator.Core.Services
{
    public class Exmediator : IExmediator
    {
        private readonly IHandlerActivatorFactory _handlerActivatorFactory;
        private readonly ITaskExecutor _taskExecutor;

        public Exmediator(IHandlerActivatorFactory handlerActivatorFactory, ITaskExecutor taskExecutor)
        {
            _handlerActivatorFactory = handlerActivatorFactory;
            _taskExecutor = taskExecutor;
        }

        public ValueTask<TResponse> SendAsync<TEvent, TResponse>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : ICallbackEvent
        {
            var handler = _handlerActivatorFactory.ActivateAsync<TEvent, TResponse>(@event, cancellationToken);

            return handler;
        }

        public void Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            var handler = _handlerActivatorFactory.ActivateAsync<TEvent>(@event, cancellationToken);
            
            _taskExecutor.Execute(handler, cancellationToken);
        }
    }
}