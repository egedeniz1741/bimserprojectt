using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BimserProject.Core.Core.DTOs
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
      

        [JsonIgnore] 
        public List<WatchedByUserDto> WatchedByUsers { get; set; }
    }

    public class WatchedByUserDto
    {
        public int UserId { get; set; }
        public DateTime WatchedAt { get; set; }
        public UserInfoDto User { get; set; }
    }

    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
