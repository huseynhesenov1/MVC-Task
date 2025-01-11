using LogisticaProject.BL.DTOs;
using LogisticaProject.BL.Services.Abstractions;
using LogisticaProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Areas.Admin.Controllers;

[Area("Admin")]
//[Authorize(Roles = "Admin, Manager")]
public class HomeController : Controller
{
	private readonly ITransportService _transportService;
	public HomeController(ITransportService transportService)
	{
		_transportService = transportService;
	}
	public async Task<IActionResult> Index()
	{
		var res = await _transportService.GetAllAsync();
		return View(res);
	}
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Create(TransportDto transportDto)
	{
        if (!ModelState.IsValid)
        {
			return View(transportDto);
		}
        if (transportDto.Image == null)
        {
			return View(transportDto);
		}
        if (transportDto.Image.Length>2*1024*1024)
        {
			return BadRequest("hecmi coxdu");
		}
		string[] allowFormat = ["jpg", "jpeg", "png"];
		string extension = Path.GetExtension(transportDto.Image.FileName);
  //      foreach (var item in allowFormat)
  //      {
  //          if (item != extension)
  //          {
		//		return BadRequest("format duz deyil coxdu");
		//	}
		//}
        await _transportService.CreateAsync(transportDto);
		return RedirectToAction("Index", "Home");
	}
	public async Task<IActionResult> Update(int id)
	{
		Transport transport = await _transportService.GetByIdAsync(id);
		return View(transport);
	}
	[HttpPost]
	public async Task<IActionResult> Update(int id, TransportDto transportDto)
	{
		await _transportService.UpdateAsync(id, transportDto);
		return RedirectToAction("Index", "Home");
	}

	public async Task<IActionResult> SoftDelete(int id)
	{
		await _transportService.SoftDeleteAsync(id);
		return RedirectToAction("Index", "Home");
	}
}
