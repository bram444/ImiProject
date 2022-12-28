using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models.Authentiction;
using Imi.Project.Api.Dto.Authentication;

namespace Imi.Project.Api.Mapper
{
    public static class MapperAuthentication
    {
        public static RegistrationModel RegistrationModelMapper(this RegistrationDto registrationDto)
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

        public static LoginRequestModel LoginRequestModelMapper(this LoginRequestDto loginRequestDto)
        {
            return new LoginRequestModel
            {
                UserName = loginRequestDto.UserName,
                Password = loginRequestDto.Password
            };
        }

        public static LoginResponseDto LoginResponseDto(this AuthenticateResult authenticationresult)
        {
            return new LoginResponseDto { Token = authenticationresult.Token };
        }
    }
}