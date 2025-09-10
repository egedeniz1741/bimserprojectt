using BimserProject.Core.Core.Interfaces.Repositories;
using BimserProject.Core.Core.Interfaces.Services;
using BimserProject.Core.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimserProject.Core.Core.DTOs;

namespace BimserProject.Business.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            return user;
        }

        public async Task<UserDto?> GetUserWithWatchedFilmsAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
               
                WatchedFilms = user.WatchedFilms?.Select(wf => new WatchedFilmSimpleDto
                {
                    FilmId = wf.FilmId,
                    WatchedAt = wf.WatchedAt,
                    Film = new FilmSimpleDto
                    {
                        Id = wf.Film.Id,
                        Title = wf.Film.Title,
                        Year = wf.Film.Year,
                        Director = wf.Film.Director
                    }
                }).ToList()
            };
        }
    }
}
