using Imi.Project.Api.Core.Dto.Game;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Repository.Interfaces;
using Imi.Project.Api.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.ListAllAsync();
            var userDto = users.Select(g => new UserResponseDto
            {
                Id = g.Id,
                Email = g.Email,
                FirstName = g.FirstName,
                LastName = g.LastName,
                UserName = g.UserName
            });

            return Ok(userDto);
        }
    }
}
