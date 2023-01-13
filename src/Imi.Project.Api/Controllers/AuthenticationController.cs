using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Dto.Authentication;
using Imi.Project.Api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthenticationResult result = await _authenticationService.RegisterAsync(registration.MapToModel());

            return !result.IsSuccess ? BadRequest(result.Messages) : Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            AuthenticationResult result = await _authenticationService.Login(loginRequestDto.MapToModel());

            return !result.IsSuccess ? BadRequest(result.Messages) : Ok(result.MapToDto());
        }

        [HttpPost("{token}refresh")]
        public async Task<IActionResult> Refresh(string token)
        {
            return Ok(await _authenticationService.RefreshToken(token));
        }
    }
}