using System.Threading;
using System.Threading.Tasks;

namespace Exmediator.Services
{
    public interface ITaskExecutor
    {
        void Execute(Task task, CancellationToken cancellationToken = default);
        
        void Execute<T>(Task<T> task, CancellationToken cancellationToken = default);
        
        void Execute(ValueTask task, CancellationToken cancellationToken = default);
        
        void Execute<T>(ValueTask<T> task, CancellationToken cancellationToken = default);
    }
}