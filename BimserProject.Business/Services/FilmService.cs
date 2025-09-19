using BimserProject.Core.DTOs;
using BimserProject.Core.Entities;
using BimserProject.Core.Interfaces.Repositories;
using BimserProject.Core.Interfaces.Services;


namespace BimserProject.Business.Services
{
    public class FilmService(IFilmRepository filmRepository) : IFilmService
    {
        private readonly IFilmRepository _filmRepository = filmRepository;

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await _filmRepository.GetByIdAsync(id);
        }

        public async Task<List<Film>> GetAllFilmAsync()
        {
            return await _filmRepository.GetAllAsync();
        }

        public async Task AddFilmAsync(Film film)
        {
            await _filmRepository.AddAsync(film);
        }

        public async Task UpdateFilmAsync(Film film)
        {
            await _filmRepository.UpdateAsync(film);
        }

        public async Task DeleteFilmAsync(int id)
        {
            await _filmRepository.DeleteAsync(id);
        }

        public async Task<FilmDto?> GetFilmWithWatchedUsersAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);

            if (film == null)
                return null;

            return new FilmDto
            {
                Id = film.Id,
                Title = film.Title,
                Year = film.Year,
                Director = film.Director,

                WatchedByUsers = film.WatchedByUsers?.Select(w => new WatchedByUserDto
                {
                    UserId = w.UserId,
                    UserName = w.User.Username
                }).ToList()
            };
        }
    }
}
