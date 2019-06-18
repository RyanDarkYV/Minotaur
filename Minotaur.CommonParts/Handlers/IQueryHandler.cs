using System.Threading.Tasks;
using Minotaur.CommonParts.Types;

namespace Minotaur.CommonParts.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}