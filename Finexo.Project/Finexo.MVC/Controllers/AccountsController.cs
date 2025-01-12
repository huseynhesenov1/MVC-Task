using Finexo.BL.DTOs;
using Finexo.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finexo.MVC.Controllers
{
	public class AccountsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		

		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(AppUserDto appUserDto)
		{
			if (!ModelState.IsValid)
			{
				return View(appUserDto);
			}
			if (appUserDto.Password != appUserDto.ConfirmPassword)
			{
				return View(appUserDto);

			}
			AppUser user = new AppUser();
			user.UserName = appUserDto.UserName;
			user.LastName = appUserDto.LastName;
			user.FirstName = appUserDto.FirstName;
			user.Email = appUserDto.Email;

			var res = await _userManager.CreateAsync(user, appUserDto.Password);

			foreach (var item in res.Errors)
			{
				ModelState.AddModelError(item.Code, item.Description);
			}
			return RedirectToAction("Login", "Accounts");
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
			var res = await _signInManager.PasswordSignInAsync(user, appUserLoginDto.Password, true, true);
			if (!res.Succeeded)
			{
				ModelState.AddModelError(string.Empty, "Password or Username is wrong");
				return View();
			}

			return RedirectToAction("Index", "Home");

		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		//public async Task CreateRole()
		//{
		//	await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
		//	await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
		//	await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
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
