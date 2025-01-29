using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReviews.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        [ForeignKey("RestaurantID")]
        public Restaurant? Restaurant { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
