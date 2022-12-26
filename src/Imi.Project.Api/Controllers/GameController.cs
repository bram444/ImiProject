using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using Imi.Project.Api.Dto;
using Imi.Project.Api.Dto.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{

    [Authorize]
    [Authorize(Policy = "approved")]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController: ControllerBase
    {
        protected readonly IGameService _gameService;
        private readonly IGameGenreService _gameGenreService;
        private readonly IUserGameService _userGameService;
        public GameController(IGameService gameService, IGameGenreService gameGenreService, IUserGameService userGameService)
        {
            _gameService = gameService;
            _gameGenreService = gameGenreService;
            _userGameService = userGameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new ServiceResultModel<IEnumerable<GameDto>>();

            ServiceResultModel<IEnumerable<Game>> serviceGame = await _gameService.ListAllAsync();

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            List<GameDto> gameList = new();

            foreach(Game game in serviceGame.Data)
            {
                GameDto gameModel = new()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Price = game.Price,
                    PublisherId = game.PublisherId,
                };

                var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(game.Id);

                if(!serviceGameGenre.IsSuccess)
                {
                    return BadRequest(serviceGameGenre.ValidationErrors);
                }

                List<Guid> listgenre = new();

                foreach(var gg in serviceGameGenre.Data)
                {
                    listgenre.Add(gg.GenreId);
                }

                gameModel.GenreId = listgenre;

                gameList.Add(gameModel);
            }

            result.Data = gameList;

            return Ok(result.Data);
        }

        [Authorize(Policy = "onlyAdults")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = new ServiceResultModel<GameDto>();


            ServiceResultModel<Game> serviceGame = await _gameService.GetByIdAsync(id);

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            result.Data = new GameDto
            {
                Id = serviceGame.Data.Id,
                Name = serviceGame.Data.Name,
                Price = serviceGame.Data.Price,
                PublisherId = serviceGame.Data.PublisherId
            };

            var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(id);

            if(!serviceGameGenre.IsSuccess)
            {
                return BadRequest(serviceGameGenre.ValidationErrors);
            }

            List<Guid> listgenre = new();

            foreach(var gg in serviceGameGenre.Data)
            {
                listgenre.Add(gg.GenreId);
            }

            result.Data.GenreId = listgenre;

            return Ok(result.Data);
        }

        [Authorize(Policy = "onlyAdults")]
        [HttpGet("{search}/name")]
        public async Task<IActionResult> GetGamesByName(string search)
        {
            var result = new ServiceResultModel<IEnumerable<GameDto>>();

            var serviceGame = await _gameService.SearchAsync(search);

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            List<GameDto> model = new();

            foreach(var game in serviceGame.Data)
            {
                GameDto gameModel = new()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Price = game.Price,
                    PublisherId = game.PublisherId,
                };

                var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(game.Id);

                if(!serviceGameGenre.IsSuccess)
                {
                    return BadRequest(serviceGameGenre.ValidationErrors);
                }

                List<Guid> listgenre = new();

                foreach(var gg in serviceGameGenre.Data)
                {
                    listgenre.Add(gg.GenreId);
                }

                gameModel.GenreId = listgenre;

                model.Add(gameModel);
            }

            result.Data = model;

            return Ok(result.Data);
        }

        [Authorize(Policy = "onlyAdults")]
        [HttpGet("{id}/publishers")]
        public async Task<IActionResult> GetGamesByPublisher(Guid id)
        {
            var result = new ServiceResultModel<IEnumerable<GameDto>>();

            var serviceGame = await _gameService.GetByPublisherIdAsync(id);

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            List<GameDto> model = new();

            foreach(var game in serviceGame.Data)
            {
                GameDto gameModel = new()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Price = game.Price,
                    PublisherId = game.PublisherId,
                };

                var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(game.Id);

                if(!serviceGameGenre.IsSuccess)
                {
                    return BadRequest(serviceGameGenre.ValidationErrors);
                }

                List<Guid> listgenre = new();

                foreach(var gg in serviceGameGenre.Data)
                {
                    listgenre.Add(gg.GenreId);
                }

                gameModel.GenreId = listgenre;

                model.Add(gameModel);
            }

            result.Data = model;


            return Ok(result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(GameDto gameDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new ServiceResultModel<Game>();

            result = await _gameService.AddAsync(new GameModel
            {
                Id = gameDto.Id,
                Name = gameDto.Name,
                Price = gameDto.Price,
                PublisherId = gameDto.PublisherId,
                 GenreId = gameDto.GenreId,
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            foreach(Guid genreId in gameDto.GenreId.Distinct())
            {
                GameGenreModel gameGenreResponseDto = new() { GenreId = genreId, GameId = gameDto.Id };
                var addGameGenre = await _gameGenreService.AddAsync(gameGenreResponseDto);

                if(!addGameGenre.IsSuccess)
                {
                    return BadRequest(addGameGenre.ValidationErrors);
                }
            }

            return CreatedAtAction(nameof(GetById), new { id = gameDto.Id }, result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(GameDto gameDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _gameService.UpdateAsync(new GameModel
            {
                Id = gameDto.Id,
                Name = gameDto.Name,
                Price = gameDto.Price,
                PublisherId = gameDto.PublisherId,
                GenreId = gameDto.GenreId
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            var resultGameGenre = await _gameGenreService.EditGameGenreAsync(new GameModel
            {
                Id = gameDto.Id,
                Name = gameDto.Name,
                Price = gameDto.Price,
                PublisherId = gameDto.PublisherId,
                GenreId = gameDto.GenreId
            });

            if(!resultGameGenre.IsSuccess)
            {
                return BadRequest(resultGameGenre.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _gameService.DeleteAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            var gameGenre = await _gameGenreService.GetByGameIdAsync(id);

            foreach(GameGenre gg in gameGenre.Data)
            {
                var deleteGenreGame = await _gameGenreService.DeleteAsync(new GameGenreModel
                {
                    GameId = gg.GameId,
                    GenreId = gg.GenreId
                });

                if(!deleteGenreGame.IsSuccess)
                {
                    return BadRequest(deleteGenreGame.ValidationErrors);
                }
            }

            var userGame = await _userGameService.GetByGameIdAsync(id);


            foreach(UserGame ug in userGame.Data)
            {
                var deleteUserGame = await _userGameService.DeleteAsync(new UserGameModel { UserId = ug.UserId, GameId = ug.GameId });

                if(!deleteUserGame.IsSuccess)
                {
                    return BadRequest(deleteUserGame.ValidationErrors);
                }
            }

            return Ok();
        }
    }
}