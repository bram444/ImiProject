using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Dto.Game;
using Imi.Project.Api.Dto.Genre;
using Imi.Project.Api.Mapper;
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
        private readonly IGenreService _genreService;
        private readonly IPublisherService _publisherService;

        public GameController(IGameService gameService, IGameGenreService gameGenreService,
            IUserGameService userGameService, IGenreService genreService,
            IPublisherService publisherService)
        {
            _gameService = gameService;
            _gameGenreService = gameGenreService;
            _userGameService = userGameService;
            _genreService = genreService;
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResultModel<IEnumerable<Game>> serviceGame = await _gameService.ListAllAsync();

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            List<GameResponseDto> gameList = new();

            foreach(Game game in serviceGame.Data)
            {
                var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(game.Id);

                if(!serviceGameGenre.IsSuccess)
                {
                    return BadRequest(serviceGameGenre.ValidationErrors);
                }

                List<GenreResponseDto> genreResponseDtos = new();

                foreach(GameGenre gg in serviceGameGenre.Data)
                {
                    var genreResult = await _genreService.GetByIdAsync(gg.GenreId);

                    if(!genreResult.IsSuccess)
                    {
                        return BadRequest(genreResult.ValidationErrors);
                    }

                    genreResponseDtos.Add(genreResult.Data.MapToDto());
                }

                var publisherResult= await _publisherService.GetByIdAsync(game.PublisherId);

                if(!publisherResult.IsSuccess)
                {
                    return BadRequest(publisherResult.ValidationErrors);
                }

                gameList.Add(game.MapToDto(genreResponseDtos, publisherResult.Data.MapToDto()));
            }

            return Ok(gameList);
        }

        [Authorize(Policy = "onlyAdults")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            ServiceResultModel<Game> serviceGame = await _gameService.GetByIdAsync(id);

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(id);

            if(!serviceGameGenre.IsSuccess)
            {
                return BadRequest(serviceGameGenre.ValidationErrors);
            }

            List<GenreResponseDto> genreResponseDtos = new();

            foreach(GameGenre gg in serviceGameGenre.Data)
            {
                var genreResult = await _genreService.GetByIdAsync(gg.GenreId);

                if(!genreResult.IsSuccess)
                {
                    return BadRequest(genreResult.ValidationErrors);
                }

                genreResponseDtos.Add(genreResult.Data.MapToDto());
            }

            var publisherResult = await _publisherService.GetByIdAsync(serviceGame.Data.PublisherId);

            if(!publisherResult.IsSuccess)
            {
                return BadRequest(publisherResult.ValidationErrors);
            }

            return Ok(serviceGame.Data.MapToDto(genreResponseDtos
                ,publisherResult.Data.MapToDto()));
        }

        [Authorize(Policy = "onlyAdults")]
        [HttpGet("{search}/name")]
        public async Task<IActionResult> GetGamesByName(string search)
        {
            ServiceResultModel<IEnumerable<Game>> serviceGame = await _gameService.SearchAsync(search);

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            List<GameResponseDto> gameList = new();

            foreach(Game game in serviceGame.Data)
            {
                var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(game.Id);

                if(!serviceGameGenre.IsSuccess)
                {
                    return BadRequest(serviceGameGenre.ValidationErrors);
                }

                List<GenreResponseDto> genreResponseDtos = new();

                foreach(GameGenre gg in serviceGameGenre.Data)
                {
                    var genreResult = await _genreService.GetByIdAsync(gg.GenreId);

                    if(!genreResult.IsSuccess)
                    {
                        return BadRequest(genreResult.ValidationErrors);
                    }

                    genreResponseDtos.Add(genreResult.Data.MapToDto());
                }

                var publisherResult = await _publisherService.GetByIdAsync(game.PublisherId);

                if(!publisherResult.IsSuccess)
                {
                    return BadRequest(publisherResult.ValidationErrors);
                }

                gameList.Add(game.MapToDto(genreResponseDtos, publisherResult.Data.MapToDto()));
            }

            return Ok(gameList);
        }

        [Authorize(Policy = "onlyAdults")]
        [HttpGet("{id}/publishers")]
        public async Task<IActionResult> GetGamesByPublisher([FromRoute] Guid id)
        {
            ServiceResultModel<IEnumerable<Game>> serviceGame = await _gameService.GetByPublisherIdAsync(id);

            if(!serviceGame.IsSuccess)
            {
                return BadRequest(serviceGame.ValidationErrors);
            }

            List<GameResponseDto> listGame = new();

            foreach(Game game in serviceGame.Data)
            {
                var serviceGameGenre = await _gameGenreService.GetByGameIdAsync(game.Id);

                if(!serviceGameGenre.IsSuccess)
                {
                    return BadRequest(serviceGameGenre.ValidationErrors);
                }

                List<GenreResponseDto> genreResponseDtos = new();

                foreach(GameGenre gg in serviceGameGenre.Data)
                {
                    var genreResult = await _genreService.GetByIdAsync(gg.GenreId);

                    if(!genreResult.IsSuccess)
                    {
                        return BadRequest(genreResult.ValidationErrors);
                    }

                    genreResponseDtos.Add(genreResult.Data.MapToDto());
                }

                var publisherResult = await _publisherService.GetByIdAsync(game.PublisherId);

                if(!publisherResult.IsSuccess)
                {
                    return BadRequest(publisherResult.ValidationErrors);
                }

                listGame.Add(game.MapToDto(genreResponseDtos, publisherResult.Data.MapToDto()));
            }

            return Ok(listGame);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(NewGameRequestDto newGameRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGameModel = newGameRequest.MapToModel();

            var result = await _gameService.AddAsync(newGameModel);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            var gameGenre = await _gameGenreService.EditGameGenreAsync(newGameRequest.MapToUpdateModel(result.Data.Id));

            if(!gameGenre.IsSuccess)
            {
                return BadRequest(gameGenre.ValidationErrors);
            }

            List<GenreResponseDto> genreResponseDtos = new();

            foreach(Guid genreId in newGameModel.GenreId)
            {
                var genreResult = await _genreService.GetByIdAsync(genreId);

                if(!genreResult.IsSuccess)
                {
                    return BadRequest(genreResult.ValidationErrors);
                }

                genreResponseDtos.Add(genreResult.Data.MapToDto());
            }

            var publisherResult = await _publisherService.GetByIdAsync(newGameModel.PublisherId);

            if(!publisherResult.IsSuccess)
            {
                return BadRequest(publisherResult.ValidationErrors);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id },
                result.Data.MapToDto(genreResponseDtos, publisherResult.Data.MapToDto()));
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateGameRequestDto updateGameRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResultModel<Game> result = await _gameService.UpdateAsync(updateGameRequest.MapToModel());

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            var resultGameGenre = await _gameGenreService.EditGameGenreAsync(updateGameRequest.MapToGameGenreModel());

            if(!resultGameGenre.IsSuccess)
            {
                return BadRequest(resultGameGenre.ValidationErrors);
            }

            List<GenreResponseDto> genreResponseDtos = new();

            foreach(var gg in resultGameGenre.Data)
            {
                var genreResult = await _genreService.GetByIdAsync(gg.GenreId);

                if(!genreResult.IsSuccess)
                {
                    return BadRequest(genreResult.ValidationErrors);
                }

                genreResponseDtos.Add(genreResult.Data.MapToDto());
            }

            var publisherResult = await _publisherService.GetByIdAsync(updateGameRequest.PublisherId);

            if(!publisherResult.IsSuccess)
            {
                return BadRequest(publisherResult.ValidationErrors);
            }

            return Ok(result.Data.MapToDto(genreResponseDtos,
                publisherResult.Data.MapToDto()));
        }

        [Authorize(Policy = "adminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            ServiceResultModel<Game> result = await _gameService.DeleteAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            var gameGenre = await _gameGenreService.GetByGameIdAsync(id);

            foreach(GameGenre gg in gameGenre.Data)
            {
                ServiceResultModel<GameGenre> deleteGenreGame = await _gameGenreService.DeleteAsync(gg.MapToModel());

                if(!deleteGenreGame.IsSuccess)
                {
                    return BadRequest(deleteGenreGame.ValidationErrors);
                }
            }

            ServiceResultModel<IEnumerable<UserGame>> userGame = await _userGameService.GetByGameIdAsync(id);

            foreach(UserGame ug in userGame.Data)
            {
                ServiceResultModel<UserGame> deleteUserGame = await _userGameService.DeleteAsync(ug.MapToModel());

                if(!deleteUserGame.IsSuccess)
                {
                    return BadRequest(deleteUserGame.ValidationErrors);
                }
            }

            return Ok();
        }
    }
}