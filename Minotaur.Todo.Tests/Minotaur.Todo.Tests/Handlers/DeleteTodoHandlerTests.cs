using System;
using System.Threading.Tasks;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.Todo.Handlers;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace Minotaur.Todo.Tests.Handlers
{
    public class DeleteTodoHandlerTests
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly ICorrelationContext _context;
        private readonly DeleteTodoHandler _commandHandler;

        public DeleteTodoHandlerTests()
        {
            _todoItemRepository = Substitute.For<ITodoItemRepository>();
            _busPublisher = Substitute.For<IBusPublisher>();
            _context = Substitute.For<ICorrelationContext>();

            _commandHandler = new DeleteTodoHandler(_todoItemRepository, _busPublisher);
        }

        private Guid _id => Guid.Parse("6e90eb06-5c7f-49f2-a6a3-e92d8ec02bd5");

        private async Task Act(DeleteTodo command) => await _commandHandler.HandleAsync(command, _context);

        [Test]
        public async Task Handle_Async_Published_Delete_TodoItem_Rejected_If_TodoItem_With_Given_Id_Does_Not_Exist()
        {
            DeleteTodo command = new DeleteTodo(_id);

            _todoItemRepository
                .ExistsAsync(_id)
                .Returns(false);

            await Act(command);
            await _busPublisher
                .Received()
                .PublishAsync(Arg.Is<DeleteTodoItemRejected>(e => e.Id == command.Id && e.Code == "todo_item_does_not_exist" && e.Reason == $"TodoItem with id: '{command.Id}' was not found."), _context);
        }
        [Test]
        public async Task Handle_Async_Published_TodoItem_Deleted_If_TodoItem_With_Given_Id_Exists()
        {
            DeleteTodo command = new DeleteTodo(_id);

            _todoItemRepository
                .ExistsAsync(_id)
                .Returns(true);

            await Act(command);
            await _busPublisher
                .Received()
                .PublishAsync(Arg.Is<TodoItemDeleted>(e => e.Id == command.Id), _context);
        }
    }
}