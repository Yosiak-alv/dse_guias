using Microsoft.AspNetCore.Mvc;

namespace Guia02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
