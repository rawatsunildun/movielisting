using System.ComponentModel.DataAnnotations;

namespace movielisting.Models
{
    public class Film
    {
        [Required]
        public string ReleaseYear { get; set; }

        [Required]
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Movie name cannot exceed 50 characters.")]
        public string MovieName { get; set; }
    }
}
