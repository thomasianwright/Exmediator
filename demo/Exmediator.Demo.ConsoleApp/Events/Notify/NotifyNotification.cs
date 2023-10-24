using Exmediator.Events;

namespace Exmediator.Demo.ConsoleApp.Events.Notify;

public class NotifyNotification : INotification
{
    public string Message { get; set; }
}