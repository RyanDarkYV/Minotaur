using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minotaur.CommonParts.RabbitMq;
using OpenTracing;

namespace Minotaur.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("Minotaur API");
    }
}