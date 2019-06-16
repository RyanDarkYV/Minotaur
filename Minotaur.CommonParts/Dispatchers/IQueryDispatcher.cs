using System.Threading.Tasks;
using Minotaur.CommonParts.Types;

namespace Minotaur.CommonParts.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}