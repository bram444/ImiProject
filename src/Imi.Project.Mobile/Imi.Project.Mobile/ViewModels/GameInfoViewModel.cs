using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Imi.Project.Mobile.ViewModels
{
    public class GameInfoViewModel : FreshBasePageModel
    {
        private GamesInfo currentGameInfo;
        private readonly IValidator gameInfoValidator;

        private readonly IGameService gameService;

        public GameInfoViewModel(IGameService gameService)
        {
            this.gameService = gameService;

            gameInfoValidator = new GameInfoValidator();
        }

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

        private string gameName;

        public string GameName
        {
            get { return gameName; }
            set
            {
                gameName = value;
                GameError = null;
                RaisePropertyChanged(nameof(GameName));
            }
        }

        private string gamePrice;

        public string GamePrice
        {
            get { return gamePrice; }
            set
            {
                this.gamePrice = value;
                GamePriceError = null;
                RaisePropertyChanged(nameof(GamePrice));
            }
        }

        private string gameError;

        public string GameError
        {
            get { return gameError; }
            set
            {
                gameError = value;
                RaisePropertyChanged(nameof(GameError));
                RaisePropertyChanged(nameof(GameErrorVisible));

            }
        }

        public bool GameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(GameError); }
        }

        private string gamePriceError;

        public string GamePriceError
        {
            get { return gamePriceError; }
            set
            {
                gamePriceError = value;
                RaisePropertyChanged(nameof(GamePriceError));
                RaisePropertyChanged(nameof(GamePriceErrorVisible));

            }
        }

        public bool GamePriceErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(GamePriceError); }
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

        private bool visableCancel;
        public bool VisableCancel
        {
            get { return visableCancel; }
            set
            {
                visableCancel = value;
                RaisePropertyChanged(nameof(VisableCancel));
            }
        }

        private bool visableEdit;
        public bool VisableEdit
        {
            get { return visableEdit; }
            set
            {
                visableEdit = value;
                RaisePropertyChanged(nameof(VisableEdit));
            }
        }

        private bool visableDelete;
        public bool VisableDelete
        {
            get { return visableDelete; }
            set
            {
                visableDelete = value;
                RaisePropertyChanged(nameof(VisableDelete));
            }
        }

        private bool visableSave;
        public bool VisableSave
        {
            get { return visableSave; }
            set
            {
                visableSave = value;
                RaisePropertyChanged(nameof(VisableSave));
            }
        }

        private bool enableEditData;
        public bool EnableEditData
        {
            get { return enableEditData; }
            set
            {
                enableEditData = value;
                RaisePropertyChanged(nameof(EnableEditData));
            }
        }

        private Guid publisherId;

        public Guid PublisherId
        {
            get { return publisherId; }
            set
            {
                publisherId = value;
                RaisePropertyChanged(nameof(PublisherId));
            }
        }

        private ICollection<Guid> genreId;

        public ICollection<Guid> GenreId
        {
            get { return genreId; }
            set
            {
                genreId = value;
                RaisePropertyChanged(nameof(GenreId));
            }
        }


        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentGameInfo = initData as GamesInfo;

                Title =currentGameInfo.Name;
                LoadGameState();
                SetRead();

            }
            else
            {
                Title = "New game";
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadGameState()
        {
            GameName = null;
            GamePrice = null;
            PublisherId = Guid.Empty;
            GenreId = null;

            if (currentGameInfo != null)
            {
                GameName = currentGameInfo.Name;
                GamePrice = currentGameInfo.Price.ToString();
                PublisherId = currentGameInfo.PublisherId;
                GenreId = currentGameInfo.GenreId;
            }
        }

        private void SaveGameState()
        {
            currentGameInfo.Price = float.Parse(GamePrice);
            currentGameInfo.Name = GameName;
            currentGameInfo.PublisherId = PublisherId;
            currentGameInfo.GenreId = GenreId;
        }

        public ICommand SaveGameInfoCommand => new Command(
            async () =>
            {
                SaveGameState();

                if (Validate(currentGameInfo))
                {
                    if (float.TryParse(GamePrice, out float isfloat))
                    {
                        currentGameInfo.Price = float.Parse(GamePrice);
                        if (currentGameInfo.Price < 0.0f)
                        {
                            GamePriceError = "Price cant be negative";
                        }
                        else
                        {
                            await gameService.UpdateGame(currentGameInfo);
                            await CoreMethods.PopPageModel(currentGameInfo, false, true);
                        }
                    }
                    else
                    {
                        GamePriceError = "Give a valid number";
                    }
                }
            });

        public ICommand AddGameInfoCommand => new Command(
            async () =>
            {
                if (GameName == null)
                {
                    GameName = "";
                }

                GamesInfo gameEdit = new GamesInfo
                {
                    Id = Guid.NewGuid(),
                    Name = GameName,
                    Price = 0.0f
                };

                if (Validate(gameEdit))
                {
                    if (float.TryParse(GamePrice, out float isfloat))
                    {
                        gameEdit.Price = float.Parse(GamePrice);
                        if(gameEdit.Price < 0.0f)
                        {
                            GamePriceError = "Price cant be negative";
                        }
                        else
                        {
                        await gameService.AddGames(gameEdit);
                        await CoreMethods.PopPageModel(gameEdit, false, true);
                        }

                    }
                    else
                    {
                        GamePriceError = "Give a valid number";
                    }
                }
                else if(float.TryParse(GamePrice, out float isfloat))
                {
                    GamePriceError = "Give a valid number";
                }
            });

        public ICommand EditCommand => new Command(() =>
        {
            SetEdit();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            LoadGameState();
            SetRead();
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await gameService.DeleteGame(currentGameInfo.Id);
            await CoreMethods.PopPageModel(new GamesInfo(),false,true);
        });

        private bool Validate(GamesInfo gamesInfo)
        {
            var validationContext = new ValidationContext<GamesInfo>(gamesInfo);
            var validationResult = gameInfoValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(gamesInfo.Name))
                {
                    GameError = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private void SetAdd()
        {
            VisableAdd = true;
            VisableCancel = false;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;
        }

        private void SetRead()
        {
            if (currentGameInfo!=null)
            { 
                Title = currentGameInfo.Name;
        }
            VisableAdd = false;
            VisableCancel = false;

            EnableEditData = false;

            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;
        }

        private void SetEdit()
        {
            Title = "Edit " + currentGameInfo.Name;

            VisableAdd = false;
            VisableCancel = true;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;
        }

    }
}
