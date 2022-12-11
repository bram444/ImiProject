using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GameInfoViewModel: BaseInfoViewModel
    {
        private GamesInfo currentGameInfo;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;

        public GameInfoViewModel(IGameService gameService, IGenreService genreService, IPublisherService publisherService)
            :base(gameService)
        {
            this.genreService = genreService;
            this.publisherService = publisherService;

            InfoValidator = new GameInfoValidator();
        }

        #region Properties
        private string gamePrice;
        public string GamePrice
        {
            get => gamePrice;
            set
            {
                gamePrice = value;
                GamePriceError = null;
                RaisePropertyChanged(nameof(GamePrice));
            }
        }

        private string publisherError;
        public string PublisherError
        {
            get => publisherError;
            set
            {
                publisherError = value;
                RaisePropertyChanged(nameof(PublisherError));
                RaisePropertyChanged(nameof(PublisherErrorVisible));
            }
        }

        public bool PublisherErrorVisible => !string.IsNullOrWhiteSpace(PublisherError);

        private string gamePriceError;
        public string GamePriceError
        {
            get => gamePriceError;
            set
            {
                gamePriceError = value;
                RaisePropertyChanged(nameof(GamePriceError));
                RaisePropertyChanged(nameof(GamePriceErrorVisible));
            }
        }

        public bool GamePriceErrorVisible => !string.IsNullOrWhiteSpace(GamePriceError);

        private bool enableFirstGenre;
        public bool EnableFirstGenre
        {
            get => enableFirstGenre;
            set
            {
                enableFirstGenre = value;
                RaisePropertyChanged(nameof(EnableFirstGenre));
            }
        }

        private bool enableSecondGenre;
        public bool EnableSecondGenre
        {
            get => enableSecondGenre;
            set
            {
                enableSecondGenre = value;
                RaisePropertyChanged(nameof(EnableSecondGenre));
            }
        }

        private bool enableThirdGenre;
        public bool EnableThirdGenre
        {
            get => enableThirdGenre;
            set
            {
                enableThirdGenre = value;
                RaisePropertyChanged(nameof(EnableThirdGenre));
            }
        }

        private bool enablePublisher;
        public bool EnablePublisher
        {
            get => enablePublisher;
            set
            {
                enablePublisher = value;
                RaisePropertyChanged(nameof(EnablePublisher));
            }
        }

        private Guid publisherId;
        public Guid PublisherId
        {
            get => publisherId;
            set
            {
                publisherId = value;
                RaisePropertyChanged(nameof(PublisherId));
            }
        }

        private ICollection<Guid> genreId;
        public ICollection<Guid> GenreId
        {
            get => genreId;
            set
            {
                genreId = value;
                RaisePropertyChanged(nameof(GenreId));
            }
        }

        private ICollection<PublisherInfo> publishers;
        public ICollection<PublisherInfo> Publishers
        {
            get => publishers;
            set
            {
                publishers = value;
                RaisePropertyChanged(nameof(Publishers));
            }
        }

        private IEnumerable<GenreInfo> genres;
        public IEnumerable<GenreInfo> Genres
        {
            get => genres;
            set
            {
                genres = value;
                RaisePropertyChanged(nameof(Genres));
            }
        }

        private GenreInfo firstGenre;
        public GenreInfo FirstGenre
        {
            get => firstGenre;
            set
            {
                firstGenre = value;
                RaisePropertyChanged(nameof(FirstGenre));
            }
        }

        private GenreInfo secondGenre;
        public GenreInfo SecondGenre
        {
            get => secondGenre;
            set
            {
                secondGenre = value;
                RaisePropertyChanged(nameof(SecondGenre));
            }
        }

        private GenreInfo thirdGenre;
        public GenreInfo ThirdGenre
        {
            get => thirdGenre;
            set
            {
                thirdGenre = value;
                RaisePropertyChanged(nameof(ThirdGenre));
            }
        }

        private PublisherInfo chosenPublisher;
        public PublisherInfo ChosenPublisher
        {
            get => chosenPublisher;
            set
            {
                chosenPublisher = value;
                PublisherError = null;
                RaisePropertyChanged(nameof(ChosenPublisher));
            }
        }

        #endregion 

        public override async void Init(object initData)
        {
            if(initData != null)
            {
                currentGameInfo = initData as GamesInfo;

                await LoadGameStateAsync();
                SetRead();
            } else
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

                foreach(GenreInfo genre in allGenreId.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                GamesInfo gameValidate = new GamesInfo
                {
                    Id = currentGameInfo.Id,
                    GenreId = gameGenreId,
                    PublisherId = ChosenPublisher.Id,
                    Name = this.Name,
                    Price = 0
                };

                if(GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameValidate.Price = float.Parse(GamePrice);
                }

                if(Validate(gameValidate))
                {
                    await GameService.UpdateGame(gameValidate);
                    await CoreMethods.PopPageModel(gameValidate, false, true);
                }
            });

        public ICommand AddGameInfoCommand => new Command(
            async () =>
            {
                if(Name == null)
                {
                    Name = "";
                }

                List<GenreInfo> allGenreId = new List<GenreInfo>
                {
                    FirstGenre,
                    SecondGenre,
                    ThirdGenre
                };

                allGenreId.RemoveAll(selectGenre => selectGenre.Id == Guid.Empty);

                List<Guid> gameGenreId = new List<Guid>();

                foreach(GenreInfo genre in allGenreId.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                GamesInfo gameEdit = new GamesInfo
                {
                    Id = Guid.NewGuid(),
                    Name = this.Name,
                    Price = 0.0f,
                    GenreId = gameGenreId,
                    PublisherId = ChosenPublisher.Id
                };

                if(GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameEdit.Price = float.Parse(GamePrice);
                }

                if(Validate(gameEdit))
                {
                    await GameService.AddGames(gameEdit);
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
            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await GameService.DeleteGame(currentGameInfo.Id);
            await CoreMethods.PopPageModel(new GamesInfo(), false, true);
        });

        private async Task LoadGameStateAsync()
        {
            PublisherId = Guid.Empty;

            GenreId = new List<Guid>
            {
                Guid.Empty
            };

            if(currentGameInfo != null)
            {
                Name = currentGameInfo.Name;
                GamePrice = currentGameInfo.Price.ToString();
                PublisherId = currentGameInfo.PublisherId;
                GenreId = currentGameInfo.GenreId;

                List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
                {
                    Id= Guid.Empty,
                    Name="Select a publisher"
                }};

                foreach(PublisherInfo publisher in await publisherService.GetAllPublisher())
                {
                    selectPublisher.Add(publisher);
                }

                Publishers = selectPublisher;

                ChosenPublisher = Publishers.FirstOrDefault();

                if(publisherId != null || !Publishers.Any(publisher => publisher.Id == PublisherId))
                {
                    ChosenPublisher = Publishers.Where(publisher => publisher.Id == publisherId).Single();
                }

                List<GenreInfo> selectGenre = new List<GenreInfo> { new GenreInfo
                {
                    Id = Guid.Empty,
                    Name = "Select a genre"
                }};

                foreach(GenreInfo genre in await genreService.GetAllGenre())
                {
                    selectGenre.Add(genre);
                }

                Genres = selectGenre;

                FirstGenre = Genres.FirstOrDefault();
                SecondGenre = Genres.FirstOrDefault();
                ThirdGenre = Genres.FirstOrDefault();

                if(GenreId.Count > 0)
                {
                    FirstGenre = Genres.Where(allGenres => allGenres.Id == GenreId.ElementAt(0)).Single();
                    if(GenreId.Count > 1)
                    {
                        SecondGenre = Genres.Where(allGenres => allGenres.Id == GenreId.ElementAt(1)).Single();
                        if(GenreId.Count > 2)
                        {
                            ThirdGenre = Genres.Where(allGenres => allGenres.Id == GenreId.ElementAt(2)).Single();
                        }
                    }
                }
            }
        }

        private bool Validate(GamesInfo gamesInfo)
        {
            ValidationContext<GamesInfo> validationContext = new ValidationContext<GamesInfo>(gamesInfo);
            FluentValidation.Results.ValidationResult validationResult = InfoValidator.Validate(validationContext);

            foreach(FluentValidation.Results.ValidationFailure error in validationResult.Errors)
            {
                switch(error.PropertyName)
                {
                    case nameof(gamesInfo.Name):
                        Name = error.ErrorMessage;
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

        public override async void SetAdd()
        {
            Title = "New game";

            EnableFirstGenre = true;
            EnableSecondGenre = true;
            EnableThirdGenre = true;
            EnablePublisher = true;


            List<GenreInfo> selectGenres = new List<GenreInfo> { new GenreInfo
            {
                Id = Guid.Empty,
                Name = "Select a genre"
            }};

            foreach(GenreInfo genre in await genreService.GetAllGenre())
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

            foreach(PublisherInfo publisher in await publisherService.GetAllPublisher())
            {
                selectPublisher.Add(publisher);
            }

            Publishers = selectPublisher;

            ChosenPublisher = Publishers.FirstOrDefault();

            base.SetAdd();
        }

        public override void SetRead()
        {
            if(currentGameInfo != null)
            {
                Title = currentGameInfo.Name;
            }

            EnableFirstGenre = false;
            EnableSecondGenre = false;
            EnableThirdGenre = false;
            EnablePublisher = false;

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + currentGameInfo.Name;

            EnableFirstGenre = true;
            EnableSecondGenre = true;
            EnableThirdGenre = true;
            EnablePublisher = true;
            
            base.SetEdit();
        }
    }
}