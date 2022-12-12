using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GameViewModel: BaseViewModel<GamesInfo, IGameService>
    {
        public GameViewModel(IGameService gameService):base(gameService)
        {
        }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Games";
        }

        public ICommand AddGameItem => new Command<GamesInfo>(
            async (GamesInfo game) =>
            {
                await CoreMethods.PushPageModel<GameInfoViewModel>(game);
            });
    }
}