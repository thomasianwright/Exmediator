using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
using FluentResults;

namespace Exmediator.Handlers
{
    public abstract class CommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse> 
        where TCommand : ICommand<TResponse>
    {
        public abstract ValueTask<TResponse> HandleAsync(TCommand command,
            CancellationToken cancellationToken = default);

        public abstract ValueTask<TResponse> HandleErrorAsync(TCommand command, Exception exception,
            CancellationToken cancellationToken = default);
    }
    
    public abstract class CommandHandler<TCommand> : CommandHandler<TCommand, Unit>, ICommandHandler<TCommand> 
        where TCommand : ICommand<Unit>
    {
    }
}