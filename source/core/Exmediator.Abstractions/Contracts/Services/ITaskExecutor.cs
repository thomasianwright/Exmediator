using System.Threading;
using System.Threading.Tasks;

namespace Exmediator.Services
{
    public interface ITaskExecutor
    {
        void Execute(Task task, CancellationToken cancellationToken = default);
    }
}