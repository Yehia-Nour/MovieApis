using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;

        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;
        public MoviesController(IMoviesService moviesService, IGenresService genresService)
        {
            _moviesService = moviesService;
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _moviesService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreIdAsync(int genreId)
        {
            var isValidGenre = await _genresService.IsvalidGenre(genreId);
            if (!isValidGenre)
                return BadRequest("Invalid genere ID!");

            var movies = await _moviesService.GetAllAsync(genreId);
            return Ok(movies);
        }

        [HttpGet(template:"{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie = await _moviesService.GetByIdAsync(id);
            if (movie == null)
                return NotFound($"Movie with ID {id} not found.");
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]MovieDto dto)
        {
            if (dto.Poster == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (dto.Poster.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB!");

            var isValidGenre = await _genresService.IsvalidGenre(dto.GenreId);
            if (!isValidGenre)
                return BadRequest("Invalid genere ID!");

            var movie = await _moviesService.CreateAsync(dto);
            return Ok(movie);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] MovieDto dto)
        {
            var movie = await _moviesService.GetByIdAsync(id);
            if (movie == null)
                return NotFound($"Movie with ID {id} not found.");

            var isValidGenre = await _genresService.IsvalidGenre(dto.GenreId);
            if (!isValidGenre)
                return BadRequest("Invalid genere ID!");

            if (dto.Poster != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (dto.Poster.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");
            }

            var movieUpdated = await _moviesService.UpdateAsync(id, dto);
            return Ok(movieUpdated);
        }

        [HttpDelete(template:"{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = await _moviesService.DeleteAsync(id);
            if (movie == null)
                return NotFound($"Genre with ID {id} not found.");
            return Ok(movie);
        }
    }
}
