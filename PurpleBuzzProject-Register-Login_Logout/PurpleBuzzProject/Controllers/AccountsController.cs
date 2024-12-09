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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public AccountsController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;


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
            await _userManager.AddToRoleAsync(user, "User");

            await _signInManager.SignInAsync(user, isPersistent: true);

            return RedirectToAction("Login", "Accounts");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            AppUser? user = await _userManager.FindByNameAsync(loginUserDto.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginUserDto.EmailOrUsername);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, loginUserDto.Ispersistant, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        //public async Task CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin"});
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        //}

        //public async Task CreateAdmin()
        //{
        //    AppUser appUser = new AppUser();
        //    appUser.UserName = "Admin";
        //    appUser.FirstName = "HuseynH";
        //    appUser.LastName = "HesenovH";
        //    appUser.Email = "admin@purplebuzz.com";
        //   await _userManager.CreateAsync(appUser, "Admin123!");
        //    await _userManager.AddToRoleAsync(appUser, "Admin");

        //}


        //public async Task CreateManager()
        //{
        //    AppUser appUser = new AppUser();
        //    appUser.UserName = "Manager";
        //    appUser.FirstName = "HesenH";
        //    appUser.LastName = "HesenovH";
        //    appUser.Email = "manager@purplebuzz.com";
        //    await _userManager.CreateAsync(appUser, "Manager123!");
        //   await _userManager.AddToRoleAsync(appUser, "Manager");

        //}
    }
}
