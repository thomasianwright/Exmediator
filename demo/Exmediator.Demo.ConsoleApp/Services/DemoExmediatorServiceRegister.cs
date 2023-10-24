using Exmediator.Enums;
using Exmediator.Services;
using Exmediator.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace Exmediator.Demo.ConsoleApp.Services;

public class DemoExmediatorServiceRegister : IExmediatorServiceRegister
{
    private readonly IServiceCollection _serviceCollection;
    private readonly IExmediatorTypeStore _exmediatorTypeStore;

    public DemoExmediatorServiceRegister(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }
    
    public ExmediatorServiceLifetime DefaultLifetime { get; set; }
    public void Register(Type implementationType, ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient)
    {
        if (lifetime == ExmediatorServiceLifetime.Transient)
        {
            _serviceCollection.AddTransient(implementationType);
        }
        else if (lifetime == ExmediatorServiceLifetime.Scoped)
        {
            _serviceCollection.AddScoped(implementationType);
        }
        else if (lifetime == ExmediatorServiceLifetime.Singleton)
        {
            _serviceCollection.AddSingleton(implementationType);
        }
    }

    public void Register(Type serviceType, Type implementationType,
        ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient)
    {
        if (lifetime == ExmediatorServiceLifetime.Transient)
        {
            _serviceCollection.AddTransient(serviceType, implementationType);
        }
        else if (lifetime == ExmediatorServiceLifetime.Scoped)
        {
            _serviceCollection.AddScoped(serviceType, implementationType);
        }
        else if (lifetime == ExmediatorServiceLifetime.Singleton)
        {
            _serviceCollection.AddSingleton(serviceType, implementationType);
        }
    }
}