using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GenreInfoService: IGenreService
    {
        private readonly string baseUrl = Constants.baseUrl;
        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public GenreInfoService(CustomHttpClient customHttpClient)
        {
            _httpClient = customHttpClient;
        }

        public async Task<IEnumerable<GenreInfo>> GetAllGenre()
        {
            return await _httpClient.GetApiResult<List<GenreInfo>>($"{baseUrl}/api/Genre/");
        }

        public async Task<GenreInfo> GenreById(Guid id)
        {
            return await _httpClient.GetApiResult<GenreInfo>($"{baseUrl}/api/Genre/{id}");
        }

        public async Task<GenreInfo> UpdateGenre(GenreInfo genre)
        {
            return await _httpClient.PutCallApi<GenreInfo, GenreInfo>($"{baseUrl}/api/Genre/", genre);
        }

        public async Task<GenreInfo> DeleteGenre(Guid id)
        {
            return await _httpClient.DeleteCallApi<GenreInfo>($"{baseUrl}/api/Genre/{id}");
        }

        public async Task<GenreInfo> AddGenre(GenreInfo genre)
        {
            return await _httpClient.PostCallApi<GenreInfo, GenreInfo>($"{baseUrl}/api/Genre", genre);
        }
    }
}