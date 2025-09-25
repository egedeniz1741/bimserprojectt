

namespace BimserProject.Core.DTOs
{
    public class UserWatchedFilmsDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public List<WatchedFilmDetailDto> WatchedFilms { get; set; }
    }

    public class WatchedFilmDetailDto
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public int FilmYear { get; set; }
        public string FilmDirector { get; set; }
        public DateTime WatchedAt { get; set; }
    }
}
