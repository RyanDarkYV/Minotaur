﻿using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Operations.Messages.Todos.Events
{
    [MessageNamespace("todos")]
    public class CreateTodoItemRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public CreateTodoItemRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}