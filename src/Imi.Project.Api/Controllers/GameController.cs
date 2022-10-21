﻿using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.GameGenre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Dto.UserGame;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        protected readonly IGameService _gameService;
        private readonly IGameGenreService _gameGenreService;
        private readonly IUserGameService _userGameService;
        private readonly IPublisherService _publisherService;
        public GameController(IGameService gameService, IGameGenreService gameGenreService, IUserGameService userGameService, IPublisherService publisherService)
        {
            _gameService = gameService;
            _gameGenreService = gameGenreService;
            _userGameService = userGameService;
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _gameService.ListAllAsync());
        }

        [HttpGet("{search}/name")]
        public async Task<IActionResult> GetGamesByName(string search)
        {
            return Ok(await _gameService.SearchAsync(search));
        }

        [HttpGet("{id}/publishers")]
        public async Task<IActionResult> GetGamesByPublisher(Guid id)
        {
            return Ok(await _gameService.GetByPublisherIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(GameResponseDto gameResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            return Ok(await _gameService.AddAsync(gameResponseDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(GameResponseDto gameResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _gameService.UpdateAsync(gameResponseDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {

            foreach (GameGenreResponseDto gg in await _gameGenreService.GetByGameIdAsync(id))
            {
                await _gameGenreService.DeleteAsync(gg);
            }

            foreach (UserGameResponseDto ug in await _userGameService.GetByGameIdAsync(id))
            {
                await _userGameService.DeleteAsync(ug);
            }

            return Ok(await _gameService.DeleteAsync(id));
        }

    }
}
