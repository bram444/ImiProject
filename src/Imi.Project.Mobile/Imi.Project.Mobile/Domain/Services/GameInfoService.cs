using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class GameInfoService:IGameService
    {
        private static List<GamesInfo> inMemoryGame = new List<GamesInfo>
        {
            new GamesInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
             Name ="Splatoon",
             Price=59.99f,
            },
            new GamesInfo{
             Id= Guid.Parse("00000000-0000-0000-0000-000000000002"),
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

        public Task<GamesInfo> UpdateGame(GamesInfo game)
        {
            var gameInfoEdit = GameById(game.Id);
            gameInfoEdit.Result.Name = game.Name;
            gameInfoEdit.Result.Price = game.Price;

            return gameInfoEdit;
        }

        public Task DeleteGame(Guid id)
        {
            inMemoryGame.Remove(GameById(id).Result);
            return Task.CompletedTask;
        }

        public Task<GamesInfo> AddGames(GamesInfo game)
        {
            inMemoryGame.Add(game);
            return GameById(game.Id);
        }
    }
}
