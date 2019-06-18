using System.Threading.Tasks;

namespace Minotaur.CommonParts.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}