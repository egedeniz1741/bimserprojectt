
using Microsoft.EntityFrameworkCore;
using BimserProject.Core.Interfaces.Repositories;
using BimserProject.Core.Entities;
using BimserProject.Data.contexts;

namespace BimserProject.Data.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
        .Include(u => u.WatchedFilms)
            .ThenInclude(wf => wf.Film)
        .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
           .Include(u => u.WatchedFilms)
           .ThenInclude(wf => wf.Film)
           .ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
