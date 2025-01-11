using AutoMapper;
using LogisticaProject.BL.DTOs;
using LogisticaProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_mapper = mapper;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(AppUserCreateDto appUserCreateDto)
		{
			if (!ModelState.IsValid)
			{
				return View(appUserCreateDto);
			}
			if (appUserCreateDto.ConfirmPassword != appUserCreateDto.Password)
			{
				return View(appUserCreateDto);
			}
			AppUser user = _mapper.Map<AppUser>(appUserCreateDto);

			var result = await _userManager.CreateAsync(user, appUserCreateDto.Password);
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
		public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
		{
			if (!ModelState.IsValid)
			{
				return View(appUserLoginDto);
			}
			AppUser? user = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
			if (user == null)
			{
				ModelState.AddModelError(string.Empty, "Password or Username is wrong");
				return View();
			}
			var res = await _signInManager.PasswordSignInAsync(user, appUserLoginDto.Password, appUserLoginDto.IsPersistant , true);
            if (!res.Succeeded)
            {
				ModelState.AddModelError(string.Empty, "Password or Username is wrong");
				return View();
			}
			await _userManager.AddToRoleAsync(user, "User");

			return RedirectToAction("Index", "Home");
		}
        public async Task<IActionResult> Logout()
        {
			await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
		//public async Task CreateRole()
		//{
		//	 await	_roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
		//	 await	_roleManager.CreateAsync(new IdentityRole { Name = "User" });
		//	 await	_roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
		//}
		//public async Task CreateAdmin()
		//{
		//	AppUser appUser = new AppUser();
		//	appUser.FirstName = "Admin";
		//	appUser.LastName = "Admin";
		//	appUser.UserName = "admin";
		//	appUser.Email = "admin12@admin.com";
		//	await _userManager.CreateAsync(appUser, "Admin123!");
		//	await _userManager.AddToRoleAsync(appUser, "Admin");
		//}
		//public async Task CreateManager()
		//{
		//	AppUser appUser = new AppUser();
		//	appUser.FirstName = "Manager";
		//	appUser.LastName = "Manager";
		//	appUser.UserName = "Manager";
		//	appUser.Email = "manager12@manager.com";
		//	await _userManager.CreateAsync(appUser, "Manager123!");
		//	await _userManager.AddToRoleAsync(appUser, "Manager");
		//}
	}
}