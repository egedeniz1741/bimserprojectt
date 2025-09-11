using BimserProject.Business.Services;
using BimserProject.Core.Core.DTOs;
using BimserProject.Core.Core.Entities;
using BimserProject.Core.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace bimserproject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService,IAuthService authService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IAuthService _authService = authService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/watched")]
        public async Task<ActionResult<List<WatchedFilmSimpleDto>>> GetUserWatchedFilms(int id)
        {
            var user = await _userService.GetUserWithWatchedFilmsAsync(id);

            if (user == null || user.WatchedFilms == null)
            {
                return NotFound();
            }

            return Ok(user.WatchedFilms);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDTO request)
        {
            var user = await _userService.AuthenticateAsync(request.UserName, request.Password);

            if (user == null)
                return Unauthorized();

            var token = _authService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

    }
}
