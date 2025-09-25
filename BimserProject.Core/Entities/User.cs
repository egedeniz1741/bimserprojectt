using System.ComponentModel.DataAnnotations;

namespace BimserProject.Core.Entities
 
{
 public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Username { get; set; }


        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }


        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        public ICollection<WatchedFilm> WatchedFilms { get; set; }
    }
}
