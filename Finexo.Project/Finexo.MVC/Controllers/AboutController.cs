using Microsoft.AspNetCore.Mvc;

namespace Finexo.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
