using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IGameService
    {
        Task<List<GamesInfo>> GetAllGames();

        Task<GamesInfo> GameById(Guid id);

        Task<GamesInfo> UpdateGame(GamesInfo game);
               
        Task<GamesInfo> AddGames(GamesInfo game);

        Task<GamesInfo> DeleteGame(Guid id);

    }
}
