using Exmediator.Core.Builders;
using Exmediator.Core.Factories;
using Exmediator.Demo.ConsoleApp.Events.Notify;
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

new ExmediatorConfigurationBuilder()
    .UseServiceRegister(serviceRegister)
    .UseServiceResolver<DemoIExmediatorServiceResolver>()
    .AddTaskExecutor<DemoTaskExecutor>()
    .AddHandler<TestQuery, TestQueryHandler>()
    .AddHandler<NotifyNotification, NotifyNotificationHandler>()
    .Build();

var serviceProvider = services.BuildServiceProvider();

var exmediator = serviceProvider.GetRequiredService<IExmediator>();

var result = await exmediator.SendAsync<TestQuery, string>(new TestQuery()
{
    TestString = "A pimp like slickback"
}, CancellationToken.None);

exmediator.Publish(new NotifyNotification()
{
    Message = "Hello World"
});

Console.WriteLine(result);