
using Microsoft.EntityFrameworkCore;
using BimserProject.Core.Interfaces.Repositories;
using BimserProject.Core.Entities;
using BimserProject.Data.contexts;

namespace BimserProject.Data.Repositories
{
    public class WatchHistoryRepository(AppDbContext context) : IWatchHistoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(WatchedFilm watchedFilm)
        {
            await _context.WatchedFilms.AddAsync(watchedFilm);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WatchedFilm>> GetByUserIdAsync(Guid userId)
        {
            return await _context.WatchedFilms
                .Include(wf => wf.Film)
                .Include(wf => wf.User)
                .Where(wf => wf.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> HasUserWatchedFilmAsync(Guid userId, int filmId)
        {
            return await _context.WatchedFilms .AnyAsync(wf => wf.UserId == userId && wf.FilmId == filmId);
        }
    }
}
