using System;
using System.Threading.Tasks;
using Minotaur.CommonParts.Authentication;
using Minotaur.Identity.Domain;

namespace Minotaur.Identity.Services
{
    public interface IIdentityService
    {
        Task SignUpAsync(Guid id, string email, string password, string login, string role = Role.User);
        Task<JsonWebToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword); 
    }
}