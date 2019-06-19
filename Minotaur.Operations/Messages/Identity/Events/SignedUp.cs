using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Operations.Messages.Identity.Events
{
    [MessageNamespace("identity")]
    public class SignedUp : IEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string Role { get; }

        [JsonConstructor]
        public SignedUp(Guid userId, string email, string role)
        {
            UserId = userId;
            Email = email;
            Role = role;
        }
    }
}