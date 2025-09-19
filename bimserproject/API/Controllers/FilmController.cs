using Microsoft.AspNetCore.Mvc;
using BimserProject.Core.DTOs;
using BimserProject.Core.Interfaces.Services;
using BimserProject.Core.Entities;

namespace bimserproject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController(IFilmService filmService) : Controller
    {
        private readonly IFilmService _filmService = filmService;

        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmService.GetAllFilmAsync();
            return Ok(films);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDto>> GetFilm(int id)
        {
            var film = await _filmService.GetFilmWithWatchedUsersAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        [HttpPost]

         public async Task<ActionResult<Film>> PostFilm(Film film)
         {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _filmService.AddFilmAsync(film);
            return CreatedAtAction(nameof(GetFilm), new { id = film.Id }, film);
         }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != film.Id)
            {
                return BadRequest();
            }

            await _filmService.UpdateFilmAsync(film);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            await _filmService.DeleteFilmAsync(id);
            return NoContent();
        }

    }
}
