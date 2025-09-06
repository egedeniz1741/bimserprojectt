using BimserProject.Core.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimserProject.Data.Data.contexts;
using Microsoft.EntityFrameworkCore;
using BimserProject.Core.Core.Entities;

namespace BimserProject.Data.Data.Repositories
{
    public class FilmRepository(AppDbContext context) : IFilmRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Film?> GetByIdAsync(int id)
        {
            return await _context.Films.FindAsync(id);
        }

        public async Task<List<Film>> GetAllAsync()
        {
            return await _context.Films.ToListAsync();
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
