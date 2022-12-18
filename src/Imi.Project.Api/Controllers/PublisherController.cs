using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Authorize(Policy = "approved")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController: ControllerBase
    {
        protected readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
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

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(PublisherResponseDto publisherResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _publisherService.AddAsync(publisherResponseDto));
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(PublisherResponseDto publisherResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _publisherService.UpdateAsync(publisherResponseDto));
        }

        [Authorize(Policy = "adminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _publisherService.DeleteAsync(id));
        }
    }
}