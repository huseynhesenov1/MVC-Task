namespace GameStore.DTOs.BasketDtos
{
    public class BasketDto
    {
       public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}
