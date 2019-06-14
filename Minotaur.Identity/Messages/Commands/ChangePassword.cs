using System;
using Minotaur.CommonParts.Messages;
using Newtonsoft.Json;

namespace Minotaur.Identity.Messages.Commands
{
    public class ChangePassword : ICommand
    {
        [JsonConstructor]
        public ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            UserId = userId;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

        public Guid UserId { get; }
        public string CurrentPassword { get; }
        public string NewPassword { get; }
    }
}