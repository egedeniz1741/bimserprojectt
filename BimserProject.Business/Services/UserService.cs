
using BimserProject.Core.DTOs;
using BimserProject.Core.Interfaces.Repositories;
using BimserProject.Core.Interfaces.Services;
using BimserProject.Core.Entities;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BimserProject.Business.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task AddUserAsync(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        public async Task<UserDto?> GetUserWithWatchedFilmsAsync(Guid id)
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
