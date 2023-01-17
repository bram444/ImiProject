using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;

namespace Imi.Project.Mobile.Domain.Interface
{
    public class GameInfoService: BaseService<GamesInfo, NewGameInfo, UpdateGameInfo>, IGameService
    {
        public GameInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Game")
        {
        }
    }
}