using Microsoft.AspNetCore.Mvc;

namespace SporSalonuUyelik.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
