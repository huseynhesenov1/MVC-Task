using LogisticaProject.BL.Services.Abstractions;
using LogisticaProject.BL.Services.Implementations;
using LogisticaProject.Core.Entities;
using LogisticaProject.DAL.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ITransportService _transportService;
        public HomeController(ITransportService transportService)
        {
            _transportService = transportService;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _transportService.GetAllAsync();
            return View(res);
        }
    }
}
