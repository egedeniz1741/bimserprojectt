using BimserProject.Core.Core.DTOs;
using BimserProject.Core.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Core.Interfaces.Services
{
    public interface IFilmService
    {
        Task<Film> GetFilmByIdAsync(int id);
        Task<List<Film>> GetAllFilmAsync();
        Task AddFilmAsync(Film film);
        Task UpdateFilmAsync(Film film);
        Task DeleteFilmAsync(int id);
        Task<FilmDto> GetFilmWithWatchedUsersAsync(int id);
    }
}
