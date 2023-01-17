using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Interface
{
    public class BaseService<T, N, U>: IBaseService<T, N, U>
    {
        private readonly string baseUrl = Constants.baseUrl;
        private readonly CustomHttpClient _httpClient = new CustomHttpClient();
        private readonly string Api;
        public BaseService(CustomHttpClient httpClient, string api)
        {
            _httpClient = httpClient;
            Api = api;
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _httpClient.GetApiResult<IEnumerable<T>>($"{baseUrl}{Api}/");
        }

        public async Task<T> GetById(Guid id)
        {
            return await _httpClient.GetApiResult<T>($"{baseUrl}{Api}/{id}");
        }

        public async Task<ApiResponse<T>> Update(U game)
        {
            return await _httpClient.PutCallApi<T, U>($"{baseUrl}{Api}/", game);
        }

        public async Task<ApiResponse<T>> Delete(Guid id)
        {
            return await _httpClient.DeleteCallApi<T>($"{baseUrl}{Api}/{id}");
        }

        public virtual async Task<ApiResponse<T>> Add(N game)
        {
            return await _httpClient.PostCallApi<T, N>($"{baseUrl}{Api}", game);
        }
    }
}
