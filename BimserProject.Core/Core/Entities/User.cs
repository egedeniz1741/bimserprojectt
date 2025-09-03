namespace BimserProject.Core.Entities
 
{
 public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<WatchedFilm> WatchedFilms { get; set; }
    }
}
