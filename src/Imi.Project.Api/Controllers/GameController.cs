using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        protected readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameRepository.ListAllAsync();
            var gameDto = games.Select(g => new GameResponseDto
            {
                Id = g.Id,
                Name = g.Name,
                Price = g.Price,
            });

            return Ok(gameDto);
        }
    }
}
