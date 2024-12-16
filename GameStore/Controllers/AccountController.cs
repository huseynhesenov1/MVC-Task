using GameStore.DAL;
using GameStore.DTOs.User;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            AppUser user = new AppUser();
            user.UserName = userDto.UserName;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);  
            }

            AppUser? user = await _userManager.FindByEmailAsync(loginDto.UserNameOrEmail);
            if (user == null)
            {
               user = await _userManager.FindByNameAsync(loginDto.UserNameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "UserName or Password is IncOrrect");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.Ispersistant, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "UserName or Password is IncOrrect");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}