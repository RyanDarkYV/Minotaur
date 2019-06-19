using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minotaur.Api.Framework;
using Minotaur.Api.Messages.Commands.TodoItems;
using Minotaur.Api.Queries;
using Minotaur.Api.Services;
using Minotaur.CommonParts.Mvc;
using Minotaur.CommonParts.RabbitMq;
using OpenTracing;

namespace Minotaur.Api.Controllers
{
    [AdminAuth]
    public class TodoItemsController : BaseController
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodoItemsController(IBusPublisher busPublisher, ITracer tracer, ITodoItemsService todoItemsService) : base(busPublisher, tracer)
        {
            _todoItemsService = todoItemsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseTodosForUser query)
            => Collection(await _todoItemsService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _todoItemsService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodo command)
            => await SendAsync(command.BindId(c => c.Id), 
                resourceId: command.Id, resource: "products");

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(Guid id, UpdateTodo command)
            => await SendAsync(command.Bind(c => c.Id, id), 
                resourceId: command.Id, resource: "products");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteTodo(id));
    }
}