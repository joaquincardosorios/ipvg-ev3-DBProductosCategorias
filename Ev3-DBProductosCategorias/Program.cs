using Microsoft.EntityFrameworkCore;
using Ev3_DBProductosCategorias.Models;

var builder = WebApplication.CreateBuilder(args);

var SupermercadoCS = builder.Configuration.GetConnectionString("SuperMercadoCS");

builder.Services.AddDbContext<SupermercadoContext>(options => options.UseSqlServer(SupermercadoCS));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
