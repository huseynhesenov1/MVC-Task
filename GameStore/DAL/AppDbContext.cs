using GameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GameStore.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}