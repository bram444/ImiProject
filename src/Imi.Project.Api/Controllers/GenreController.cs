using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
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
    public class GenreController: ControllerBase
    {
        protected readonly IGenreService _genreService;
        protected readonly IGameGenreService _gameGenreService;

        public GenreController(IGenreService genreService, IGameGenreService gameGenreService)
        {
            _genreService = genreService;
            _gameGenreService = gameGenreService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResultModel<IEnumerable<Genre>> result = await _genreService.ListAllAsync();

            return !result.IsSuccess ? BadRequest(result.ValidationErrors)
                : Ok(result.Data.MapToDtos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ServiceResultModel<Genre> result = await _genreService.GetByIdAsync(id);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors)
                : Ok(result.Data.MapToDto());
        }

        [AllowAnonymous]
        [HttpGet("{search}/genre")]
        public async Task<IActionResult> GetByName(string search)
        {
            ServiceResultModel<IEnumerable<Genre>> result = await _genreService.SearchAsync(search);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors)
                : Ok(result.Data.MapToDtos());
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(NewGenreRequestDto newGenreRequestDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResultModel<Genre> result = await _genreService.AddAsync(newGenreRequestDto.MapToModel());

            return !result.IsSuccess
                ? BadRequest(result.ValidationErrors)
                : CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data.MapToDto());
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateGenreRequestDto updateGenre)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResultModel<Genre> result = await _genreService.UpdateAsync(updateGenre.MapToModel());

            return !result.IsSuccess ? BadRequest(result.ValidationErrors)
                : Ok(result.Data.MapToDto());
        }

        [Authorize(Policy = "adminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            ServiceResultModel<IEnumerable<GameGenre>> resultGameGenreList = await _gameGenreService.GetByGenreIdAsync(id);

            if(!resultGameGenreList.IsSuccess)
            {
                return BadRequest(resultGameGenreList.ValidationErrors);
            }

            foreach(GameGenre gg in resultGameGenreList.Data)
            {
                ServiceResultModel<GameGenre> resultGameGenre = await _gameGenreService.DeleteAsync(gg.MapToModel());

                if(!resultGameGenre.IsSuccess)
                {
                    return BadRequest(resultGameGenre.ValidationErrors);
                }
            }

            ServiceResultModel<Genre> result = await _genreService.DeleteAsync(id);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok();
        }
    }
}