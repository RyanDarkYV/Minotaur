using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Identity.Messages.Events
{
    public class AccessTokenRevoked : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public AccessTokenRevoked(Guid userId)
        {
            UserId = userId;
        }
    }
}