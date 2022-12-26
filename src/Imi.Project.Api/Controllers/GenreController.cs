using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using Imi.Project.Api.Dto.Game;
using Imi.Project.Api.Dto.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Authorize(Policy = "approved")]
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
            var result = await _genreService.ListAllAsync();

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _genreService.GetByIdAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{search}/genre")]
        public async Task<IActionResult> GetByName(string search)
        {
            var result = await _genreService.SearchAsync(search);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(GenreDto genreDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _genreService.AddAsync(new GenreModel
            {
                Id = genreDto.Id,
                Description = genreDto.Description,
                Name = genreDto.Name
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return CreatedAtAction(nameof(GetById), new { id = genreDto.Id }, result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(GenreDto genreDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _genreService.UpdateAsync(new GenreModel
            {
                Id = genreDto.Id,
                Description = genreDto.Description,
                Name = genreDto.Name
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var x = await _gameGenreService.GetByGenreIdAsync(id);
            if(!x.IsSuccess)
            {
                return BadRequest(x.ValidationErrors);
            }

            foreach(GameGenre gg in x.Data)
            {
                var res = await _gameGenreService.DeleteAsync(new GameGenreModel
                {
                    GameId = gg.GameId,
                    GenreId = gg.GenreId
                });

                if(!res.IsSuccess)
                {
                    return BadRequest(res.ValidationErrors);
                }
            }

            var result = await _genreService.DeleteAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok();
        }
    }
}