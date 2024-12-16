using GameStore.DAL;
using GameStore.Models;
using GameStore.Utilities;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GameStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Manager")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Gamer> Gamers = _context.Gamers.ToList();
            return View(Gamers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateGameVM createGameVM)
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Modelstate Valid deyil");
            }
            if (createGameVM.Image == null)
            {
                return NotFound("Image nulldur");
            }
            if (!createGameVM.Image.CheckSize(3))
            {
                ModelState.AddModelError("Img", "Shekilin ölçüsü 3 Mb dan çox ola bilməz");
            }
            if (!createGameVM.Image.CheckType())
            {
                ModelState.AddModelError("Img", "Bu formata icaze yoxdur");
                return View(createGameVM);
            }


            createGameVM.Image.UpdloadImage(_webHostEnvironment.WebRootPath, "ImageUpload");

            string fileName = Path.GetFileNameWithoutExtension(createGameVM.Image.FileName);
            string extension = Path.GetExtension(createGameVM.Image.FileName);
            fileName = fileName + extension;


            Gamer gamer = new Gamer()
            {
                Title = createGameVM.Title,
                Description = createGameVM.Description,
                Price = createGameVM.Price,
                GamerId = createGameVM.GamerId,
                ImgPath = fileName,
                CreateDate = DateTime.Now
                
            };

            _context.Gamers.Add(gamer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index),"Home");
        }


        public IActionResult Update(int Id)
        {
            Gamer? updateGamer =  _context.Gamers.Find(Id);
            if (updateGamer == null)
            {
                return NotFound("Id i tapilmadi");
            }
            UpdateGameVM updateGameVM = new UpdateGameVM()
            {
                Id = Id,
                Title = updateGamer.Title,
                Description = updateGamer.Description,
                Price = updateGamer.Price,
                GamerId = updateGamer.GamerId,

            };
            return View(updateGameVM);
        }
        [HttpPost]
        public IActionResult Update(UpdateGameVM updateGameVM)
        {
           Gamer? updateGamer = _context.Gamers.FirstOrDefault(x=>x.Id == updateGameVM.Id);
            if (updateGamer == null)
            {
                return NotFound("Nulldi");
            }

            updateGamer.Title = updateGameVM.Title;
            updateGamer.Description = updateGameVM.Description;
            updateGamer.Id = updateGameVM.Id;
            updateGamer.GamerId = updateGameVM.GamerId;
            updateGamer.Price = updateGameVM.Price;
            updateGamer.UpdateDate = DateTime.Now;
            _context.Gamers.Update(updateGamer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult SoftDelete(int Id)
        {
           Gamer? gamer =  _context.Gamers.Find(Id);
            if (gamer == null)
            {
                return NotFound("null");
            }
            gamer.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Home");

        }
        public IActionResult Details(int Id)
        {
            Gamer? gamer = _context.Gamers.Find(Id);
            if (gamer == null)
            {
                return NotFound("null");
            }
            return View(gamer);
        }
        public IActionResult HardDelete(int Id)
        {
            Gamer? gamer = _context.Gamers.Find(Id);
            if (gamer == null)
            {
                return NotFound("null");
            }
            _context.Gamers.Remove(gamer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult Restore(int Id)
        {
            Gamer? gamer = _context.Gamers.Find(Id);
            if (gamer == null)
            {
                return NotFound("null");
            }
            gamer.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Details");
        }
    }
}
