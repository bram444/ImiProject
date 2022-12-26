using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using Imi.Project.Api.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
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
            var result = await _userService.ListAllAsync();

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userService.GetByIdAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{search}/firstname")]
        public async Task<IActionResult> GetByFirstName(string search)
        {
            var result = await _userService.SearchFirstNameAsync(search);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{search}/lastname")]
        public async Task<IActionResult> GetByLastName(string search)
        {
            var result = await _userService.SearchLastNameAsync(search);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{search}/username")]
        public async Task<IActionResult> GetByUserName(string search)
        {
            var result = await _userService.SearchUserNameAsync(search);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(UserDto userRequestDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach(Guid gameId in userRequestDto.GameId)
            {
                var resultUserGame = await _userGameService.AddAsync(new UserGameModel
                {
                    GameId = gameId,
                    UserId = userRequestDto.Id
                });

                if(!resultUserGame.IsSuccess)
                {
                    return BadRequest(resultUserGame.ValidationErrors);
                }
            }

            var result = await _userService.AddAsync(new UserRequestModel
            {
                Id = userRequestDto.Id,
                UserName = userRequestDto.UserName,
                GameId = userRequestDto.GameId,
                ApprovedTerms = userRequestDto.ApprovedTerms,
                BirthDay = userRequestDto.BirthDay,
                ConfirmPassword = userRequestDto.ConfirmPassword,
                Email = userRequestDto.Email,
                FirstName = userRequestDto.FirstName,
                LastName = userRequestDto.LastName,
                Password = userRequestDto.Password
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return CreatedAtAction(nameof(GetById), new { id = userRequestDto.Id }, result.Data);
        }

        [Authorize(Policy = "onlyOwner")]
        [HttpPut]
        public async Task<IActionResult> Put(UserDto userRequestDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultUserGame = await _userGameService.EditUserGameAsync(new UserRequestModel
            {
                Id = userRequestDto.Id,
                UserName = userRequestDto.UserName,
                GameId = userRequestDto.GameId,
                ApprovedTerms = userRequestDto.ApprovedTerms,
                BirthDay = userRequestDto.BirthDay,
                ConfirmPassword = userRequestDto.ConfirmPassword,
                Email = userRequestDto.Email,
                FirstName = userRequestDto.FirstName,
                LastName = userRequestDto.LastName,
                Password = userRequestDto.Password
            });

            if(!resultUserGame.IsSuccess)
            {
                return BadRequest(resultUserGame.ValidationErrors);
            }

            var result = await _userService.UpdateAsync(new UserRequestModel
            {
                Id = userRequestDto.Id,
                UserName = userRequestDto.UserName,
                GameId = userRequestDto.GameId,
                ApprovedTerms = userRequestDto.ApprovedTerms,
                BirthDay = userRequestDto.BirthDay,
                ConfirmPassword = userRequestDto.ConfirmPassword,
                Email = userRequestDto.Email,
                FirstName = userRequestDto.FirstName,
                LastName = userRequestDto.LastName,
                Password = userRequestDto.Password
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [Authorize(Policy = "onlyOwner")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deleteUserGame = await _userGameService.GetByUserIdAsync(id);

            foreach(UserGame ug in deleteUserGame.Data)
            {
                UserGameModel userGameModel = new() { UserId = ug.UserId, GameId = ug.GameId };

                var resultUserGame = await _userGameService.DeleteAsync(userGameModel);

                if(!resultUserGame.IsSuccess)
                {
                    return BadRequest(resultUserGame.ValidationErrors);
                }
            }

            var result = await _userService.DeleteAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok();
        }
    }
}