using System.Threading.Tasks;
using Minotaur.CommonParts.Messages;
using Minotaur.CommonParts.RabbitMq;

namespace Minotaur.CommonParts.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}