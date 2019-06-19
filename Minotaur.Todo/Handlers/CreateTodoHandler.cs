using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.Todo.Domain;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;
using System.Threading.Tasks;

namespace Minotaur.Todo.Handlers
{
    public class CreateTodoHandler : ICommandHandler<CreateTodo>
    {
        private readonly ITodoItemRepository _repository;
        private readonly IBusPublisher _busPublisher;

        public CreateTodoHandler(ITodoItemRepository repository, IBusPublisher busPublisher)
        {
            _repository = repository;
            _busPublisher = busPublisher;
        }


        public async Task HandleAsync(CreateTodo command, ICorrelationContext context)
        {
            if (await _repository.ExistsAsync(command.Id))
            {
                //throw new MinotaurException("todo_item_already_exists",
                //    $"Todo Item: '{command.Id}' already exists.");
                await _busPublisher.PublishAsync(
                    new CreateTodoItemRejected(command.Id, "todo_item_already_exists","Todo Item: already exists."), context);
                return;
            }

            var todoItem = new TodoItem(command.Id, command.UserId, command.Description, command.Title, command.IsDone);
            await _repository.AddAsync(todoItem);
            await _busPublisher.PublishAsync(
                new TodoItemCreated(command.Id, command.Title, command.Description, command.IsDone, command.UserId),
                context);
        }
    }
}