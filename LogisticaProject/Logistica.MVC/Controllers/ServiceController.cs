using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
