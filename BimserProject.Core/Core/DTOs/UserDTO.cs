using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BimserProject.Core.Core.DTOs
{

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<WatchedFilmSimpleDto> WatchedFilms { get; set; }
    }

    public class WatchedFilmSimpleDto
    {
        public int FilmId { get; set; }
        public DateTime WatchedAt { get; set; }
        public FilmSimpleDto Film { get; set; }
    }

    public class FilmSimpleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
    }
}
