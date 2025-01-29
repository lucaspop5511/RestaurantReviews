using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RestaurantReviews.Models
{
    public class Restaurant
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu!")]
        [StringLength(100, ErrorMessage = "Numele nu poate depăși 100 de caractere.")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string CuisineType { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
