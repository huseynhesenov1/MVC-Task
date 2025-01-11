using LogisticaProject.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogisticaProject.DAL.Contexts;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions opt):base(opt) { } 
    
    public DbSet<TransportType> TransportTypes { get; set; }
    public DbSet<Transport> Transports { get; set; }

}
