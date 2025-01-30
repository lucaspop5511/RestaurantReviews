using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReviews.Models
{
    public class ReviewTag
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ReviewID { get; set; }

        [ForeignKey("ReviewID")]
        public Review? Review { get; set; }

        [Required]
        public int TagID { get; set; }

        [ForeignKey("TagID")]
        public Tag? Tag { get; set; }
    }
}
