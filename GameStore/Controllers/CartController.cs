using GameStore.DAL;
using GameStore.DTOs.BasketDtos;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace GameStore.Controllers
{
	public class CartController : Controller
	{
		private readonly AppDbContext _context;

		public CartController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AddToBasket(int productId)
		{
			Gamer? gamer = _context.Gamers.Find(productId);
			if (gamer == null)
			{
				return NotFound("tapilmadi");
			}
			var cookieOption = new CookieOptions()
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true
			};
			BasketItemDto basketItemDto = new BasketItemDto()
			{
				Title = gamer.Title,
				Price = gamer.Price,
				Quantity = 1
			};

			var baksetItem =  JsonConvert.SerializeObject(basketItemDto);
			Response.Cookies.Append("BasketItem" , baksetItem , cookieOption);
			
			return Ok(baksetItem);
		}
		public IActionResult GetBasket()
		{
			var basketItemDto = Request.Cookies["BasketItem"];
			return Ok(basketItemDto);
		}
	}
}
