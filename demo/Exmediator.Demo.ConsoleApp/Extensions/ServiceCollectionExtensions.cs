using Exmediator.Core.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Exmediator.Demo.ConsoleApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterMediator(this IServiceCollection services, Action<ExmediatorConfigurationBuilder> builder)
    {
        var exmediatorConfigurationBuilder = new ExmediatorConfigurationBuilder();
        builder(exmediatorConfigurationBuilder);

        exmediatorConfigurationBuilder.Build();

        return services;
    }
}