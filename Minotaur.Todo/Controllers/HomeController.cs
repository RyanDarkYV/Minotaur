using Microsoft.AspNetCore.Mvc;

namespace Minotaur.Todo.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Minotaur-Todo Service");
    }
}