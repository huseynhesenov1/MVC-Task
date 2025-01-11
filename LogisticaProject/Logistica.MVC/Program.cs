using LogisticaProject.BL.Profiles;
using LogisticaProject.BL.Services.Abstractions;
using LogisticaProject.BL.Services.Implementations;
using LogisticaProject.Core.Entities;
using LogisticaProject.DAL.Contexts;
using LogisticaProject.DAL.Repostories.Abstractions;
using LogisticaProject.DAL.Repostories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ITransportRepostory, TransportRepostory>();
builder.Services.AddScoped<ITransportTypeRepostory, TransportTypeRepostory>();
builder.Services.AddScoped<ITransportService, TransportService>();
builder.Services.AddAutoMapper(typeof(TransportProfile));
builder.Services.AddAutoMapper(typeof(AppUserProfile));
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseAuthentication();
app.UseAuthorization();
app.Run();