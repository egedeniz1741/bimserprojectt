

namespace BimserProject.Core.DTOs
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
      

      
        public List<WatchedByUserDto> WatchedByUsers { get; set; }
    }

    public class WatchedByUserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        public DateTime WatchedAt { get; set; }
       
    }

    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
