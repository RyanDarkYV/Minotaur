using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Identity.Messages.Commands
{
    public class RefreshAccessToken : ICommand
    {
        public string Token { get; }

        [JsonConstructor]
        public RefreshAccessToken(string token)
        {
            Token = token;
        }
    }
}