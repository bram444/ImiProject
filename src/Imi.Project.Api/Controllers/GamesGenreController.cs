using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesGenreController : Controller
    {

        protected readonly IGameGenreService _gameGenresServices;

        public GamesGenreController(IGameGenreService gameGenresServices)
        {
            _gameGenresServices = gameGenresServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _gameGenresServices.ListAllAsync());
        }

        [HttpGet("{id}/games")]
        public async Task<IActionResult> GetByGamesId(Guid id)
        {
            return Ok(await _gameGenresServices.GetByGameIdAsync(id));
        }

        [HttpGet("{id}/genre")]
        public async Task<IActionResult> GetByGenreId(Guid id)
        {
            return Ok(await _gameGenresServices.GetByGenreIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(GameGenreResponseDto gameGenreResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _gameGenresServices.AddAsync(gameGenreResponseDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(GameGenreResponseDto gameGenreResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _gameGenresServices.DeleteAsync(gameGenreResponseDto));
        }

    }
}
