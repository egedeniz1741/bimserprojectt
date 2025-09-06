using BimserProject.Core.Core.Entities;
using BimserProject.Core.Core.Interfaces.Repositories;
using BimserProject.Core.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Business.Services
{
    public class FilmService(IFilmRepository filmRepository) : IFilmService
    {
        private readonly IFilmRepository _filmRepository = filmRepository;

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await _filmRepository.GetByIdAsync(id);
        }

        public async Task<List<Film>> GetAllFilmAsync()
        {
            return await _filmRepository.GetAllAsync();
        }

        public async Task AddFilmAsync(Film film)
        {
            await _filmRepository.AddAsync(film);
        }

        public async Task UpdateFilmAsync(Film film)
        {
            await _filmRepository.UpdateAsync(film);
        }

        public async Task DeleteFilmAsync(int id)
        {
            await _filmRepository.DeleteAsync(id);
        }
    }
}
