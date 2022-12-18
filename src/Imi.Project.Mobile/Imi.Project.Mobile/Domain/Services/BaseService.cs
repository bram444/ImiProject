using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class BaseService<T>: IBaseService<T>
    {
        private readonly string baseUrl = Constants.baseUrl;
        private readonly CustomHttpClient _httpClient = new CustomHttpClient();
        private readonly string Api;
        public BaseService(CustomHttpClient httpClient, string api)
        {
            _httpClient = httpClient;
            Api = api;
        }

        public async Task<IEnumerable<T>> GetAll() => await _httpClient.GetApiResult<IEnumerable<T>>($"{baseUrl}{Api}/");

        public async Task<T> GetById(Guid id) => await _httpClient.GetApiResult<T>($"{baseUrl}{Api}/{id}");

        public async Task<T> Update(T game) => await _httpClient.PutCallApi<T, T>($"{baseUrl}{Api}/", game);

        public async Task<T> Delete(Guid id) => await _httpClient.DeleteCallApi<T>($"{baseUrl}{Api}/{id}");

        public async Task<T> Add(T game) => await _httpClient.PostCallApi<T, T>($"{baseUrl}{Api}", game);

    }
}
