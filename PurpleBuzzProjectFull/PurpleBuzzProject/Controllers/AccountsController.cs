using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzProject.DAL;
using PurpleBuzzProject.DTOs.UserDTOs;
using PurpleBuzzProject.Models;

namespace PurpleBuzzProject.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
       
        public AccountsController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
             _appDbContext = appDbContext;
             _userManager = userManager;

        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createUserDto);
            }
            AppUser user = new AppUser();
            user.FirstName = createUserDto.FirstName;
            user.LastName = createUserDto.LastName;
            user.Email = createUserDto.Email;
            user.UserName = createUserDto.Username;
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(createUserDto);
            }
            return RedirectToAction("Index","Home");
        }
    }
}
