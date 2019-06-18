using Minotaur.CommonParts.Messages;
using Minotaur.CommonParts.Types;
using System.Threading.Tasks;

namespace Minotaur.CommonParts.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
