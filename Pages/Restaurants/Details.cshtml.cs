using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Restaurant = await _context.Restaurants.FindAsync(id);

            if (Restaurant == null)
            {
                return NotFound();
            }

            Reviews = await _context.Reviews
                .Where(r => r.RestaurantID == id)
                .Include(r => r.ReviewTags)
                .ThenInclude(rt => rt.Tag)
                .ToListAsync();

            return Page();
        }
    }
}
