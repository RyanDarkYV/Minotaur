using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Todo.Messages.Events
{
    public class UpdateTodoItemRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public UpdateTodoItemRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}