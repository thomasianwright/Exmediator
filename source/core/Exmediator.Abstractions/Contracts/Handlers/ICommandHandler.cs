using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
using FluentResults;

namespace Exmediator.Handlers
{
    public interface ICommandHandler<in TCommand, TResponse> : ICallbackHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit>
    {
    }
}