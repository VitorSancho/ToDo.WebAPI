using Microsoft.AspNetCore.Mvc;

namespace ToDo.WebAPI.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
