using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGamesController : Controller
    {
        protected readonly IUserGameService _userGameService;

        public UserGamesController(IUserGameService userGameService)
        {
            _userGameService = userGameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userGameService.ListAllAsync());
        }

        [HttpGet("{id}/games")]
        public async Task<IActionResult> GetByGamesId(Guid id)
        {
            return Ok(await _userGameService.GetByGameIdAsync(id));
        }

        [HttpGet("{id}/user")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            return Ok(await _userGameService.GetByUserIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserGameResponseDto userGameResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _userGameService.AddAsync(userGameResponseDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserGameResponseDto userGameResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _userGameService.DeleteAsync(userGameResponseDto));
        }
    }
}
