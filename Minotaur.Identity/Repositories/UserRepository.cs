using System;
using System.Threading.Tasks;
using Minotaur.Identity.Domain;

namespace Minotaur.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}