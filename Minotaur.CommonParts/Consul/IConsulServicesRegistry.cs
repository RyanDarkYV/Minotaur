using System.Threading.Tasks;
using Consul;

namespace Minotaur.CommonParts.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}