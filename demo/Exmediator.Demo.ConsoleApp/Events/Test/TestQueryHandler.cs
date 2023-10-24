using Exmediator.Handlers;

namespace Exmediator.Demo.ConsoleApp.Events.Test;

public class TestQueryHandler : IQueryHandler<TestQuery, string>
{
    public async ValueTask<string> HandleAsync(TestQuery command, CancellationToken cancellationToken = default)
    {
        return await ValueTask.FromResult(command.TestString);
    }

    public async ValueTask<string> HandleErrorAsync(TestQuery command, Exception exception, CancellationToken cancellationToken = default)
    {
        return await ValueTask.FromResult(exception.Message);
    }
}