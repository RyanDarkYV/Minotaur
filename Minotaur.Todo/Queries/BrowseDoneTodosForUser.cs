using System;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;

namespace Minotaur.Todo.Queries
{
    public class BrowseDoneTodosForUser : PagedQueryBase, IQuery<PagedResult<TodoItemDto>>
    {
        public Guid Id { get; set; }
    }
}