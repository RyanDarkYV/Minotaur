using System.Linq;
using System.Threading.Tasks;
using Minotaur.CommonParts.Handlers;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;
using Minotaur.Todo.Queries;
using Minotaur.Todo.Repositories;

namespace Minotaur.Todo.Handlers
{
    public class BrowseTodosForUserHandler : IQueryHandler<BrowseTodosForUser, PagedResult<TodoItemDto>>
    {
        private readonly ITodoItemRepository _repository;

        public BrowseTodosForUserHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<TodoItemDto>> HandleAsync(BrowseTodosForUser query)
        {
            var pagedResult = await _repository.BrowseTodosForUser(query);
            var todoItems = pagedResult.Items.Select(todo => new TodoItemDto()
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsDone = todo.IsDone,
                UserId = todo.UserId
            }).ToList();

            return PagedResult<TodoItemDto>.From(pagedResult, todoItems);
        }
    }
}