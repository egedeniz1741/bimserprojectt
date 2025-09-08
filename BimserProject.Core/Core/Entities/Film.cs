using System.ComponentModel.DataAnnotations;

namespace BimserProject.Core.Core.Entities
{
    public class Film
    {

        public int Id { get; set; } 
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }


        public ICollection<WatchedFilm> WatchedByUsers { get; set; }
    }
}
