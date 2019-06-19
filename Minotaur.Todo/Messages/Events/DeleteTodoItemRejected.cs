using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Todo.Messages.Events
{
    public class DeleteTodoItemRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public DeleteTodoItemRejected(Guid id, string code, string reason)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}