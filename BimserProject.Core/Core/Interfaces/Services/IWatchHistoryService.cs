using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Core.Interfaces.Services
{
    public interface IWatchHistoryService
    {
        Task MarkFilmAsWatchedAsync(int userId, int filmId);
        Task<List<WatchedFilm>> GetUserWatchedFilmsAsync(int userId);

    }
}
