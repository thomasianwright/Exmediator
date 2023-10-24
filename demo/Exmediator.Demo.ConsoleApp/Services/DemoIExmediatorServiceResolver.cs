using Exmediator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Exmediator.Demo.ConsoleApp.Services;

public class DemoIExmediatorServiceResolver : IExmediatorServiceResolver
{
    private readonly IServiceProvider _serviceProvider;

    public DemoIExmediatorServiceResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    public TService GetService<TService>()
    {
        return (TService)_serviceProvider.GetRequiredService(typeof(TService));
    }

    public object GetService(Type serviceType)
    {
        return _serviceProvider.GetRequiredService(serviceType);
    }
}