using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GameInfoService: IGameService
    {
        string baseUrl = Constants.baseUrl;

        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public GameInfoService(CustomHttpClient customHttpClient)
        {
            _httpClient = customHttpClient;
        }

        public async Task<IEnumerable<GamesInfo>> GetAllGames()
        {
            return await _httpClient.GetApiResult<IEnumerable<GamesInfo>>($"{baseUrl}/api/Game/");
        }

        public async Task<GamesInfo> GameById(Guid id)
        {
            return await _httpClient.GetApiResult<GamesInfo>($"{baseUrl}/api/Game/{id}");
        }

        public async Task<GamesInfo> UpdateGame(GamesInfo game)
        {
            return await _httpClient.PutCallApi<GamesInfo, GamesInfo>($"{baseUrl}/api/Game/", game);
        }

        public async Task<GamesInfo> DeleteGame(Guid id)
        {
            return await _httpClient.DeleteCallApi<GamesInfo>($"{baseUrl}/api/Game/{id}");

        }

        public async Task<GamesInfo> AddGames(GamesInfo game)
        {
            return await _httpClient.PostCallApi<GamesInfo, GamesInfo>($"{baseUrl}/api/Game", game);
        }
    }
}
