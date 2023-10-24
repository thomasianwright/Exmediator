using Exmediator.Demo.ConsoleApp.Events.Notify;
using Exmediator.Demo.ConsoleApp.Events.Test;
using Exmediator.Demo.ConsoleApp.Extensions;
using Exmediator.Demo.ConsoleApp.Services;
using Exmediator.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var serviceRegister = new DemoExmediatorServiceRegister(services);

services.RegisterMediator(x =>
    x.UseServiceRegister(serviceRegister)
        .UseServiceResolver<DemoIExmediatorServiceResolver>()
        .AddTaskExecutor<DemoTaskExecutor>()
        .AddHandler<TestQuery, TestQueryHandler>()
        .AddHandler<NotifyNotification, NotifyNotificationHandler>());

var serviceProvider = services.BuildServiceProvider();

var exmediator = serviceProvider.GetRequiredService<IExmediator>();

for(int i = 0; i < 10000; i++)
{
    var result = await exmediator.SendAsync<TestQuery, string>(new TestQuery()
    {
        TestString = "A pimp like slickback"
    }, CancellationToken.None);

    exmediator.Publish(new NotifyNotification()
    {
        Message = "Hello World"
    });

    Console.WriteLine(result);
}