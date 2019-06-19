using System.Threading.Tasks;
using Minotaur.CommonParts.RabbitMq;

namespace Minotaur.Operations.Services
{
    public interface IOperationPublisher
    {
        Task PendingAsync(ICorrelationContext context);
        Task CompleteAsync(ICorrelationContext context);
        Task RejectAsync(ICorrelationContext context, string code, string message);
    }
}