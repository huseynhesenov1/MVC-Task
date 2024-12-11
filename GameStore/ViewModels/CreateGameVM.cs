using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels
{
    public class CreateGameVM
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int GamerId { get; set; }
        public IFormFile Image { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
