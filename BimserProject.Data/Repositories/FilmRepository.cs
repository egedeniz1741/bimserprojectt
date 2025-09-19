
using Microsoft.EntityFrameworkCore;
using BimserProject.Core.Interfaces.Repositories;
using BimserProject.Core.Entities;
using BimserProject.Data.contexts;

namespace BimserProject.Data.Repositories
{

    public class FilmRepository(AppDbContext context) : IFilmRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Film?> GetByIdAsync(int id)
        {
            return await _context.Films
                .Include(f => f.WatchedByUsers)
                    .ThenInclude(w => w.User)  
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Film>> GetAllAsync()
        {
            return await _context.Films
                .Include(f => f.WatchedByUsers)
                    .ThenInclude(w => w.User)
                .ToListAsync();
        }

        public async Task AddAsync(Film film)
        {
            await _context.Films.AddAsync(film);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                await _context.SaveChangesAsync();
            }
        }
    }
}
