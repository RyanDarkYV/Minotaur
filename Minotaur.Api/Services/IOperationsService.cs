using System;
using System.Threading.Tasks;
using Minotaur.Api.Models.Operations;
using RestEase;

namespace Minotaur.Api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}