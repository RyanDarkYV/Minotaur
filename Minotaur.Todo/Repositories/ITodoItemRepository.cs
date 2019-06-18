using Minotaur.Todo.Domain;
using System;
using System.Threading.Tasks;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;
using Minotaur.Todo.Queries;

namespace Minotaur.Todo.Repositories
{
    public interface ITodoItemRepository
    {
        Task<TodoItem> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<PagedResult<TodoItem>> BrowseTodosForUser(BrowseTodosForUser query);
        Task<PagedResult<TodoItem>> BrowseDoneTodosForAllUsers(BrowseDoneTodosForAllUsers query);
        Task<PagedResult<TodoItem>> BrowseNotDoneTodosForAllUsers(BrowseNotDoneTodosForAllUsers query);
        Task<PagedResult<TodoItem>> BrowseDoneTodosForUser(BrowseDoneTodosForUser query);
        Task<PagedResult<TodoItem>> BrowseNotDoneTodosForUser(BrowseNotDoneTodosForUser query);
        Task AddAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(Guid id);
    }
}
