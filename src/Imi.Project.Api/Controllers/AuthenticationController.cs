using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using Imi.Project.Api.Dto.Authentication;
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
        public async Task<IActionResult> Register([FromBody] RegisterDto registration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authenticationService.RegisterAsync(new RegisterModel
            {
                ApprovedTerms = registration.ApprovedTerms,
                BirthDay = registration.BirthDay,
                ConfirmPassword = registration.ConfirmPassword,
                Email = registration.Email,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Password = registration.Password,
                UserName = registration.UserName,
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var result = await _authenticationService.Login(new LoginRequestModel
            {
                UserName = loginRequestDto.UserName,
                Password = loginRequestDto.Password,
            });

            if(!result.IsSuccess)
            {
                return BadRequest(result.Messages);
            }

            return Ok(new LoginResponseDto { Token = result.Token });
        }
    }
}