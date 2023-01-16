using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GameInfoService: BaseService<GamesInfo, NewGameInfo, UpdateGameInfo>, IGameService
    {
        public GameInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Game")
        {
        }
    }
}