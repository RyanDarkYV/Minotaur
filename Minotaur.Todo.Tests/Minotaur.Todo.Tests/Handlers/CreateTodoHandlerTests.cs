using System;
using System.Threading.Tasks;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Handlers;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace Minotaur.Todo.Tests.Handlers
{

    [TestFixture]
    public class CreateTodoHandlerTests
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly ICorrelationContext _context;
        private readonly CreateTodoHandler _commandHandler;

        public CreateTodoHandlerTests()
        {
            _todoItemRepository = Substitute.For<ITodoItemRepository>();
            _busPublisher = Substitute.For<IBusPublisher>();
            _context = Substitute.For<ICorrelationContext>();

            _commandHandler = new CreateTodoHandler(_todoItemRepository, _busPublisher);
        }

        private Guid _id => Guid.Parse("6e90eb06-5c7f-49f2-a6a3-e92d8ec02bd5");
        private string _title => "title";
        private string _description => "description";
        private bool _isDone => false;
        private Guid _userId => Guid.Parse("839d54be-2f75-4c6f-9df7-570b398446f6");

        

        private async Task Act(CreateTodo command) => await _commandHandler.HandleAsync(command, _context);

        [Test]
        public async Task Handle_Async_Published_Create_TodoItem_Rejected_If_TodoItem_With_Given_Id_Exists()
        {
            CreateTodo command = new CreateTodo(_id, _title, _description, _isDone, _userId);

            _todoItemRepository
                .ExistsAsync(_id)
                .Returns(true);

            await Act(command);
            await _busPublisher
                .Received()
                .PublishAsync(Arg.Is<CreateTodoItemRejected>(e => e.Id == command.Id && e.Code == "todo_item_already_exists" && e.Reason == "Todo Item: already exists."), _context);
        }

        [Test]
        public async Task Handle_Async_Published_Todo_Item_Created_If_Ok()
        {
            CreateTodo command = new CreateTodo(_id, _title, _description, _isDone, _userId);

            _todoItemRepository
                .ExistsAsync(_id)
                .Returns(false);

            await Act(command);
            await _busPublisher
                .Received()
                .PublishAsync(Arg.Is<TodoItemCreated>(e => e.Id == command.Id && e.Title == command.Title && e.Description == command.Description && e.IsDone == command.IsDone && e.UserId == command.UserId), _context);
        }
    }
}