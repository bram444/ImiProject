using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserService _userService;
        protected readonly IUserGameService _userGameService;

        public UserController(IUserService userService, IUserGameService userGameService)
        {
            _userService = userService;
            _userGameService = userGameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.ListAllAsync());
        }

        [HttpGet("{search}/firstname")]
        public async Task<IActionResult> GetByFirstName(string search)
        {
            return Ok(await _userService.SearchFirstNameAsync(search));
        }

        [HttpGet("{search}/lastname")]
        public async Task<IActionResult> GetByLastName(string search)
        {
            return Ok(await _userService.SearchFirstNameAsync(search));
        }

        [HttpGet("{search}/username")]
        public async Task<IActionResult> GetByUserName(string search)
        {
            return Ok(await _userService.SearchUserNameAsync(search));
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserResponseDto userResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (Guid gameId in userResponseDto.GameId)
            {
                UserGameResponseDto userGameResponseDto = new() { UserId = userResponseDto.Id, GameId = gameId };
                await _userGameService.AddAsync(userGameResponseDto);
            }


            return Ok(await _userService.AddAsync(userResponseDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserResponseDto userResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userGameService.EditUserGameAsync(userResponseDto);

            return Ok(await _userService.UpdateAsync(userResponseDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            foreach (UserGameResponseDto ug in await _userGameService.GetByUserIdAsync(id))
            {
                await _userGameService.DeleteAsync(ug);
            }

            return Ok(await _userService.DeleteAsync(id));
        }
    }
}
