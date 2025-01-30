using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public SelectList Restaurants { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Review = await _context.Reviews.FindAsync(id);

            if (Review == null)
            {
                return NotFound();
            }

            Restaurants = new SelectList(await _context.Restaurants.ToListAsync(), "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Review).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
