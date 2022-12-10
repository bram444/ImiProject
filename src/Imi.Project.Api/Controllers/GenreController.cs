using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController: ControllerBase
    {
        protected readonly IGenreService _genreService;
        protected readonly IGameGenreService _gameGenreService;

        public GenreController(IGenreService genreService, IGameGenreService gameGenreService)
        {
            _genreService = genreService;
            _gameGenreService = gameGenreService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genreService.ListAllAsync());
        }

        [HttpGet("{search}/genre")]
        public async Task<IActionResult> GetByName(string search)
        {
            return Ok(await _genreService.SearchAsync(search));
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreResponseDto genreResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genreService.AddAsync(genreResponseDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(GenreResponseDto genreResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genreService.UpdateAsync(genreResponseDto));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            foreach(GameGenreResponseDto gg in await _gameGenreService.GetByGenreIdAsync(id))
            {
                await _gameGenreService.DeleteAsync(gg);
            }

            return Ok(await _genreService.DeleteAsync(id));
        }
    }
}