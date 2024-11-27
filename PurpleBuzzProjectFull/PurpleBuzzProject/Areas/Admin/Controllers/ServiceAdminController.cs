using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzProject.DAL;
using PurpleBuzzProject.Models;

namespace PurpleBuzzProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceAdminController : Controller
    {
        readonly AppDbContext _context;

        public ServiceAdminController(AppDbContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            IEnumerable<OurService> ourServices =  _context.OurServices.ToList();
            return View(ourServices);
        }
        public IActionResult Delete(int Id)
        {
            OurService? deleteOurWork = _context.OurServices.Find(Id);
            if (deleteOurWork == null)
            {
                return NotFound();
            }
            else
            {
                _context.OurServices.Remove(deleteOurWork);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(OurService ourService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("smth went wrong");
            }
            else
            {
                _context.OurServices.Add(ourService);
                _context.SaveChanges();
            }

            
            return RedirectToAction(nameof(Index));
        }
        //burda update'in get sorgusu aparilir
        public IActionResult Update(int Id)
        {
           OurService? ourService = _context.OurServices.Find(Id);
            if (ourService == null)
            {
                return NotFound("No such Service");
            }

            return View(ourService);
        }
        [HttpPost]
        public IActionResult Update(OurService ourservice)
        {
          OurService? updateOurservice = _context.OurServices.AsNoTracking().FirstOrDefault(x=>x.Id == ourservice.Id);
            if (updateOurservice == null)
            {
                return NotFound("No Such Service");
            }
            _context.OurServices.Update(ourservice);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
