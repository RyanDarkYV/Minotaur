using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Identity.Messages.Commands
{
    public class RevokeAccessToken : ICommand
    {
        public Guid UserId { get; }
        public string Token { get; }

        [JsonConstructor]
        public RevokeAccessToken(Guid userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}