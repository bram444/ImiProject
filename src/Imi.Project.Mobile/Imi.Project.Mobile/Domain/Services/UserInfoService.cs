using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class UserInfoService: BaseService<UserInfo, RegistrationInfo, UpdateUserInfo>, IUserService
    {
        private readonly IAuthenticationService _authenticationService = new AuthenticationService();
        private readonly ITokenService _tokenService = new TokenService();

        public UserInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/User")
        {
        }

        public override async Task<ApiResponse<UserInfo>> Add(RegistrationInfo user)
        {
            try
            {
                TokenResponse token = await _authenticationService.Registration(user);

                return new ApiResponse<UserInfo>()
                {
                    IsSuccess = true,
                    ApiResponseData = await GetById(_tokenService.GetId(token.Token))
                };

            } catch(Exception ex)
            {
                return new ApiResponse<UserInfo>()
                {
                    IsSuccess = false,
                    Messages = new List<string>() { ex.Message }
                };
            }
        }
    }
}