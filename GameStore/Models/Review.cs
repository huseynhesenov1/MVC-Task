namespace GameStore.Models
{
	public class Review
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public Gamer Gamer { get; set; }
		public int GamerId { get; set; }
	}
}
