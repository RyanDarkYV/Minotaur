using System;
using Minotaur.CommonParts.Types;
using Minotaur.Todo.Dto;

namespace Minotaur.Todo.Queries
{
    public class GetTodoItem : IQuery<TodoItemDto>
    {
        public Guid Id { get; set; }
    }
}
