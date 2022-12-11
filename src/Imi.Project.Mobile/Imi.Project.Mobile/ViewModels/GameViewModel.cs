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
    public class GameViewModel: BaseViewModel
    {
        private readonly IGameService gameService;

        public GameViewModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        #region Properties
        private ObservableCollection<GamesInfo> gamesInfo;
        public ObservableCollection<GamesInfo> GamesInfo
        {
            get => gamesInfo;
            set
            {
                gamesInfo = value;
                RaisePropertyChanged(nameof(GamesInfo));
            }
        }
        #endregion

        public override async void Init(object initData)
        {
            base.Init(initData);

            await Refresh();
        }

        public override async void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            await Refresh();
        }

        public override async Task Refresh()
        {
            VisableAdd = false;

            Title = "Loading";

            GamesInfo = null;

            GamesInfo = new ObservableCollection<GamesInfo>(await gameService.GetAllGames());

            VisableAdd = true;

            Title = "Games";
        }

        public ICommand AddGameItem => new Command<GamesInfo>(
            async (GamesInfo game) =>
            {
                await CoreMethods.PushPageModel<GameInfoViewModel>(game);
            });
    }
}