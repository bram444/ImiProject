using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController: ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser? newUser = new()
            {
                ApprovedTerms = registration.ApprovedTerms,
                Email = registration.Email,
                UserName = registration.UserName,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Id = Guid.NewGuid(),
                BirthDay = registration.BirthDay,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            newUser = await _userManager.FindByEmailAsync(registration.Email);
            await _userManager.AddClaimAsync(newUser!, new Claim("birthday", registration.BirthDay.ToString()));
            await _userManager.AddClaimAsync(newUser!, new Claim("approved", registration.ApprovedTerms.ToString()));
            await _userManager.AddToRoleAsync(newUser!, "User");

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequestDto login)
        {
            var applicationUser = await _userManager.FindByNameAsync(login.UserName);
            JwtSecurityToken token = await GenerateTokenAsync(applicationUser!);
            string serializedToken = new JwtSecurityTokenHandler().WriteToken(token); //serialize the token 
            return Ok(new LoginUserResponseDto()
            {
                Token = serializedToken
            });
        }

        private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>();

            // Loading the user Claims 
            var userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            // Loading the roles and put them in a claim of a Role ClaimType 
            var roleClaims = await _userManager.GetRolesAsync(user);
            foreach (var roleClaim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, await _userManager.GetUserIdAsync(user)));

            claims.Add(new Claim(ClaimTypes.Name, (await _userManager.GetUserNameAsync(user))!));

            claims.Add(new Claim(ClaimTypes.Email, (await _userManager.GetEmailAsync(user))!));

            claims.Add(new Claim(type: "Approved", value: user.ApprovedTerms.ToString()));

            var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            var token = new JwtSecurityToken
            (
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey),
                          SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}