using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
using FluentResults;

namespace Exmediator.Handlers
{
    public interface IQueryHandler<in TQuery, TResponse> : ICallbackHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {

    }
    
    public interface IQueryHandler<in TQuery> : IQueryHandler<TQuery, Unit> where TQuery : IQuery<Unit> { }
}