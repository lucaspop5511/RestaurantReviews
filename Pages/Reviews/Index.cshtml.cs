using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Review> Reviews { get; set; } = new List<Review>();

        public async Task OnGetAsync()
        {
            Reviews = await _context.Reviews
                .Include(r => r.Restaurant)
                .Include(r => r.ReviewTags)  // ✅ Include relația cu etichetele
                .ThenInclude(rt => rt.Tag)   // ✅ Include numele etichetelor
                .ToListAsync();
        }
    }
}
