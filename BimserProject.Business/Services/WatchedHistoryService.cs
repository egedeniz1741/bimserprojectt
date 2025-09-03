using BimserProject.Core.Core.Interfaces.Repositories;
using BimserProject.Core.Core.Interfaces.Services;
using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Business.Services
{
    public class WatchedFilmService : IWatchHistoryService
    {
        private readonly IWatchHistoryRepository _watchedFilmRepository;

        public WatchedFilmService(IWatchHistoryRepository watchedFilmRepository)
        {
            _watchedFilmRepository = watchedFilmRepository;
        }

        public async Task MarkFilmAsWatchedAsync(int userId, int filmId)
        {
            var watchedFilm = new WatchedFilm
            {
                UserId = userId,
                FilmId = filmId,
                WatchedAt = DateTime.UtcNow
            };
            await _watchedFilmRepository.AddAsync(watchedFilm);
        }

        public async Task<List<WatchedFilm>> GetUserWatchedFilmsAsync(int userId)
        {
            return await _watchedFilmRepository.GetByUserIdAsync(userId);
        }
    }
}
