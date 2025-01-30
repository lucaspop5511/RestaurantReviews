using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Models;

namespace RestaurantReviews.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ReviewTag> ReviewTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definim relația M:N între Review și Tag
            modelBuilder.Entity<ReviewTag>()
                .HasOne(rt => rt.Review)
                .WithMany(r => r.ReviewTags)
                .HasForeignKey(rt => rt.ReviewID);

            modelBuilder.Entity<ReviewTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.ReviewTags)
                .HasForeignKey(rt => rt.TagID);

            modelBuilder.Entity<Tag>().HasData(
                new Tag { ID = 1, Name = "Friendly Staff" },
                new Tag { ID = 2, Name = "Fast Service" },
                new Tag { ID = 3, Name = "Cozy Atmosphere" },
                new Tag { ID = 4, Name = "Great Coffee" },
                new Tag { ID = 5, Name = "Affordable Prices" }
    );
        }
    }
}
