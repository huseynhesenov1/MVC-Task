using GameStore.Models;

namespace GameStore.DTOs.BasketDtos
{
	public class BasketItemDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public string ImgPath { get; set; }
		public int Quantity { get; set; }


	}
}
