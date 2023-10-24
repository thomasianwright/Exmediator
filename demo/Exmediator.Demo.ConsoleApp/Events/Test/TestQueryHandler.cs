using Exmediator.Handlers;

namespace Exmediator.Demo.ConsoleApp.Events.Test;

public class TestQueryHandler : QueryHandler<TestQuery, string>
{
    public override async ValueTask<string> HandleAsync(TestQuery command, CancellationToken cancellationToken = default)
    {
        return await ValueTask.FromResult(command.TestString);
    }

    public override async ValueTask<string> HandleErrorAsync(TestQuery command, Exception exception, CancellationToken cancellationToken = default)
    {
        return await ValueTask.FromResult(exception.Message);
    }
}