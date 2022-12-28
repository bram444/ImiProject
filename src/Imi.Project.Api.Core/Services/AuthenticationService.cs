using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Models.Authentiction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<AuthenticateResult> RegisterAsync(RegistrationModel registration)
        {
            ApplicationUser newUser = new()
            {
                ApprovedTerms = registration.ApprovedTerms,
                Email = registration.Email,
                UserName = registration.UserName,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Id = Guid.NewGuid(),
                BirthDay = registration.BirthDay,
                NormalizedEmail = registration.Email.Normalize(),
                NormalizedUserName = registration.UserName.Normalize(),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            try
            {
                IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);

                if(!result.Succeeded)
                {
                    List<string> errors = new();
                    foreach(IdentityError error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }

                    return new AuthenticateResult
                    {
                        IsSuccess = false,
                        Messages = errors
                    };
                }

                newUser = await _userManager.FindByEmailAsync(registration.Email);
                await _userManager.AddClaimAsync(newUser, new Claim("birthday", registration.BirthDay.ToString()));
                await _userManager.AddClaimAsync(newUser, new Claim("approved", registration.ApprovedTerms.ToString()));
                await _userManager.AddToRoleAsync(newUser, "User");

                return new AuthenticateResult
                {
                    Messages = new List<string> { "Succesfully registered" }
                };
            } catch(Exception ex)
            {
                return new AuthenticateResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthenticateResult> Login(LoginRequestModel loginUser)
        {
            try
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, true, false);

                if(!result.Succeeded)
                {
                    return new AuthenticateResult
                    {
                        IsSuccess = false,
                        Messages = new List<string> { "Login failed!" }
                    };
                }

                ApplicationUser applicationUser = await _userManager.FindByNameAsync(loginUser.UserName);

                List<Claim> listClaims = await GetClaims(applicationUser!);

                JwtSecurityToken jwtSecurityToken = _jwtService.GenerateToken(listClaims);

                return new AuthenticateResult { Token = _jwtService.SerializeToken(jwtSecurityToken) };

            } catch(Exception ex)
            {
                return new AuthenticateResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { ex.Message }
                };
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            List<Claim> claims = new();

            // Loading the user Claims 
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            // Loading the roles and put them in a claim of a Role ClaimType 
            IList<string> roleClaims = await _userManager.GetRolesAsync(user);
            foreach(string roleClaim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, await _userManager.GetUserIdAsync(user)));

            claims.Add(new Claim(ClaimTypes.Name, (await _userManager.GetUserNameAsync(user))!));

            claims.Add(new Claim(ClaimTypes.Email, (await _userManager.GetEmailAsync(user))!));

            return claims;
        }
    }
}