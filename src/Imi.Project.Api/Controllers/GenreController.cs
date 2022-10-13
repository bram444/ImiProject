using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        protected readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreRepository.ListAllAsync();
            var genreDto = genres.Select(g => new GenreResponseDto
            {
                Id = g.Id,
                Description = g.Description,
                Name = g.Name,
            });
            return Ok(genreDto);
        }
    }
}
