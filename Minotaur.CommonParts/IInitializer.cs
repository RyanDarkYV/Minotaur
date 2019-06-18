using System.Threading.Tasks;

namespace Minotaur.CommonParts
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}