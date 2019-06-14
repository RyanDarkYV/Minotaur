using System.Threading.Tasks;
using Minotaur.Identity.Domain;

namespace Minotaur.Identity.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}