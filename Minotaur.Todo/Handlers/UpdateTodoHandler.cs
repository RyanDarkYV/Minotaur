using System.Threading.Tasks;
using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;

namespace Minotaur.Todo.Handlers
{
    public class UpdateTodoHandler : ICommandHandler<UpdateTodo>
    {
        private readonly ITodoItemRepository _repository;
        private readonly IBusPublisher _busPublisher;

        public UpdateTodoHandler(ITodoItemRepository repository, IBusPublisher busPublisher)
        {
            _repository = repository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateTodo command, ICorrelationContext context)
        {
            var todoItem = await _repository.GetAsync(command.Id);
            if (todoItem == null)
            {
                throw new MinotaurException("todo_item_not_found",
                    $"TodoItem with id: '{command.Id}' was not found.");
            }

            todoItem.SetTitle(command.Title);
            todoItem.SetDescription(command.Description);
            todoItem.SetUserId(command.Id);
            todoItem.SetIsDone(command.IsDone);
            await _repository.UpdateAsync(todoItem);
            await _busPublisher.PublishAsync(
                new TodoItemUpdated(command.Id, command.Title, command.Description, command.IsDone, command.UserId), context);
        }
    }
}