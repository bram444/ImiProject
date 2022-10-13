using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Repository.Interfaces;
using Imi.Project.Api.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        protected readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var publishers = await _publisherRepository.ListAllAsync();
            var publisherDto = publishers.Select(g => new PublisherResponseDto
            {
                Id = g.Id,
                Name = g.Name,
                Country=g.Country
            });

            return Ok(publisherDto);
        }
    }
}
