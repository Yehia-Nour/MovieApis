

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var geners = await _genresService.GetAllAsync();
            return Ok(geners);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(GenreDto dto)
        {
            var genre =  await _genresService.CreateAsync(dto);
            return Ok(genre);
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] GenreDto dto)
        {
            var genre = await _genresService.UpdateAsync(id, dto);
            if (genre == null)
                return NotFound($"Genre with ID {id} not found.");

            return Ok(genre);
        }

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = await _genresService.DeleteAsync(id);
            if (genre == null)
                return NotFound($"Genre with ID {id} not found.");

            return Ok(genre);
        }
    }
}
