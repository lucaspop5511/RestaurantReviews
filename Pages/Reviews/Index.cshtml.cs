using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews.Pages.Reviews
{
    public class ReviewsIndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReviewsIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Review> Reviews { get; set; } = new List<Review>();

        public async Task OnGetAsync()
        {
            Reviews = await _context.Reviews
                .Include(r => r.Restaurant)
                .ToListAsync();
        }
    }
}
