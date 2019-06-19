using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Operations.Messages.Todos.Events
{
    [MessageNamespace("todos")]
    public class TodoItemDeleted : IEvent
    {
        public Guid Id { get; private set; }

        [JsonConstructor]
        public TodoItemDeleted(Guid id)
        {
            Id = id;
        }
    }
}