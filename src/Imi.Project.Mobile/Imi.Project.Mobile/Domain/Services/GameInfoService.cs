using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GameInfoService: BaseService<GamesInfo>, IGameService
    {
        public GameInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Game")
        {
        }
    }
}