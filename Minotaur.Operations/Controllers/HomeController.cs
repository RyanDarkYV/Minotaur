using Microsoft.AspNetCore.Mvc;

namespace Minotaur.Operations.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Minotaur Operations Service");
    }
}