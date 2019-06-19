using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Api.Messages.Commands.TodoItems
{
    [MessageNamespace("todos")]
    public class DeleteTodo : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteTodo(Guid id)
        {
            Id = id;
        }
    }
}