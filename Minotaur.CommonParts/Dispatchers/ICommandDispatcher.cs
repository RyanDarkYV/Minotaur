using System.Threading.Tasks;
using Minotaur.CommonParts.Messages;

namespace Minotaur.CommonParts.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}