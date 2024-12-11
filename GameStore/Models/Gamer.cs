namespace GameStore.Models
{
    public class Gamer
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int GamerId { get; set; }
        //public IFormFile Image { get; set; }
        public string ImgPath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
