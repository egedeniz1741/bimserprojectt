namespace bimserproject.Core.Entities
{
    public class WatchedFilm
    {
        public int UserId { get; set; }
        public User User { get; set; } 

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public DateTime WatchedAt { get; set; } = DateTime.UtcNow;
    }
}
