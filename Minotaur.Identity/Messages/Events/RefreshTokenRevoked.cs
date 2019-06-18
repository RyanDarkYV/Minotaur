using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;
using System;

namespace Minotaur.Identity.Messages.Events
{
    public class RefreshTokenRevoked : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public RefreshTokenRevoked(Guid userId)
        {
            UserId = userId;
        }
    }
}
