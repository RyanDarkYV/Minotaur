using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Api.Messages.Commands.TodoItems
{
    [MessageNamespace("todos")]
    public class UpdateTodo : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid UserId { get; set; }

        [JsonConstructor]
        public UpdateTodo(Guid id, string title, string description, bool isDone, Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            IsDone = isDone;
            UserId = userId;
        }
    }
}