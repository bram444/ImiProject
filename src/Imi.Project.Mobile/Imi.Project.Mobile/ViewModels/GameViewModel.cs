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
    public class GameViewModel: FreshBasePageModel
    {
        private readonly IGameService gameService;
        private GamesInfo currentGameInfo;

        public GameViewModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        #region Properties

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

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

        private string gameName;
        public string GameName
        {
            get => gameName;
            set
            {
                gameName = value;
                RaisePropertyChanged(nameof(GameName));
            }
        }

        private float gamePrice;
        public float GamePrice
        {
            get => gamePrice;
            set
            {
                gamePrice = value;
                RaisePropertyChanged(nameof(GamePrice));
            }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get => visableAdd;
            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        #endregion

        public override async void Init(object initData)
        {
            base.Init(initData);

            currentGameInfo = initData as GamesInfo;
            VisableAdd = false;

            await RefreshGame();
        }

        public override async void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            if(initData is GamesInfo)
            {
                currentGameInfo = initData as GamesInfo;
            }
            VisableAdd = false;

            await RefreshGame();
        }

        private async Task RefreshGame()
        {
            Title = "Loading";

            GamesInfo = null;

            GamesInfo = new ObservableCollection<GamesInfo>(await gameService.GetAllGames());

            VisableAdd = true;

            Title = "Games";

            currentGameInfo = new GamesInfo
            {
                Id = Guid.NewGuid()
            };

            LoadGameState();
        }

        public ICommand AddGameItem => new Command<GamesInfo>(
            async (GamesInfo game) =>
            {
                SaveGameState();
                await CoreMethods.PushPageModel<GameInfoViewModel>(game);
            });

        private void LoadGameState()
        {
            GamePrice = currentGameInfo.Price;
            GameName = currentGameInfo.Name;
        }
        private void SaveGameState()
        {
            currentGameInfo.Price = GamePrice;
            currentGameInfo.Name = GameName;
        }
    }
}