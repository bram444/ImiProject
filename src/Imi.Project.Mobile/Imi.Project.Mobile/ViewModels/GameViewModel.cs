using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class GameViewModel: BaseViewModel<GamesInfo, IGameService, GameInfoViewModel>
    {
        public GameViewModel(IGameService gameService) : base(gameService)
        { }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Games";
        }
    }
}