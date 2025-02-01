using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews.Pages.Restaurants
{
    public class RestaurantsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RestaurantsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

        public async Task OnGetAsync()
        {
            Restaurants = await _context.Restaurants.ToListAsync();
        }
    }
}
