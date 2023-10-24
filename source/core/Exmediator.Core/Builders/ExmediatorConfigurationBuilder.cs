using Exmediator.Core.Factories;
using Exmediator.Enums;
using Exmediator.Events;
using Exmediator.Factories;
using Exmediator.Handlers;
using Exmediator.Services;
using Exmediator.Stores;

namespace Exmediator.Core.Builders
{
    public class ExmediatorConfigurationBuilder
    {
        public IExmediatorServiceRegister ServiceRegister { get; set; }
        public IExmediatorTypeStore TypeStore { get; } = new ExmediatorTypeStore();

        public ExmediatorConfigurationBuilder UseServiceRegister(IExmediatorServiceRegister serviceRegister)
        {
            ServiceRegister = serviceRegister;
            return this;
        }
        
        public ExmediatorConfigurationBuilder UseServiceResolver<TServiceResolver>()
            where TServiceResolver : IExmediatorServiceResolver
        {
            ServiceRegister.Register(typeof(IExmediatorServiceResolver), typeof(TServiceResolver), ExmediatorServiceLifetime.Scoped);
            return this;
        }

        public ExmediatorConfigurationBuilder AddHandler<TEvent, THandler>()
            where TEvent : IEvent where THandler : IHandler
        {
            TypeStore.Add(typeof(TEvent), typeof(THandler));
            return this;
        }
        
        public ExmediatorConfigurationBuilder AddTaskExecutor<TTaskExecutor>()
            where TTaskExecutor : ITaskExecutor
        {
            ServiceRegister.Register(typeof(ITaskExecutor), typeof(TTaskExecutor), ExmediatorServiceLifetime.Singleton);
            return this;
        }
        
        public void Build()
        {
            ServiceRegister.Register(typeof(IExmediatorTypeStore), TypeStore, ExmediatorServiceLifetime.Singleton);

            foreach (var type in TypeStore.GetRegisteredTypes())
            {
                ServiceRegister.Register(type, ExmediatorServiceLifetime.Scoped);
            }
            
            ServiceRegister.Register(typeof(IExmediator), typeof(Services.Exmediator), ExmediatorServiceLifetime.Scoped);
            ServiceRegister.Register(typeof(IHandlerActivatorFactory), typeof(HandlerActivatorFactory), ExmediatorServiceLifetime.Scoped);
            
            TypeStore.SetInitialized();
        }
    }
}