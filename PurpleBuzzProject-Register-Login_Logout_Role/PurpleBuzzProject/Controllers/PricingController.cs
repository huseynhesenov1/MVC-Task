using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzProject.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
