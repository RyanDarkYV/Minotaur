using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Operations.Messages.Identity.Events
{
    [MessageNamespace("identity")]
    public class SignedIn : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public SignedIn(Guid userId)
        {
            UserId = userId;
        }
    }
}