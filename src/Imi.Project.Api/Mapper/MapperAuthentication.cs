using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Authentication;
using Imi.Project.Api.Dto.Authentication;

namespace Imi.Project.Api.Mapper
{
    public static class MapperAuthentication
    {
        public static RegistrationModel MapToModel(this RegistrationDto registrationDto)
        {
            return new RegistrationModel
            {
                UserName = registrationDto.UserName,
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                Password = registrationDto.Password,
                ConfirmPassword = registrationDto.ConfirmPassword,
                ApprovedTerms = registrationDto.ApprovedTerms,
                BirthDay = registrationDto.BirthDay
            };
        }

        public static LoginRequestModel MapToModel(this LoginRequestDto loginRequestDto)
        {
            return new LoginRequestModel
            {
                UserName = loginRequestDto.UserName,
                Password = loginRequestDto.Password
            };
        }

        public static LoginResponseDto MapToDto(this AuthenticationResult authenticationresult)
        {
            return new LoginResponseDto { Token = authenticationresult.Token };
        }
    }
}