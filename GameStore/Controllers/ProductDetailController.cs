using GameStore.DAL;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
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
            return View(gamer);
        }
    }
}
