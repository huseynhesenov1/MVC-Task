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
        public IActionResult SOftDelete(int Id)
        {
            SliderItem? sliderItem = _context.SliderItems.Find(Id);
            if (sliderItem == null)
            {
                return NotFound("Not Found Service");
            }

            sliderItem.IsDeleted = true;

            //_context.SliderItems.Remove(sliderItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult HardDelete(int Id)
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

        public IActionResult Details(int Id)
        {
            SliderItem? sliderItem = _context.SliderItems.Find(Id);
            if (sliderItem == null)
            {
                return NotFound("Not Found Service");
            }

                return View(sliderItem);
        }
        public IActionResult Restore(int Id)
        {
            SliderItem? sliderItem = _context.SliderItems.Find(Id);
            if (sliderItem == null)
            {
                return NotFound("Not Found Service");
            }

            sliderItem.IsDeleted = false;

            //_context.SliderItems.Remove(sliderItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
