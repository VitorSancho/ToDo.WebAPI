using Microsoft.AspNetCore.Mvc;

namespace ToDo.WebAPI.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
