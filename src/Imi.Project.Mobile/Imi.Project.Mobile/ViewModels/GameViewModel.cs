using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GameViewModel : FreshBasePageModel
    {
        private readonly IGameService gameService;

        private GamesInfo currentGameInfo;

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private IEnumerable<GamesInfo> gamesInfo;
        public IEnumerable<GamesInfo> GamesInfo
        {
            get { return gamesInfo; }
            set
            {
                gamesInfo = value;
                RaisePropertyChanged(nameof(GamesInfo));
            }
        }

        private string gameName;

        public string GameName
        {
            get { return gameName; }
            set
            {
                gameName = value;
                RaisePropertyChanged(nameof(GameName));
            }
        }

        private float gamePrice;

        public float GamePrice
        {
            get { return gamePrice; }
            set
            {
                gamePrice = value;
                RaisePropertyChanged(nameof(GamePrice));
            }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get { return visableAdd; }
            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        public GameViewModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            currentGameInfo = initData as GamesInfo;
            VisableAdd = false;

            await RefreshGame();
        }

        public async override void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            VisableAdd = false;

            if (initData is GamesInfo)
            {
                currentGameInfo = initData as GamesInfo;
            }
            await RefreshGame();
        }

        private async Task RefreshGame()
        {
            GamesInfo = null;

            Title = "Loading";


            GamesInfo = await gameService.GetAllGames();
            VisableAdd = true;

                Title = "Games";
                currentGameInfo = new GamesInfo
                {
                    Id = Guid.NewGuid()
                };
            //if (currentGameInfo != null &&currentGameInfo.Id != Guid.Empty)
            //{

            //    //currentGameInfo = await gameService.GameById(currentGameInfo.Id);
            //}
            //else
            //{
            //    currentGameInfo = new GamesInfo
            //    {
            //        Id = Guid.NewGuid()
            //    };
            //}
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
