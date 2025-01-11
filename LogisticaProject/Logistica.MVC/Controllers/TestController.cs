using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
