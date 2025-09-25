using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Interfaces.Services
{
    public interface IWatchHistoryService
    {
        Task MarkFilmAsWatchedAsync(Guid userId, int filmId);
        Task<List<WatchedFilm>> GetUserWatchedFilmsAsync(Guid userId);

    }
}
