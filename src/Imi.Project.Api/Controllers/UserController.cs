using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Dto.Game;
using Imi.Project.Api.Dto.User;
using Imi.Project.Api.Mapper;
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
        protected readonly IGameService _gameService;

        public UserController(IUserService userService, IUserGameService userGameService, IGameService gameService)
        {
            _userService = userService;
            _userGameService = userGameService;
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.ListAllAsync();

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            List<UserResponseDto> response = new();

            foreach(ApplicationUser user in result.Data)
            {
                var userGame = await _userGameService.GetByUserIdAsync(user.Id);

                List<GameResponseDto> gameList = new();

                foreach(var ug in userGame.Data)
                {
                    var game = await _gameService.GetByIdAsync(ug.GameId);

                    if(!game.IsSuccess)
                    {
                        return BadRequest(game.ValidationErrors);
                    }

                    gameList.Add(game.Data.MapToDto());

                }

                response.Add(user.MapToDto(gameList));

            }

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ServiceResultModel<ApplicationUser> result = await _userService.GetByIdAsync(id);

            var userGame = await _userGameService.GetByUserIdAsync(result.Data.Id);

            List<GameResponseDto> gameList = new();

            foreach(var ug in userGame.Data)
            {
                var game = await _gameService.GetByIdAsync(ug.GameId);

                if(!game.IsSuccess)
                {
                    return BadRequest(game.ValidationErrors);
                }

                gameList.Add(game.Data.MapToDto());

            }

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok(result.Data.MapToDto(gameList));
        }

        [HttpGet("{search}/firstname")]
        public async Task<IActionResult> GetByFirstName(string search)
        {
            var result = await _userService.SearchFirstNameAsync(search);

            List<UserResponseDto> response = new();

            foreach(ApplicationUser user in result.Data)
            {
                var userGame = await _userGameService.GetByUserIdAsync(user.Id);

                List<GameResponseDto> gameList = new();

                foreach(var ug in userGame.Data)
                {
                    var game = await _gameService.GetByIdAsync(ug.GameId);

                    if(!game.IsSuccess)
                    {
                        return BadRequest(game.ValidationErrors);
                    }

                    gameList.Add(game.Data.MapToDto());
                }

                response.Add(user.MapToDto(gameList));

            }

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok(response);
        }

        [HttpGet("{search}/lastname")]
        public async Task<IActionResult> GetByLastName(string search)
        {
            var result = await _userService.SearchLastNameAsync(search);

            List<UserResponseDto> response = new();

            foreach(ApplicationUser user in result.Data)
            {
                var userGame = await _userGameService.GetByUserIdAsync(user.Id);

                List<GameResponseDto> gameList = new();

                foreach(var ug in userGame.Data)
                {
                    var game = await _gameService.GetByIdAsync(ug.GameId);

                    if(!game.IsSuccess)
                    {
                        return BadRequest(game.ValidationErrors);
                    }

                    gameList.Add(game.Data.MapToDto());
                }

                response.Add(user.MapToDto(gameList));

            }

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok(response);
        }

        [HttpGet("{search}/username")]
        public async Task<IActionResult> GetByUserName(string search)
        {
            var result = await _userService.SearchUserNameAsync(search);

            List<UserResponseDto> response = new();

            foreach(ApplicationUser user in result.Data)
            {
                var userGame = await _userGameService.GetByUserIdAsync(user.Id);

                List<GameResponseDto> gameList = new();

                foreach(var ug in userGame.Data)
                {
                    var game = await _gameService.GetByIdAsync(ug.GameId);

                    if(!game.IsSuccess)
                    {
                        return BadRequest(game.ValidationErrors);
                    }

                    gameList.Add(game.Data.MapToDto());
                }

                response.Add(user.MapToDto(gameList));

            }

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok(response);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(NewUserRequestDto newUserRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.AddAsync(newUserRequest.MapToModel());

            return !result.IsSuccess
                ? BadRequest(result.ValidationErrors)
                : CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data.MapToDto());
        }

        [Authorize(Policy = "onlyOwner")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserRequestDto updateUserDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultUserGame = await _userGameService.EditUserGameAsync(updateUserDto.MapToUserGameModel());

            if(!resultUserGame.IsSuccess)
            {
                return BadRequest(resultUserGame.ValidationErrors);
            }

            ServiceResultModel<ApplicationUser> result = await _userService.UpdateAsync(updateUserDto.MapToModel());

            //var userGame = await _userGameService.GetByUserIdAsync(result.Data.Id);

            List<GameResponseDto> gameList = new();

            foreach(var ug in resultUserGame.Data)
            {
                var game = await _gameService.GetByIdAsync(ug.GameId);
                if(!game.IsSuccess)
                {
                    return BadRequest(game.ValidationErrors);
                }
                gameList.Add(game.Data.MapToDto());
            }

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok(result.Data.MapToDto(gameList));
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
                var resultUserGame = await _userGameService.DeleteAsync(ug.MapToModel());

                if(!resultUserGame.IsSuccess)
                {
                    return BadRequest(resultUserGame.ValidationErrors);
                }
            }

            var result = await _userService.DeleteAsync(id);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok();
        }
    }
}