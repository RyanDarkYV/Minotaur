using Minotaur.CommonParts.Mongo;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Domain;
using Minotaur.Todo.Queries;
using System;
using System.Threading.Tasks;

namespace Minotaur.Todo.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {

        private readonly IMongoRepository<TodoItem> _repository;

        public TodoItemRepository(IMongoRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public async Task<TodoItem> GetAsync(Guid id) => await _repository.GetAsync(id);

        public async Task<bool> ExistsAsync(Guid id) => await _repository.ExistsAsync(item => item.Id == id);

        public async Task<PagedResult<TodoItem>> BrowseTodosForUser(BrowseTodosForUser query) => await _repository.BrowseAsync(items => items.Id == query.Id,query);

        public async Task<PagedResult<TodoItem>> BrowseDoneTodosForAllUsers(BrowseDoneTodosForAllUsers query) =>
            await _repository.BrowseAsync(items => items.IsDone == true, query);

        public async Task<PagedResult<TodoItem>>BrowseNotDoneTodosForAllUsers(BrowseNotDoneTodosForAllUsers query) =>
            await _repository.BrowseAsync(items => items.IsDone == false, query);

        public async Task<PagedResult<TodoItem>> BrowseDoneTodosForUser(BrowseDoneTodosForUser query) =>
            await _repository.BrowseAsync(items => items.UserId == query.Id && items.IsDone == true, query);

        public async Task<PagedResult<TodoItem>> BrowseNotDoneTodosForUser(BrowseNotDoneTodosForUser query) =>
            await _repository.BrowseAsync(items => items.Id == query.Id && items.IsDone == false, query);

        public async Task AddAsync(TodoItem todoItem) => await _repository.AddAsync(todoItem);

        public async Task UpdateAsync(TodoItem todoItem) => await _repository.UpdateAsync(todoItem);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}