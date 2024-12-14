namespace GameStore.ViewModels
{
	public class UpdateGameVM
	{
		public int Id { get; set; }
        public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int GamerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
