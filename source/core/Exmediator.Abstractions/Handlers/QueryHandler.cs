using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;
using FluentResults;

namespace Exmediator.Handlers
{
    public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        public abstract ValueTask<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);

        public abstract ValueTask<TResponse> HandleErrorAsync(TQuery query, Exception exception,
            CancellationToken cancellationToken = default);
    }
    
    public abstract class QueryHandler<TQuery> : QueryHandler<TQuery, Unit>, IQueryHandler<TQuery> where TQuery : IQuery<Unit>
    {
    }
}