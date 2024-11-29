using MediplusProject.DAL;
using MediplusProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediplusProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SliderItem> sliderItems = _context.SliderItems.ToList();
            return View(sliderItems);
        }
        
	}
}
