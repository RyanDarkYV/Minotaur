using Microsoft.AspNetCore.Mvc;

namespace Minotaur.Identity.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Identity Service");
    }
}