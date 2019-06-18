using System.Threading.Tasks;
using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;

namespace Minotaur.Todo.Handlers
{
    public sealed class DeleteTodoHandler : ICommandHandler<DeleteTodo>
    {
        private readonly ITodoItemRepository _repository;
        private readonly IBusPublisher _busPublisher;

        public DeleteTodoHandler(ITodoItemRepository repository, IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
            _repository = repository;
        }

        public async Task HandleAsync(DeleteTodo command, ICorrelationContext context)
        {
            if (!await _repository.ExistsAsync(command.Id))
            {
                throw new MinotaurException("todo_item_not_found",
                    $"TodoItem with id: '{command.Id}' was not found.");
            }

            await _repository.DeleteAsync(command.Id);
            await _busPublisher.PublishAsync(new TodoItemDeleted(command.Id), context);
        }
    }
}