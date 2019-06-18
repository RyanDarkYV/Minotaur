using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Todo.Messages.Commands
{
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