using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tag> Tags { get; set; } = new List<Tag>();

        public async Task OnGetAsync()
        {
            Tags = await _context.Tags.ToListAsync();
        }
    }
}
