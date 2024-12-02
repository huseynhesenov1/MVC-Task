using Employe.DAL;
using Employe.DTOs.UserDTOs;
using Employe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Employe.Controllers;

public class AccountsController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;


    public AccountsController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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


        await _signInManager.SignInAsync(user, isPersistent: true);

        return RedirectToAction(nameof(Login), "Accounts");
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
}
