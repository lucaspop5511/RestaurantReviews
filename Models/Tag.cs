using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RestaurantReviews.Models
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // relatie M:N cu ReviewTags
        public ICollection<ReviewTag>? ReviewTags { get; set; }
    }
}
