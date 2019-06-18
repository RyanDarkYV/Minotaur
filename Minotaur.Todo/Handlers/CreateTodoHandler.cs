using System.Threading.Tasks;
using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Domain;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;

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
            if (string.IsNullOrWhiteSpace(command.Title))
            {
                throw new MinotaurException("invalid_title",
                    "Title cannot be empty.");
            }

            var todoItem = new TodoItem(command.Id, command.UserId, command.Description, command.Title, command.IsDone);
            await _repository.AddAsync(todoItem);
            await _busPublisher.PublishAsync(
                new TodoItemCreated(command.Id, command.Title, command.Description, command.IsDone, command.UserId),
                context);
        }
    }
}