using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimserProject.Core.Core.Interfaces.Repositories;
using BimserProject.Data.Data.contexts;
using Microsoft.EntityFrameworkCore;

namespace BimserProject.Data.Data.Repositories
{
    public class WatchHistoryRepository(AppDbContext context) : IWatchHistoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(WatchedFilm watchedFilm)
        {
            await _context.WatchedFilms.AddAsync(watchedFilm);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WatchedFilm>> GetByUserIdAsync(int userId)
        {
            return await _context.WatchedFilms
                .Include(wf => wf.Film)
                .Include(wf => wf.User)
                .Where(wf => wf.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> HasUserWatchedFilmAsync(int userId, int filmId)
        {
            return await _context.WatchedFilms .AnyAsync(wf => wf.UserId == userId && wf.FilmId == filmId);
        }
    }
}
