using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Todo.Messages.Events
{
    public class TodoItemUpdated : IEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid UserId { get; set; }

        [JsonConstructor]
        public TodoItemUpdated(Guid id, string title, string description, bool isDone, Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            IsDone = isDone;
            UserId = userId;
        }
    }
}