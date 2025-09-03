namespace BimserProject.Core.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }

        public ICollection<WatchedFilm> WatchedByUsers { get; set; }
    }
}
