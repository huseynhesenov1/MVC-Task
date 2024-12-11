using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
