using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Controllers
{
    public class ContactController : Controller
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;
        public IActionResult Index()
        {
            return View();
        }
    }
}
