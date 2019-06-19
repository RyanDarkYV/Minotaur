using System;
using System.Threading.Tasks;
using Minotaur.Api.Models.Todos;
using Minotaur.Api.Queries;
using Minotaur.CommonParts.Types;
using RestEase;

namespace Minotaur.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ITodoItemsService
    {
        [AllowAnyStatusCode]
        [Get("todos/{id}")]
        Task<TodoItem> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("todos")]
        Task<PagedResult<TodoItem>> BrowseAsync([Query] BrowseTodosForUser query);
    }
}