using System;
using System.Threading.Tasks;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.Todo.Domain;
using Minotaur.Todo.Handlers;
using Minotaur.Todo.Messages.Commands;
using Minotaur.Todo.Messages.Events;
using Minotaur.Todo.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Minotaur.Todo.Tests.Handlers
{
    public class UpdateTodoHandlerTests
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly ICorrelationContext _context;
        private readonly UpdateTodoHandler _commandHandler;

        public UpdateTodoHandlerTests()
        {
            _todoItemRepository = Substitute.For<ITodoItemRepository>();
            _busPublisher = Substitute.For<IBusPublisher>();
            _context = Substitute.For<ICorrelationContext>();

            _commandHandler = new UpdateTodoHandler(_todoItemRepository, _busPublisher);
        }

        private Guid _id => Guid.Parse("6e90eb06-5c7f-49f2-a6a3-e92d8ec02bd5");
        private string _title => "title";
        private string _description => "description";
        private bool _isDone => false;
        private Guid _userId => Guid.Parse("839d54be-2f75-4c6f-9df7-570b398446f6");

        

        private async Task Act(UpdateTodo command) => await _commandHandler.HandleAsync(command, _context);

        [Test]
        public async Task Handle_Async_Published_Update_TodoItem_Rejected_If_TodoItem_With_Given_Id_Does_Not_Exist()
        {
            UpdateTodo command = new UpdateTodo(_id, _title, _description, _isDone, _userId);

            _todoItemRepository
                .GetAsync(_id)
                .ReturnsNull();

            await Act(command);
            await _busPublisher
                .Received()
                .PublishAsync(Arg.Is<UpdateTodoItemRejected>(e => e.Id == command.Id && e.Code == "todo_item_does_not_exist" && e.Reason == $"TodoItem with id: '{command.Id}' was not found."), _context);
        }

        [Test]
        public async Task Handle_Async_Published_Todo_Item_Updated_If_Ok()
        {
            UpdateTodo command = new UpdateTodo(_id, _title, _description, true, _userId);
            TodoItem item = new TodoItem(_id, _userId, _description, _title, _isDone);
            _todoItemRepository
                .GetAsync(_id)
                .Returns(item);

            await Act(command);
            await _busPublisher
                .Received()
                .PublishAsync(Arg.Is<TodoItemUpdated>(e => e.Id == command.Id && e.Title == command.Title && e.Description == command.Description && e.IsDone == command.IsDone && e.UserId == command.UserId), _context);
        }
    }
}