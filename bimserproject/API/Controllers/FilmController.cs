using BimserProject.Core.Core.Entities;
using BimserProject.Core.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetFilmById(int id)
        {
            var film = await _filmService.GetFilmByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpPost]

         public async Task<ActionResult<Film>> PostFilm(Film film)
         {
            if (film == null)
            {
                return BadRequest();
            }
            await _filmService.AddFilmAsync(film);
            return CreatedAtAction(nameof(GetFilmById), new { id = film.Id }, film);
         }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
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
