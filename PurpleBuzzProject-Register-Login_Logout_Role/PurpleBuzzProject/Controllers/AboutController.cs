using Microsoft.AspNetCore.Mvc;
using PurpleBuzzProject.DAL;
using PurpleBuzzProject.Models;

namespace PurpleBuzzProject.Controllers
{
    public class AboutController : Controller
    {
        readonly AppDbContext _context;

        public AboutController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            OurTeam ourTeam1 = new OurTeam()
            {
               
                Name= "John Doe",
                Title= "Business Development",
                MainImageUrl= "team-01.jpg"

            };
            OurTeam ourTeam2 = new OurTeam()
            {
                
                Name = "Jane Doe",
                Title = "Media Development",
                MainImageUrl = "team-02.jpg"

            };
            OurTeam ourTeam3 = new OurTeam()
            {
                
                Name = "Sam",
                Title = "Development",
                MainImageUrl = "team-03.jpg"

            };
            // elave etmek ucun komentden cixarin , her defe run edende add etmesin deye koment etdim
            //_context.OurTeams.Add(ourTeam1);
            //_context.OurTeams.Add(ourTeam2);
            //_context.OurTeams.Add(ourTeam3);
            IEnumerable<OurTeam> ourteams = _context.OurTeams.ToList();
            _context.SaveChanges();


            return View(ourteams);
        }
    }
}
