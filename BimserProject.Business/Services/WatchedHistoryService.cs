using BimserProject.Core.DTOs;
using BimserProject.Core.Entities;
using BimserProject.Core.Interfaces.Repositories;
using BimserProject.Core.Interfaces.Services;



namespace BimserProject.Business.Services
{
    public class WatchedFilmService(IWatchHistoryRepository watchedFilmRepository, IUserRepository userRepository) : IWatchHistoryService
    {
        private readonly IWatchHistoryRepository _watchedFilmRepository = watchedFilmRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task MarkFilmAsWatchedAsync(int userId, int filmId)
        {
            var alreadyWatched = await _watchedFilmRepository.HasUserWatchedFilmAsync(userId, filmId);

            if (!alreadyWatched)
            {
                var watchedFilm = new WatchedFilm
                {
                    UserId = userId,
                    FilmId = filmId,
                    WatchedAt = DateTime.UtcNow
                };
                await _watchedFilmRepository.AddAsync(watchedFilm);
            }
        }

        public async Task<List<WatchedFilm>> GetUserWatchedFilmsAsync(int userId)
        {
            return await _watchedFilmRepository.GetByUserIdAsync(userId);
        }

        public async Task<UserWatchedFilmsDto> GetUserWatchedFilmsWithDetailsAsync(int userId)
        {
            var watchedFilms = await _watchedFilmRepository.GetByUserIdAsync(userId);
            var user = await _userRepository.GetByIdAsync(userId);

            return user == null
                ? throw new Exception("User not found")
                : new UserWatchedFilmsDto
            {
                UserId = user.Id,
                Username = user.Username,
                WatchedFilms = [.. watchedFilms.Select(wf => new WatchedFilmDetailDto
                {
                    FilmId = wf.FilmId,
                    FilmTitle = wf.Film.Title,
                    FilmYear = wf.Film.Year,
                    FilmDirector = wf.Film.Director,
                    WatchedAt = wf.WatchedAt
                })]
            };
        }
    }
}