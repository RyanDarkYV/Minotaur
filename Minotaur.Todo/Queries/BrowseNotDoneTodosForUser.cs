using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;
using System;

namespace Minotaur.Todo.Queries
{
    public class BrowseNotDoneTodosForUser: PagedQueryBase, IQuery<PagedResult<TodoItemDto>>
    {
        public Guid Id { get; set; }
    }
}