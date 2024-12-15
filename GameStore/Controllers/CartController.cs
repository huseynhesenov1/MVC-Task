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
			BasketDto basket = GetBasket();
			return View(basket);
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
			BasketDto basket = GetBasket();

            if (basket == null)
            {
				basket = new BasketDto();
            }
			BasketItemDto? existingBasketItem  = basket.Items.FirstOrDefault(g => g.GamerId == gamer.Id);
            if (existingBasketItem == null)
            {

            BasketItemDto basketItemDto = new BasketItemDto()
			{
				Description = gamer.Description,
				ImgPath = gamer.ImgPath,
				GamerId = gamer.Id,
				Title = gamer.Title,
				Price = gamer.Price,
				Quantity = 1
			};
            basket.Items.Add(basketItemDto);
			}
			else
			{
				existingBasketItem.Quantity += 1;

			}

			var cookieBasket =  JsonConvert.SerializeObject(basket);
			Response.Cookies.Append("Basket" , cookieBasket, cookieOption);
			
			
			return Ok();
		}
		public BasketDto GetBasket()
		{
			var basket = Request.Cookies["Basket"];
			if (basket != null)
			{
				BasketDto? existingBasket = JsonConvert.DeserializeObject<BasketDto>(basket);
				return existingBasket;

            }
			return null;
		}
	}
}
