using BimserProject.Business.Services;
using BimserProject.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using BimserProject.Core.Core.Interfaces.Services;

namespace bimserproject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchedHistoryController : ControllerBase
    {
        private readonly IWatchHistoryService _watchedFilmService;

        public WatchedHistoryController(IWatchHistoryService watchedFilmService)
        {
            _watchedFilmService = watchedFilmService;
        }

        
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WatchedFilm>>> GetUserWatchedHistory(int userId)
        {
            var watchedFilms = await _watchedFilmService.GetUserWatchedFilmsAsync(userId);
            return Ok(watchedFilms);
        }

        
        [HttpPost]
        public async Task<ActionResult> MarkFilmAsWatched(int userId, int filmId)
        {
            await _watchedFilmService.MarkFilmAsWatchedAsync(userId, filmId);
            return Ok();
        }
    }
}
