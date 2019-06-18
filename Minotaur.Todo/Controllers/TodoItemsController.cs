using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Minotaur.CommonParts.Dispatchers;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;
using Minotaur.Todo.Queries;

namespace Minotaur.Todo.Controllers
{
    [Route("[controller]")]
    public class TodoItemsController : BaseController
    {
        public TodoItemsController(IDispatcher dispatcher) : base(dispatcher)
        {
        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<TodoItemDto>>> Get([FromBody] BrowseTodosForUser query)
            => Collection(await QueryAsync(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetAsync([FromRoute] GetTodoItem query)
            => Single(await QueryAsync(query));
    }
}