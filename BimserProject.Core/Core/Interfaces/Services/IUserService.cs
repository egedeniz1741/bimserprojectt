using BimserProject.Core.Core.DTOs;
using BimserProject.Core.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> AuthenticateAsync(string username, string password);

        Task<UserDto> GetUserWithWatchedFilmsAsync(int id);
    }
}
