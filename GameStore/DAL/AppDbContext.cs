using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GameStore.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Gamer> Gamers { get; set; }
    }
}
