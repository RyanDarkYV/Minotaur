using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minotaur.CommonParts.Dispatchers;
using Minotaur.Operations.Dto;
using Minotaur.Operations.Services;

namespace Minotaur.Operations.Controllers
{
    [Route("[controller]")]
    public class OperationsController : BaseController
    {
        private readonly IOperationsStorage _operationsStorage;

        public OperationsController(IDispatcher dispatcher,
            IOperationsStorage operationsStorage) : base(dispatcher)
        {
            _operationsStorage = operationsStorage;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDto>> Get(Guid id)
            => Single(await _operationsStorage.GetAsync(id));
    }
}