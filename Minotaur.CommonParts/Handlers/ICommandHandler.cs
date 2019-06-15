using System.Threading.Tasks;
using Minotaur.CommonParts.Messages;
using Minotaur.CommonParts.RabbitMq;

namespace Minotaur.CommonParts.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}