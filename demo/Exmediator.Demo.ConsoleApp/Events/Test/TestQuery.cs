using Exmediator.Events;

namespace Exmediator.Demo.ConsoleApp.Events.Test;

public class TestQuery : IQuery<string>
{
    public string TestString { get; set; }
}