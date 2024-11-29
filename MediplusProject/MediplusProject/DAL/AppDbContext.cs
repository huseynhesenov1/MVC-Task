using MediplusProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MediplusProject.DAL
{
	public class AppDbContext:DbContext
	{
		
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<SliderItem> SliderItems { get; set; }
		public DbSet<Coursel> Coursels { get; set; }
		public DbSet<HomeCard> HomeCards { get; set; }
		public DbSet<Scores> Scores { get; set; }

	}
}
