using BimserProject.Core.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BimserProject.Core.Core.Entities
 
{
 public class User
    {
        public int Id { get; set; }

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
