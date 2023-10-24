using Exmediator.Core.Factories;
using Exmediator.Demo.ConsoleApp.Events.Test;
using Exmediator.Demo.ConsoleApp.Services;
using Exmediator.Enums;
using Exmediator.Factories;
using Exmediator.Handlers;
using Exmediator.Services;
using Exmediator.Stores;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var serviceRegister = new DemoExmediatorServiceRegister(services);
var store = new ExmediatorTypeStore();
store.Add(typeof(TestQuery), typeof(TestQueryHandler));

services.AddSingleton<IExmediatorTypeStore>(store);
serviceRegister.Register(typeof(TestQueryHandler), ExmediatorServiceLifetime.Scoped);
services.AddScoped<IExmediatorServiceResolver, DemoIExmediatorServiceResolver>();
services.AddScoped<IExmediator, Exmediator.Core.Services.Exmediator>();
services.AddScoped<IHandlerActivatorFactory, HandlerActivatorFactory>();
services.AddScoped<ITaskExecutor, DemoTaskExecutor>();

var serviceProvider = services.BuildServiceProvider();

var exmediator = serviceProvider.GetRequiredService<IExmediator>();

var result = await exmediator.SendAsync<TestQuery, string>(new TestQuery()
{
    TestString = "A pimp like slickback"
}, CancellationToken.None);

Console.WriteLine(result);