using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;
using System.Threading.Tasks;

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
                //throw new MinotaurException("todo_item_not_found",
                //    $"TodoItem with id: '{command.Id}' was not found.");
                await _busPublisher.PublishAsync(
                    new DeleteTodoItemRejected(command.Id, "todo_item_does_not_exist",$"TodoItem with id: '{command.Id}' was not found."), context);
                return;
            }

            await _repository.DeleteAsync(command.Id);
            await _busPublisher.PublishAsync(new TodoItemDeleted(command.Id), context);
        }
    }
}