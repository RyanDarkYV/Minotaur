using System.Threading.Tasks;
using Minotaur.Identity.Domain;

namespace Minotaur.Identity.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        public Task<RefreshToken> GetAsync(string token)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(RefreshToken token)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RefreshToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}