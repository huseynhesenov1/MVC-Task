using Employe.Abstraction;
using Employe.DAL;
using Employe.DTOs.UserDTOs;
using Employe.Models;
using Employe.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Employe.Controllers;

public class AccountsController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEmailService _emailService;

    public AccountsController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _emailService = emailService;
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
        //EmailService emailService = new EmailService(_configuration);
        _emailService.SendEmail(user.Email);
        string userToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        string? url =Url.Action("ConfirmEmail","Accounts",new {UserId = user.Id, token = userToken},Request.Scheme);
        _emailService.SendEmailConfirm(user.Email, url);
        await _userManager.AddToRoleAsync(user, "User");



        await _signInManager.SignInAsync(user, isPersistent: true);

        return RedirectToAction(nameof(Login), "Accounts");
    }
    public async Task<IActionResult> ConfirmEmail(string UserId, string token)
    {
        AppUser? user = await _userManager.FindByIdAsync(UserId);
        if (user==null)
        {
            return BadRequest("propblem var");
        }
        var result = await _userManager.ConfirmEmailAsync(user,token);
        if (result.Succeeded)
        {
            return Ok("Confirmed Email");
        }
        return BadRequest("propblem var");

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
        if (!user.EmailConfirmed)
        {
            return BadRequest("please confirm your email");
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
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
    //}
    //public async Task<string> CreateAdmin()
    //{
    //    AppUser appUser = new AppUser();
    //    appUser.UserName = "SuperAdmin";
    //    appUser.Email = "instance@admin.com";
    //    appUser.FirstName = "Huseyn";
    //    appUser.LastName = "Hesenov";
    //    await _userManager.CreateAsync(appUser, "Admin123!");
    //    await _userManager.AddToRoleAsync(appUser,"Admin");
    //    return "salam";
    //}

    //public async Task<string> CreateManager()
    //{
    //    AppUser appUser = new AppUser();
    //    appUser.UserName = "Manager";
    //    appUser.Email = "instance@manager.com";
    //    appUser.FirstName = "Nuran";
    //    appUser.LastName = "Piriyev";
    //    await _userManager.CreateAsync(appUser, "Manager123!");
    //    await _userManager.AddToRoleAsync(appUser, "Manager");
    //    return "salam";
    //}
}
