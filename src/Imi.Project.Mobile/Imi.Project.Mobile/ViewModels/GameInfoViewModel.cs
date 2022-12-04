﻿using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;

        public GameInfoViewModel(IGameService gameService, IGenreService genreService, IPublisherService publisherService)
        {
            this.gameService = gameService;

            this.genreService = genreService;

            this.publisherService = publisherService;

            gameInfoValidator = new GameInfoValidator();
        }

        #region Properties

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

        private string publisherError;

        public string PublisherError
        {
            get { return publisherError; }
            set
            {
                publisherError = value;
                RaisePropertyChanged(nameof(PublisherError));
                RaisePropertyChanged(nameof(PublisherErrorVisible));
            }
        }

        public bool PublisherErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(PublisherError); }
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

        private bool enableFirstGenre;

        public bool EnableFirstGenre
        {
            get { return enableFirstGenre; }
            set
            {
                enableFirstGenre = value;
                RaisePropertyChanged(nameof(EnableFirstGenre));
            }
        }

        private bool enableSecondGenre;

        public bool EnableSecondGenre
        {
            get { return enableSecondGenre; }
            set
            {
                enableSecondGenre = value;
                RaisePropertyChanged(nameof(EnableSecondGenre));
            }
        }

        private bool enableThirdGenre;

        public bool EnableThirdGenre
        {
            get { return enableThirdGenre; }
            set
            {
                enableThirdGenre = value;
                RaisePropertyChanged(nameof(EnableThirdGenre));
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

        private bool enablePublisher;

        public bool EnablePublisher
        {
            get { return enablePublisher; }
            set
            {
                enablePublisher = value;
                RaisePropertyChanged(nameof(EnablePublisher));
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

        private ICollection<PublisherInfo> publishers;

        public ICollection<PublisherInfo> Publishers
        {
            get { return publishers; }
            set
            {
                publishers = value;
                RaisePropertyChanged(nameof(Publishers));
            }
        }

        private IEnumerable<GenreInfo> genres;

        public IEnumerable<GenreInfo> Genres
        {
            get { return genres; }
            set
            {
                genres = value;
                RaisePropertyChanged(nameof(Genres));
            }
        }

        private GenreInfo firstGenre;

        public GenreInfo FirstGenre
        {
            get { return firstGenre; }
            set
            {
                firstGenre = value;
                RaisePropertyChanged(nameof(FirstGenre));
            }
        }

        private GenreInfo secondGenre;

        public GenreInfo SecondGenre
        {
            get { return secondGenre; }
            set
            {
                secondGenre = value;
                RaisePropertyChanged(nameof(SecondGenre));
            }
        }

        private GenreInfo thirdGenre;

        public GenreInfo ThirdGenre
        {
            get { return thirdGenre; }
            set
            {
                thirdGenre = value;
                RaisePropertyChanged(nameof(ThirdGenre));
            }
        }

        private PublisherInfo chosenPublisher;

        public PublisherInfo ChosenPublisher
        {
            get { return chosenPublisher; }
            set
            {
                chosenPublisher = value;
                PublisherError = null;
                RaisePropertyChanged(nameof(ChosenPublisher));
            }
        }

        #endregion 

        public async override void Init(object initData)
        {
            if (initData != null)
            {
                currentGameInfo = initData as GamesInfo;

                await LoadGameStateAsync();
                SetRead();
            }
            else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        public ICommand SaveGameInfoCommand => new Command(
            async () =>
            {
                List<GenreInfo> allGenreId = new List<GenreInfo>
                {
                    FirstGenre,
                    SecondGenre,
                    ThirdGenre
                };

                allGenreId.RemoveAll(selectGenre => selectGenre.Id == Guid.Empty);

                List<Guid> gameGenreId = new List<Guid>();

                foreach (var genre in allGenreId.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                GamesInfo gameValidate = new GamesInfo
                {
                    Id = currentGameInfo.Id,
                    GenreId = gameGenreId,
                    PublisherId = ChosenPublisher.Id,
                    Name = GameName,
                    Price = 0
                };

                if (GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameValidate.Price = float.Parse(GamePrice);
                }

                if (Validate(gameValidate))
                {
                    await gameService.UpdateGame(gameValidate);
                    await CoreMethods.PopPageModel(gameValidate, false, true);
                }
            });

        public ICommand AddGameInfoCommand => new Command(
            async () =>
            {
                if (GameName == null)
                {
                    GameName = "";
                }

                List<GenreInfo> allGenreId = new List<GenreInfo>
                {
                    FirstGenre,
                    SecondGenre,
                    ThirdGenre
                };

                allGenreId.RemoveAll(selectGenre => selectGenre.Id == Guid.Empty);

                List<Guid> gameGenreId = new List<Guid>();

                foreach (var genre in allGenreId.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                GamesInfo gameEdit = new GamesInfo
                {
                    Id = Guid.NewGuid(),
                    Name = GameName,
                    Price = 0.0f,
                    GenreId = gameGenreId,
                    PublisherId = ChosenPublisher.Id
                };

                if (GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameEdit.Price = float.Parse(GamePrice);
                }

                if (Validate(gameEdit))
                {
                    await gameService.AddGames(gameEdit);
                    await CoreMethods.PopPageModel(gameEdit, false, true);
                }
            });

        public ICommand EditCommand => new Command(() =>
        {
            SetEdit();
        });

        public ICommand CancelCommand => new Command(async () =>
        {
            await LoadGameStateAsync();
            SetRead();
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await gameService.DeleteGame(currentGameInfo.Id);
            await CoreMethods.PopPageModel(new GamesInfo(), false, true);
        });

        private async Task LoadGameStateAsync()
        {
            PublisherId = Guid.Empty;

            GenreId = new List<Guid>
            {
                Guid.Empty
            };

            if (currentGameInfo != null)
            {
                GameName = currentGameInfo.Name;
                GamePrice = currentGameInfo.Price.ToString();
                PublisherId = currentGameInfo.PublisherId;
                GenreId = currentGameInfo.GenreId;

                List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
                {
                    Id= Guid.Empty,
                    Name="Select a publisher"
                }};

                foreach (PublisherInfo publisher in await publisherService.GetAllPublisher())
                {
                    selectPublisher.Add(publisher);
                }

                Publishers = selectPublisher;

                ChosenPublisher = Publishers.FirstOrDefault();

                if (publisherId != null || !Publishers.Any(publisher => publisher.Id == PublisherId))
                {
                    ChosenPublisher = Publishers.Where(publisher => publisher.Id == publisherId).Single();
                }

                List<GenreInfo> selectGenre = new List<GenreInfo> { new GenreInfo
                {
                    Id = Guid.Empty,
                    Name = "Select a genre"
                }};

                foreach (GenreInfo genre in await genreService.GetAllGenre())
                {
                    selectGenre.Add(genre);
                }

                Genres = selectGenre;

                FirstGenre = Genres.FirstOrDefault();
                SecondGenre = Genres.FirstOrDefault();
                ThirdGenre = Genres.FirstOrDefault();

                if (GenreId.Count > 0)
                {
                    FirstGenre = Genres.Where(allGenres => allGenres.Id == GenreId.ElementAt(0)).Single();
                    if (GenreId.Count > 1)
                    {
                        SecondGenre = Genres.Where(allGenres => allGenres.Id == GenreId.ElementAt(1)).Single();
                        if (GenreId.Count > 2)
                        {
                            ThirdGenre = Genres.Where(allGenres => allGenres.Id == GenreId.ElementAt(2)).Single();
                        }
                    }
                }
            }
        }

        private bool Validate(GamesInfo gamesInfo)
        {
            var validationContext = new ValidationContext<GamesInfo>(gamesInfo);
            var validationResult = gameInfoValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                switch (error.PropertyName)
                {
                    case nameof(gamesInfo.Name):
                        GameError = error.ErrorMessage;
                        break;

                    case nameof(gamesInfo.PublisherId):
                        PublisherError = error.ErrorMessage;
                        break;

                    case nameof(gamesInfo.Price):
                        GamePriceError = error.ErrorMessage;
                        break;

                    default:
                        break;
                }
            }
            return validationResult.IsValid;
        }

        private async void SetAdd()
        {
            Title = "New game";

            EnableEditData = true;
            EnableFirstGenre = true;
            EnableSecondGenre = true;
            EnableThirdGenre = true;
            EnablePublisher = true;

            VisableAdd = true;
            VisableCancel = false;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;

            List<GenreInfo> selectGenres = new List<GenreInfo> { new GenreInfo
            {
                Id = Guid.Empty,
                Name = "Select a genre"
            }};

            foreach (GenreInfo genre in await genreService.GetAllGenre())
            {
                selectGenres.Add(genre);
            }

            Genres = selectGenres;

            FirstGenre = Genres.FirstOrDefault();
            SecondGenre = Genres.FirstOrDefault();
            ThirdGenre = Genres.FirstOrDefault();

            List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
            {
                Id= Guid.Empty,
                Name="Select a publisher"
            }};

            foreach (PublisherInfo publisher in await publisherService.GetAllPublisher())
            {
                selectPublisher.Add(publisher);
            }

            Publishers = selectPublisher;

            ChosenPublisher = Publishers.FirstOrDefault();
        }

        private void SetRead()
        {
            if (currentGameInfo != null)
            {
                Title = currentGameInfo.Name;
            }

            EnableEditData = false;
            EnableFirstGenre = false;
            EnableSecondGenre = false;
            EnableThirdGenre = false;
            EnablePublisher = false;

            VisableAdd = false;
            VisableCancel = false;
            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;
        }

        private void SetEdit()
        {
            Title = "Edit " + currentGameInfo.Name;

            EnableEditData = true;
            EnableFirstGenre = true;
            EnableSecondGenre = true;
            EnableThirdGenre = true;
            EnablePublisher = true;

            VisableAdd = false;
            VisableCancel = true;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;
        }
    }
}