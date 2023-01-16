using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<AuthenticationResult> RegisterAsync(RegistrationModel registration)
        {
            try
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

                IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);

                if(!result.Succeeded)
                {
                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        Messages = result.Errors.Select(error => error.Description).ToList()
                    };
                }

                newUser = await _userManager.FindByEmailAsync(registration.Email);
                await _userManager.AddClaimAsync(newUser, new Claim(ClaimTypes.DateOfBirth, registration.BirthDay.ToString()));
                await _userManager.AddClaimAsync(newUser, new Claim("approved", registration.ApprovedTerms.ToString()));
                await _userManager.AddToRoleAsync(newUser, "User");

                List<Claim> listClaims = await GetClaims(newUser!);

                JwtSecurityToken jwtSecurityToken = _jwtService.GenerateToken(listClaims);

                return new AuthenticationResult
                {
                    Token = _jwtService.SerializeToken(jwtSecurityToken),
                    Messages = new List<string> { "Succesfully registered" }
                };

            } catch(Exception ex)
            {
                return new AuthenticationResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { ex.Message }
                };
            }
        }

        public async Task<AuthenticationResult> Login(LoginRequestModel loginUser)
        {
            try
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, true, false);

                if(!result.Succeeded)
                {
                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        Messages = new List<string> { "Login failed!" }
                    };
                }

                ApplicationUser applicationUser = await _userManager.FindByNameAsync(loginUser.UserName);

                List<Claim> listClaims = await GetClaims(applicationUser!);

                JwtSecurityToken jwtSecurityToken = _jwtService.GenerateToken(listClaims);

                return new AuthenticationResult { Token = _jwtService.SerializeToken(jwtSecurityToken) };

            } catch(Exception ex)
            {
                return new AuthenticationResult
                {
                    IsSuccess = false,
                    Messages = new List<string> { ex.Message }
                };
            }
        }

        public async Task<string> RefreshToken(string token)
        {
            JwtSecurityToken jwt = _jwtService.DecodeToken(token);

            string id = jwt.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            string email = jwt.Claims.First(c => c.Type == ClaimTypes.Email).Value;

            string birthday = jwt.Claims.First(c => c.Type == ClaimTypes.DateOfBirth).Value;

            ApplicationUser user = await _userManager.FindByIdAsync(id);

            string dateTimeBDString = user.BirthDay.ToString("dd/MM/yyyy");

            if(user == null || user.Email != email || user.Id.ToString() != id)
            {
                return token;
            }

            List<Claim> listClaims = await GetClaims(user!);

            JwtSecurityToken jwtSecurityToken = _jwtService.GenerateToken(listClaims);

            return _jwtService.SerializeToken(jwtSecurityToken);
        }

        public async Task UpdateClaim(string id, bool approved)
        {
            ApplicationUser applicationUserOld = await _userManager.FindByIdAsync(id.ToString());

            applicationUserOld.ApprovedTerms = approved;

            IList<Claim> claims = await _userManager.GetClaimsAsync(applicationUserOld);

            Claim oldClaim = claims.Where(c => c.Type == "approved").FirstOrDefault();

            Claim newClaim = new("approved", applicationUserOld.ApprovedTerms.ToString());

            await _userManager.ReplaceClaimAsync(applicationUserOld, oldClaim, newClaim);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {

            // Loading the user Claims 
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);

            List<Claim> claims = new();

            claims.AddRange(userClaims);

            // Loading the roles and put them in a claim of a Role ClaimType 
            IList<string> roleClaims = await _userManager.GetRolesAsync(user);
            foreach(string roleClaim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }

            ApplicationUser foundUser = await _userManager.FindByNameAsync(user.UserName);

            claims.Add(new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString()));

            claims.Add(new Claim(ClaimTypes.Name, foundUser.UserName));

            claims.Add(new Claim(ClaimTypes.Email, foundUser.Email));

            return claims;
        }
    }
}