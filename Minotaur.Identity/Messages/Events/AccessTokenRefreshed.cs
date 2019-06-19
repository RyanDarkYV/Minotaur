using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Identity.Messages.Events
{
    public class AccessTokenRefreshed : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public AccessTokenRefreshed(Guid userId)
        {
            UserId = userId;
        }
    }
}