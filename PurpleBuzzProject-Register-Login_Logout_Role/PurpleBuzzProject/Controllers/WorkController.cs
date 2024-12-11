using Microsoft.AspNetCore.Mvc;
using PurpleBuzzProject.DAL;
using PurpleBuzzProject.Models;
using System;

namespace PurpleBuzzProject.Controllers
{
    public class WorkController : Controller
    {
        readonly AppDbContext _context;

        public WorkController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            OurWork ourwork1 = new OurWork()
            {
                Title= "Digital Marketing",
                Description= "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                            sed do eiusmod tempor incididunt ut labore et dolor.",
                ImgUrl= "our-work-01.jpg"
            };
            OurWork ourwork2 = new OurWork()
            {
                Title = "Corporate Branding",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                            sed do eiusmod tempor incididunt ut labore et dolor.",
                ImgUrl = "our-work-02.jpg"
            };
            OurWork ourwork3 = new OurWork()
            {
                Title = "Leading Digital Solution",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                            sed do eiusmod tempor incididunt ut labore et dolor.",
                ImgUrl = "our-work-03.jpg"
            };
            OurWork ourwork4 = new OurWork()
            {
                Title = "Smart Applications",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                            sed do eiusmod tempor incididunt ut labore et dolor.",
                ImgUrl = "our-work-04.jpg"
            };
            OurWork ourwork5 = new OurWork()
            {
                Title = "Corporate Stationary",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                            sed do eiusmod tempor incididunt ut labore et dolor.",
                ImgUrl = "our-work-05.jpg"
            };
            OurWork ourwork6 = new OurWork()
            {
                Title = "8 Financial Tips",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\n                            sed do eiusmod tempor incididunt ut labore et dolor.",
                ImgUrl = "our-work-06.jpg"
            };
            //_context.OurWorks.Add(ourwork1);
            //_context.OurWorks.Add(ourwork2);
            //_context.OurWorks.Add(ourwork3);
            //_context.OurWorks.Add(ourwork4);
            //_context.OurWorks.Add(ourwork5);
            //_context.OurWorks.Add(ourwork6);
            
           IEnumerable<OurWork> ourWorks = _context.OurWorks.ToList();
            _context.SaveChanges();

            return View(ourWorks);
        }
    }
}
