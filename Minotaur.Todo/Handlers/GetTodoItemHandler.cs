using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Minotaur.CommonParts.Handlers;
using Minotaur.Todo.Dto;
using Minotaur.Todo.Queries;
using Minotaur.Todo.Repositories;

namespace Minotaur.Todo.Handlers
{
    public class GetTodoItemHandler : IQueryHandler<GetTodoItem, TodoItemDto>
    {
        private readonly ITodoItemRepository _repository;

        public GetTodoItemHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItemDto> HandleAsync(GetTodoItem query)
        {
            var todoItem = await _repository.GetAsync(query.Id);

            return todoItem == null
                ? null
                : new TodoItemDto()
                {
                    Id = todoItem.Id,
                    Title = todoItem.Title,
                    Description = todoItem.Description,
                    IsDone = todoItem.IsDone,
                    UserId = todoItem.UserId
                };
        }
    }
}