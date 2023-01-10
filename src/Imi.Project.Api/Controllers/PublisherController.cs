using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Dto.Publisher;
using Imi.Project.Api.Mapper;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResultModel<IEnumerable<Publisher>> result = await _publisherService.ListAllAsync();

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) :
                Ok(result.Data.MapToDtos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ServiceResultModel<Publisher> result = await _publisherService.GetByIdAsync(id);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) :
                Ok(result.Data.MapToDto());

        }

        [AllowAnonymous]
        [HttpGet("{search}/name")]
        public async Task<IActionResult> GetPublisherByName(string search)
        {
            ServiceResultModel<IEnumerable<Publisher>> result = await _publisherService.SearchAsync(search);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) :
                Ok(result.Data.MapToDtos());
        }

        [HttpGet("{search}/country")]
        public async Task<IActionResult> GetPublisherByCountry(string search)
        {
            ServiceResultModel<IEnumerable<Publisher>> result = await _publisherService.SearchByCountryAsync(search);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) :
                Ok(result.Data.MapToDtos());
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        public async Task<IActionResult> Post(NewPublisherRequestDto newPublisher)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResultModel<Publisher> result = await _publisherService.AddAsync(newPublisher.MapToModel());

            return !result.IsSuccess
                ? BadRequest(result.ValidationErrors)
                : CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data.MapToDto());
        }

        [Authorize(Policy = "adminOnly")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdatePublisherRequestDto updatePublisher)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResultModel<Publisher> result = await _publisherService.UpdateAsync(updatePublisher.MapToModel());

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) :
                Ok(result.Data.MapToDto());
        }

        [Authorize(Policy = "adminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResultModel<Publisher> result = await _publisherService.DeleteAsync(id);

            return !result.IsSuccess ? BadRequest(result.ValidationErrors) : Ok();
        }
    }
}