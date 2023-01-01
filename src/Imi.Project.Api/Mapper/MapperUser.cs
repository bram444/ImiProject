using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.User;
using Imi.Project.Api.Dto.Game;
using Imi.Project.Api.Dto.User;

namespace Imi.Project.Api.Mapper
{
    public static class MapperUser
    {
        public static NewUserModel MapToModel(this NewUserRequestDto newUser)
        {
            return new NewUserModel
            {
                UserName = newUser.UserName,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password,
                ConfirmPassword = newUser.ConfirmPassword,
                BirthDay = newUser.BirthDay,
                ApprovedTerms = newUser.ApprovedTerms
            };
        }

        public static UpdateUserModel MapToModel(this UpdateUserRequestDto updateUser)
        {
            return new UpdateUserModel
            {
                Id = updateUser.Id,
                UserName = updateUser.UserName,
                FirstName = updateUser.FirstName,
                LastName = updateUser.LastName,
                Password = updateUser.Password,
                ConfirmPassword = updateUser.ConfirmPassword,
                ApprovedTerms = updateUser.ApprovedTerms,
                GameId = updateUser.GameId
            };
        }

        public static UserResponseDto MapToDto(this ApplicationUser applicationUser)
        {
            return new UserResponseDto
            {
                Id = applicationUser.Id,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                ApprovedTerms = applicationUser.ApprovedTerms,
                BirthDay = applicationUser.BirthDay,
                Password = applicationUser.PasswordHash
            };
        }

        public static UserResponseDto MapToDto(this ApplicationUser applicationUser, List<GameResponseDto> gameResponse)
        {
            var userResponse = MapToDto(applicationUser);
            userResponse.Games = gameResponse;
            return userResponse;
        }

        //public static IEnumerable<UserResponseDto> UserResponseDtoMapper(this IEnumerable<ApplicationUser> applicationUsers)
        //{
        //    return applicationUsers.Select(user => user.UserResponseDtoMapper());
        //}
    }
}