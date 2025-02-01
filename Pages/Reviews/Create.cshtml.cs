using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RestaurantReviews.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public SelectList Restaurants { get; set; }

        // proprietatea pentru lista de etichete disponibile
        public List<Tag> Tags { get; set; } = new List<Tag>();

        // proprietatea pentru etichetele selectate de utilizator
        [BindProperty]
        public List<int> SelectedTags { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync()
        {
            Restaurants = new SelectList(await _context.Restaurants.ToListAsync(), "ID", "Name");
            Tags = await _context.Tags.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Restaurants = new SelectList(await _context.Restaurants.ToListAsync(), "ID", "Name");
                Tags = await _context.Tags.ToListAsync();
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            // salvam etichetele asociate recenziei in `ReviewTags`
            foreach (var tagId in SelectedTags)
            {
                _context.ReviewTags.Add(new ReviewTag { ReviewID = Review.ID, TagID = tagId });
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
