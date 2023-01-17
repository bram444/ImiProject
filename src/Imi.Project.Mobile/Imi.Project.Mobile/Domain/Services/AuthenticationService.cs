using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Imi.Project.Mobile.Domain.Services
{
    public class AuthenticationService: HttpClient, IAuthenticationService
    {
        private readonly string baseUrl = Constants.baseUrl;
        private readonly string _api;

        public AuthenticationService() : base(CreateClientHandler())
        {
            _api = "/api/Authentication";
        }

        private static HttpClientHandler CreateClientHandler()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
#if DEBUG
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
#endif
            return httpClientHandler;
        }

        public async Task<TokenResponse> Login(LogInInfo login)
        {
            try
            {
                HttpResponseMessage responseMessage = await this.PostAsJsonAsync($"{baseUrl}{_api}/login", login);

                if(responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<TokenResponse>();
                }
                List<string> allErrors = new List<string>();

                string value = await responseMessage.Content.ReadAsStringAsync();
                if(value.Contains("errors"))
                {
                    var obj = new { errors = new Dictionary<string, string[]>() };
                    var validations = JsonConvert.DeserializeAnonymousType(value, obj);

                    List<string[]> allValidators = validations.errors.Values.ToList();

                    allValidators.ForEach(stringList => stringList.ForEach(singleError => allErrors.Add(singleError)));

                    return new TokenResponse
                    {
                        IsSuccess = false,
                        Messages = allErrors
                    };
                }

                object[] allObjects = await responseMessage.Content.ReadAsAsync<object[]>();
                string[] stringArray = Array.ConvertAll(allObjects, o => o.ToString());
                allErrors.AddRange(stringArray);
                return new TokenResponse
                {
                    IsSuccess = false,
                    Messages = allErrors
                };

            } catch(Exception ex)
            {
                return new TokenResponse
                {
                    IsSuccess = false,
                    Messages = new List<string>() { ex.Message }
                };
            }
        }

        public async Task<TokenResponse> Registration(RegistrationInfo registration)
        {
            try
            {
                HttpResponseMessage responseMessage = await this.PostAsJsonAsync($"{baseUrl}{_api}/register", registration);

                if(responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<TokenResponse>();
                }

                List<string> allErrors = new List<string>();
                string value = await responseMessage.Content.ReadAsStringAsync();
                if(value.Contains("errors"))
                {
                    var obj = new { errors = new Dictionary<string, string[]>() };
                    var validations = JsonConvert.DeserializeAnonymousType(value, obj);

                    List<string[]> allValidators = validations.errors.Values.ToList();

                    allValidators.ForEach(stringList => stringList.ForEach(singleError => allErrors.Add(singleError)));

                    return new TokenResponse
                    {
                        IsSuccess = false,
                        Messages = allErrors
                    };
                }

                object[] allObjects = await responseMessage.Content.ReadAsAsync<object[]>();
                string[] stringArray = Array.ConvertAll(allObjects, o => o.ToString());
                allErrors.AddRange(stringArray);
                return new TokenResponse
                {
                    IsSuccess = false,
                    Messages = allErrors
                };
            } catch(Exception ex)
            {
                return new TokenResponse
                {
                    IsSuccess = false,
                    Messages = new List<string>() { ex.Message }
                };
            }
        }
    }
}