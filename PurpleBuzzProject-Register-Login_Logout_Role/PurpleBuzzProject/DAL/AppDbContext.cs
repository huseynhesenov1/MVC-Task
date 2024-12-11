using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzProject.Models;

namespace PurpleBuzzProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options):base(options) { }
       
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<OurWork> OurWorks { get; set; }
        public DbSet<OurService> OurServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OurWork>()
                .HasOne(e => e.OurService)
                .WithMany(e => e.OurWorks)
                .HasForeignKey(e => e.OurServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
