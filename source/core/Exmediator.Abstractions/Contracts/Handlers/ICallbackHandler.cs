using System;
using System.Threading;
using System.Threading.Tasks;
using Exmediator.Events;

namespace Exmediator.Handlers
{
    public interface ICallbackHandler<in TEvent, TResponse> : IHandler where TEvent : ICallbackEvent
    {
        ValueTask<TResponse> HandleAsync(TEvent command, CancellationToken cancellationToken = default);

        ValueTask<TResponse> HandleErrorAsync(TEvent command, Exception exception,
            CancellationToken cancellationToken = default);
    }
}