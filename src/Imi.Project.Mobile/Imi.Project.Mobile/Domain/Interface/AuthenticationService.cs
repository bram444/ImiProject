﻿using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Imi.Project.Mobile.Domain.Interface
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly string baseUrl = Constants.baseUrl;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _api;

        public AuthenticationService()
        {
            _api = "/api/Authentication";
        }

        public async Task<TokenResponse> Login(LogInInfo login)
        {
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync($"{baseUrl}{_api}/login", login);

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
                HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync($"{baseUrl}{_api}/register", registration);

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