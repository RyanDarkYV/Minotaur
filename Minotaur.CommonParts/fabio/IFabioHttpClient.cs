using System.Threading.Tasks;

namespace Minotaur.CommonParts.Fabio
{
    public interface IFabioHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);

    }
}
