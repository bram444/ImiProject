using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Entities;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GameInfoService
    {
        private static List<GamesInfo> inMemoryGame = new List<GamesInfo>
        {
            new GamesInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
             Name ="Splatoon",
             Price=59.99f,
            },
            new GamesInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
             Name ="Splatoon 2",
             Price=59.99f,
            }
        };
        public async Task<List<GamesInfo>> GetAllGames()
        {
            return await Task.FromResult(inMemoryGame);
        }

        public async Task<GamesInfo> GameById(Guid id)
        {
            return await Task.FromResult(inMemoryGame.Where(game => game.Id == id).First());
        }

        public void SaveGames(GamesInfo gamesInfo)
        {
            var gameInfoEdit = GameById(gamesInfo.Id);
            gameInfoEdit.Result.Name = gamesInfo.Name;
            gameInfoEdit.Result.Price = gamesInfo.Price;
        }

        public void AddGames(GamesInfo gamesInfo)
        {
            var gameInfoEdit = GameById(gamesInfo.Id);
            inMemoryGame.Add(gamesInfo);
        }

        public void RemoveGames(Guid id)
        {
            inMemoryGame.Remove(GameById(id).Result);
        }

    }
}
