using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserGameRepository _userGameRepository;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(IUserRepository userRepository, IUserGameRepository userGameRepository, 
            UserManager<ApplicationUser> userManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _userRepository = userRepository;
            _userGameRepository = userGameRepository;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        private ApplicationUser CreateEntity(UserResponseDto userResponseDto)
        {
            ApplicationUser user = new()
            {
                Id = userResponseDto.Id,
                Email = userResponseDto.Email,
                FirstName = userResponseDto.FirstName,
                LastName = userResponseDto.LastName,
                UserName = userResponseDto.UserName,
                ApprovedTerms = userResponseDto.ApprovedTerms,
            };

            user.PasswordHash = passwordHasher.HashPassword(user, userResponseDto.Password);

            return user;
        }

        private static UserResponseDto CreateDto(ApplicationUser user, List<Guid> gameId)
        {
            UserResponseDto userResponseDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                GameId = gameId,
                Password = user.PasswordHash,
                ConfirmPassword = user.PasswordHash,
                ApprovedTerms = user.ApprovedTerms
            };

            return userResponseDto;
        }

        private async Task<List<Guid>> GetGameList(Guid userId)
        {
            IEnumerable<UserGame> userGames = await _userGameRepository.GetByUserIdAsync(userId);

            List<Guid> gameIds = new();

            foreach(UserGame userGame in userGames)
            {
                gameIds.Add(userGame.GameId);
            }

            return gameIds;
        }

        public async Task<ServiceResult<UserResponseDto>> AddAsync(UserResponseDto response)
        {
            ServiceResult<UserResponseDto> serviceResponse = new();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.AddAsync(CreateEntity(response)), await GetGameList(response.Id));
            } catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResult<UserResponseDto>> DeleteAsync(Guid id)
        {
            ServiceResult<UserResponseDto> serviceResponse = new();

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.DeleteAsync(await _userRepository.GetByIdAsync(id)), await GetGameList(id));
            } catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }

            return serviceResponse;
        }

        public IQueryable<UserResponseDto> GetAll()
        {
            List<UserResponseDto> userResponseDtos = new();

            foreach(ApplicationUser entity in _userRepository.GetAll())
            {
                IEnumerable<UserGame> userGames = _userGameRepository.GetByUserIdAsync(entity.Id).Result;

                List<Guid> gameIds = new();

                foreach(UserGame userGame in userGames)
                {
                    gameIds.Add(userGame.GameId);
                }

                userResponseDtos.Add(CreateDto(entity, gameIds));
            }

            return userResponseDtos.AsQueryable();
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto(await _userRepository.GetByIdAsync(id), await GetGameList(id));
        }

        public async Task<IEnumerable<UserResponseDto>> ListAllAsync()
        {
            List<UserResponseDto> userResponseDtos = new();
            foreach(ApplicationUser entity in await _userRepository.ListAllAsync())
            {
                userResponseDtos.Add(CreateDto(entity, await GetGameList(entity.Id)));
            }

            return userResponseDtos;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchFirstNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new();
            foreach(ApplicationUser user in await _userRepository.SearchFirstNameAsync(search))
            {
                userResponseList.Add(CreateDto(user, await GetGameList(user.Id)));
            }

            return userResponseList;
        }
        public async Task<IEnumerable<UserResponseDto>> SearchLastNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new();
            foreach(ApplicationUser user in await _userRepository.SearchLastNameAsync(search))
            {
                userResponseList.Add(CreateDto(user, await GetGameList(user.Id)));
            }

            return userResponseList;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchUserNameAsync(string search)
        {
            List<UserResponseDto> userResponseList = new();
            foreach(ApplicationUser user in await _userRepository.SearchUserNameAsync(search))
            {
                userResponseList.Add(CreateDto(user, await GetGameList(user.Id)));
            }

            return userResponseList;
        }

        public async Task<ServiceResult<UserResponseDto>> UpdateAsync(UserResponseDto response)
        {
            ServiceResult<UserResponseDto> serviceResponse = new();

            ApplicationUser editUser = await _userRepository.GetByIdAsync(response.Id);

            editUser.Email = response.Email;
            editUser.FirstName = response.FirstName;
            editUser.LastName = response.LastName;
            editUser.UserName = response.UserName;
            editUser.PasswordHash = passwordHasher.HashPassword(editUser, response.Password);

            try
            {
                serviceResponse.Result = CreateDto(await _userRepository.UpdateAsync(editUser), await GetGameList(response.Id));
            } catch(Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }

            return serviceResponse;
        }
        public async Task<bool> RegisterAsync(RegisterDto registration)
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
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);

            if(!result.Succeeded)
            {
                return false;
            }

            newUser = await _userManager.FindByEmailAsync(registration.Email);
            await _userManager.AddClaimAsync(newUser, new Claim("birthday", registration.BirthDay.ToString()));
            await _userManager.AddClaimAsync(newUser, new Claim("approved", registration.ApprovedTerms.ToString()));
            await _userManager.AddToRoleAsync(newUser, "User");

            return true;
        }

        public async Task<string> Login(LoginUserRequestDto loginUser)
        {
            //check if user exists
            var user = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, true, false);

            ApplicationUser applicationUser = await _userManager.FindByNameAsync(loginUser.UserName);

            JwtSecurityToken token = await GenerateTokenAsync(applicationUser!);
            return new JwtSecurityTokenHandler().WriteToken(token); //serialize the token 
        }

        private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
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

            claims.Add(new Claim(ClaimTypes.DateOfBirth, value: user.BirthDay.ToShortDateString()));

            claims.Add(new Claim(type: "approved", value: user.ApprovedTerms.ToString()));

            claims.AddRange(userClaims);
            var expirationDays = int.Parse(_configuration["JWTConfiguration:TokenExpirationDays"]);
            var signinKey = _configuration["JWTConfiguration:SigninKey"];
            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWTConfiguration:Issuer"],
                audience: _configuration["JWTConfiguration:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey))
                , SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

    }
}