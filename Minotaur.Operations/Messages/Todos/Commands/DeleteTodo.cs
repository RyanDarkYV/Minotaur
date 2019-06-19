using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Operations.Messages.Todos.Commands
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