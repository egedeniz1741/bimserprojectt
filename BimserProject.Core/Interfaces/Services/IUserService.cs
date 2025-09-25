using BimserProject.Core.DTOs;
using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<User> AuthenticateAsync(string username, string password);

        Task<UserDto> GetUserWithWatchedFilmsAsync(Guid id);
    }
}
