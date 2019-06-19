using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;
using System;

namespace Minotaur.Operations.Messages.Todos.Events
{
    [MessageNamespace("todos")]
    public class TodoItemCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid UserId { get; set; }

        [JsonConstructor]
        public TodoItemCreated(Guid id, string title, string description, bool isDone, Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            IsDone = isDone;
            UserId = userId;
        }
    }
}
