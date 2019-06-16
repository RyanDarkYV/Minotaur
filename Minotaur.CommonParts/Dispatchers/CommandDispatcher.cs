using System.Threading.Tasks;
using Autofac;
using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.Messages;
using Minotaur.CommonParts.RabbitMq;

namespace Minotaur.CommonParts.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command, CorrelationContext.Empty);
    }
}