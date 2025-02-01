using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;

var builder = WebApplication.CreateBuilder(args);

// SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AllowAnonymousToFolder("/Restaurants");
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapFallbackToPage("/Index");

app.Run();
