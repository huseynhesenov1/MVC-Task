using GameStore.DAL;
using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

public class ProductDetailController : Controller
{
    private readonly AppDbContext _context;
    public ProductDetailController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    { 
       
        return View();
    }
    public IActionResult Detail(int Id)
    {
        Gamer gamer = _context.Gamers.Find(Id);
        ViewBag.Gamer = gamer;
        return View();
    }
    public IActionResult Create()
    {
        List<Review> review = _context.Reviews.ToList();
        
        return View(review);
    }
    [HttpPost]
    public IActionResult Create(CreateReviewVM createReviewVM)
    {
        
        if (!ModelState.IsValid)
        {
            return NotFound("nulldu");
        }
        //Gamer? game = _context.Gamers.FirstOrDefault(g => g.Id == createReviewVM.GamerId);
        Review review = new Review()
        {
            Comment = createReviewVM.Comment,
            GamerId = createReviewVM.GamerId,
        };
        _context.Reviews.Add(review);
        _context.SaveChanges();
        return RedirectToAction("Index","Home");
    }
}
