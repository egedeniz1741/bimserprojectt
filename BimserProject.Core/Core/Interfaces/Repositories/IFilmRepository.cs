using BimserProject.Core.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Core.Interfaces.Repositories
{
    public interface IFilmRepository
    {
        Task<Film> GetByIdAsync(int id);
        Task<List<Film>> GetAllAsync();
        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(int id);
    }
}
