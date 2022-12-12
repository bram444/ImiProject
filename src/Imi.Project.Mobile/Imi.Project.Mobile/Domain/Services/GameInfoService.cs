using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GameInfoService: BaseService<GamesInfo>, IGameService
    {
        public GameInfoService(CustomHttpClient customHttpClient):base(customHttpClient,"/api/Game")
        {
        }
    }
}