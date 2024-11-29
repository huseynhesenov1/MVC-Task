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
        public IActionResult Delete(int Id)
        {
            SliderItem? sliderItem = _context.SliderItems.Find(Id);
            if (sliderItem == null)
            {
                return NotFound("Not Found Service");
            }
            _context.SliderItems.Remove(sliderItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
