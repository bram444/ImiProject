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

            AuthenticateResult result = await _authenticationService.RegisterAsync(registration.RegistrationModelMapper());

            return !result.IsSuccess ? BadRequest(result.Messages) : Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            AuthenticateResult result = await _authenticationService.Login(loginRequestDto.LoginRequestModelMapper());

            return !result.IsSuccess ? BadRequest(result.Messages) : Ok(result.LoginResponseDto());
        }
    }
}