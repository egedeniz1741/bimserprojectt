using BimserProject.Business.Services;
using Microsoft.AspNetCore.Mvc;
using BimserProject.Core.Interfaces.Services;
using BimserProject.Core.Entities;

namespace bimserproject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchedHistoryController(IWatchHistoryService watchedFilmService) : ControllerBase
    {
        private readonly IWatchHistoryService _watchedFilmService = watchedFilmService;

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WatchedFilm>>> GetUserWatchedHistory(int userId)
        {
            var watchedFilms = await _watchedFilmService.GetUserWatchedFilmsAsync(userId);
            return Ok(watchedFilms);
        }


        [HttpPost("user/{userId}/film/{filmId}")]
        public async Task<ActionResult> MarkFilmAsWatched(int userId, int filmId)
        {
            await _watchedFilmService.MarkFilmAsWatchedAsync(userId, filmId);
            return Ok(new { message = "Film izlendi olarak işaretlendi" });
        }
    }
}
