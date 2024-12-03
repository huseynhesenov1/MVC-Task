using MediplusProject.DAL;
using MediplusProject.Models;
using MediplusProject.ViewModels;
using MediplusProject.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace MediplusProject.Controllers;

public class HomeController : Controller
{

    readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<SliderItem> sliderItems =  _context.SliderItems.ToList();
        List<Coursel> coursels = _context.Coursels.ToList();
        List<HomeCard> homeCards = _context.HomeCards.ToList();
        List<Scores> scores = _context.Scores.ToList();
        HomeVM homeVM = new HomeVM()
        {
            sliderItems = sliderItems,
            coursels = coursels,
            homeCards = homeCards,
            scores = scores
        };
        return View(homeVM);
    }
}