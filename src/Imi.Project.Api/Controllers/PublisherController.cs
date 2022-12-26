using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using Imi.Project.Api.Dto.Publisher;
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
            var result = await _publisherService.ListAllAsync();

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _publisherService.GetByIdAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{search}/name")]
        public async Task<IActionResult> GetPublisherByName(string search)
        {
            var result = await _publisherService.SearchAsync(search);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{search}/country")]
        public async Task<IActionResult> GetPublisherByCountry(string search)
        {
            var result = await _publisherService.SearchByCountryAsync(search);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok(result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(PublisherDto publisherDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new ServiceResultModel<Publisher>();

            result = await _publisherService.AddAsync(new PublisherModel
            {
                Id = publisherDto.Id,
                Name = publisherDto.Name,
                Country = publisherDto.Country
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return CreatedAtAction(nameof(GetById), new { id = publisherDto.Id }, result.Data);
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(PublisherDto publisherDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _publisherService.UpdateAsync(new PublisherModel
            {
                Id = publisherDto.Id,
                Name = publisherDto.Name,
                Country = publisherDto.Country
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _publisherService.DeleteAsync(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }

            return Ok();
        }
    }
}