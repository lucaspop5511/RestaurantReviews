using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RestaurantReviews.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Selectarea unui restaurant este obligatorie.")]
        public int RestaurantID { get; set; }

        [ForeignKey("RestaurantID")]
        public Restaurant? Restaurant { get; set; }

        [Required(ErrorMessage = "Rating-ul este obligatoriu.")]
        [Range(1, 5, ErrorMessage = "Rating-ul trebuie să fie între 1 și 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comentariul este obligatoriu.")]
        [StringLength(500, ErrorMessage = "Comentariul nu poate depăși 500 de caractere.")]
        public string Comment { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;

        // Relație M:N cu ReviewTags
        public ICollection<ReviewTag>? ReviewTags { get; set; }
    }
}
