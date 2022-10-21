using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        protected readonly IPublisherService _publisherService;
        private readonly IGameService _gameService;

        public PublisherController(IPublisherService publisherService,IGameService gameService)
        {
            _publisherService = publisherService;
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _publisherService.ListAllAsync());
        }

        [HttpGet("{search}/name")]
        public async Task<IActionResult> GetPublisherByName(string search)
        {
            return Ok(await _publisherService.SearchAsync(search));
        }

        [HttpGet("{search}/country")]
        public async Task<IActionResult> GetPublisherByCountry(string search)
        {
            return Ok(await _publisherService.SearchByCountryAsync(search));
        }


        [HttpPost]
        public async Task<IActionResult> Post(PublisherResponseDto publisherResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _publisherService.AddAsync(publisherResponseDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(PublisherResponseDto publisherResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _publisherService.UpdateAsync(publisherResponseDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _publisherService.DeleteAsync(id));
        }
    }
}
