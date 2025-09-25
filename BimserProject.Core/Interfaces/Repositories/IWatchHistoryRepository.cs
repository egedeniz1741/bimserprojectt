using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Interfaces.Repositories
{
    public interface IWatchHistoryRepository
    {
        Task AddAsync(WatchedFilm watchedFilm);
        Task<List<WatchedFilm>> GetByUserIdAsync(Guid userId);
        Task<bool> HasUserWatchedFilmAsync(Guid userId, int filmId);
    }
}
