using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzProject.DAL;
using PurpleBuzzProject.Models;
using PurpleBuzzProject.ViewModels;

namespace PurpleBuzzProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurWorksController : Controller
    {
        private readonly AppDbContext _context;

        public OurWorksController(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.OurWorks.Include(o => o.OurService);
            return View(await appDbContext.ToListAsync());
        }


        //public IActionResult Delete(int Id)
        //{
        //   OurWork? deleteourWork = _context.OurWorks.Find(Id);
        //    if (deleteourWork == null)
        //    {
        //        return NotFound("NO such Works");
        //    }
            
            
        //        _context.OurWorks.Remove(deleteourWork);
        //        _context.SaveChanges();

          
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Update(int Id)
        {
          OurWork? ourwork =   _context.OurWorks.Find(Id);
            if (ourwork == null)
            {
                return NotFound("No Such Works");
            }
            return View(ourwork);
        }
        //[HttpPost]
        //public IActionResult Update(OurWork ourWork)
        //{
        //  OurWork? updateOurWork =  _context.OurWorks.AsNoTracking().FirstOrDefault(x=>x.Id==ourWork.Id);
        //    if (updateOurWork == null)
        //    {
        //        return NotFound("No Such Work");
        //    }

        //    _context.OurWorks.Update(ourWork);
        //    updateOurWork.UpdatedAt = DateTime.Now;
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Create()
        {
            ViewBag.OurServices = new SelectList(_context.OurServices, "Id", "Title");
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(OurWorkVM ourWorkVM)
        {
            if (ModelState.IsValid)
            {
                OurWork ourWork = new()
                {
                    ImgUrl = ourWorkVM.ImgUrl,
                    OurServiceId = ourWorkVM.OurServiceId,
                    Title = ourWorkVM.Title,
                    Description = ourWorkVM.Description,
                    CreatedAt = DateTime.Now,
                };
                _context.OurWorks.Add(ourWork);
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.OurServices = new SelectList(_context.OurServices, "Id", "Title");
            return View(ourWorkVM);
        }


       
        

       
       

        
    }
}
