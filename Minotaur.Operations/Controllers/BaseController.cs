using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minotaur.CommonParts.Dispatchers;
using Minotaur.CommonParts.Types;

namespace Minotaur.Operations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        protected async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
            => await _dispatcher.QueryAsync(query);

        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        protected ActionResult<PagedResult<T>> Collection<T>(PagedResult<T> pagedResult)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }

            return Ok(pagedResult);
        }
    }
}