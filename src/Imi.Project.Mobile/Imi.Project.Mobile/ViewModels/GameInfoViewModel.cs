using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GameInfoViewModel: BaseEditListViewModel<GamesInfo, GenreInfo, IGameService, IGenreService, NewGameInfo, UpdateGameInfo, NewGenreInfo, UpdateGenreInfo>
    {
        private readonly IPublisherService PublisherService;

        public GameInfoViewModel(IGameService gameService, IGenreService genreService, IPublisherService publisherService)
            : base(gameService, genreService, new UpdateGameInfoValidator(), new NewGameInfoValidator())
        {
            PublisherService = publisherService;
        }

        #region Properties
        private string gamePrice;
        public string GamePrice
        {
            get
            {
                return gamePrice;
            }

            set
            {
                gamePrice = value;
                GamePriceError = null;
                ErrorAPI = null;
                RaisePropertyChanged(nameof(GamePrice));
            }
        }

        private string gamePriceError;
        public string GamePriceError
        {
            get
            {
                return gamePriceError;
            }

            set
            {
                gamePriceError = value;
                RaisePropertyChanged(nameof(GamePriceError));
            }
        }

        private PublisherInfo chosenPublisher;
        public PublisherInfo ChosenPublisher
        {
            get
            {
                return chosenPublisher;
            }

            set
            {
                chosenPublisher = value;
                PublisherError = null;
                ErrorAPI = null;
                RaisePropertyChanged(nameof(ChosenPublisher));
            }
        }

        private string publisherError;
        public string PublisherError
        {
            get
            {
                return publisherError;
            }

            set
            {
                publisherError = value;
                RaisePropertyChanged(nameof(PublisherError));
            }
        }

        private ObservableCollection<PublisherInfo> publishers;
        public ObservableCollection<PublisherInfo> Publishers
        {
            get
            {
                return publishers;
            }

            set
            {
                publishers = value;
                RaisePropertyChanged(nameof(Publishers));
            }
        }

        private bool enablePublisher;
        public bool EnablePublisher
        {
            get
            {
                return enablePublisher;
            }

            set
            {
                enablePublisher = value;
                RaisePropertyChanged(nameof(EnablePublisher));
            }
        }

        private Guid publisherId;
        public Guid PublisherId
        {
            get
            {
                return publisherId;
            }

            set
            {
                publisherId = value;
                RaisePropertyChanged(nameof(PublisherId));
            }
        }
        #endregion 

        public override void LoadState()
        {
            Name = CurrentItem.Name;
            GamePrice = CurrentItem.Price.ToString();
            PublisherId = CurrentItem.Publisher.Id;

            CurrentItemIdList = new ObservableCollection<Guid>(CurrentItem.Genres.Select(genres => genres.Id));

            List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
                {
                    Id= Guid.Empty,
                    Name="Select a publisher"
                }};

            foreach(PublisherInfo publisher in Task.Run(async () => await PublisherService.GetAll()).Result)
            {
                selectPublisher.Add(publisher);
            }

            Publishers = new ObservableCollection<PublisherInfo>(selectPublisher);

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

            LoadList(selectGenre);
        }

        public override ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
            {
                base.AddCommand.Execute(null);

                ObservableCollection<GenreInfo> allGenre = CurrentItemList;

                List<Guid> gameGenreId = new List<Guid>();

                foreach(GenreInfo genre in allGenre.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                NewGameInfo gameEdit = new NewGameInfo
                {
                    Name = Name,
                    Price = 0.0f,
                    GenreId = gameGenreId,
                    PublisherId = ChosenPublisher.Id
                };

                if(GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameEdit.Price = float.Parse(GamePrice);
                }

                ApiResponse<GamesInfo> apiResponse = await AddItem(gameEdit);
                ErrorAPI = string.Join(Environment.NewLine, apiResponse.Messages);
            });
            }
        }

        public override ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    ObservableCollection<GenreInfo> allGenre = CurrentItemList;

                    List<Guid> gameGenreId = new List<Guid>();

                    foreach(GenreInfo genre in allGenre.Distinct())
                    {
                        gameGenreId.Add(genre.Id);
                    }

                    UpdateGameInfo gameValidate = new UpdateGameInfo
                    {
                        Id = CurrentItem.Id,
                        GenreId = gameGenreId,
                        PublisherId = ChosenPublisher.Id,
                        Name = Name,
                        Price = 0
                    };

                    if(GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                    {
                        gameValidate.Price = float.Parse(GamePrice);
                    }

                    ApiResponse<GamesInfo> apiResponse = await SaveItem(gameValidate);
                    ErrorAPI = string.Join(Environment.NewLine, apiResponse.Messages);
                });
            }
        }

        public override ICommand AddPickerItem
        {
            get
            {
                return new Command(() =>
                {
                    TextPicker = "Add genre";

                    List<GenreInfo> genres = new List<GenreInfo>
                    {
                        new GenreInfo
                        {
                            Id = Guid.Empty,
                            Name="Select a genre"
                        }
                    };

                    base.AddPickerItem.Execute(genres);
                });
            }
        }

        public override ICommand DeletePickerItem
        {
            get
            {
                return new Command(() =>
                {
                    TextPicker = "Delete genre";

                    List<GenreInfo> genres = new List<GenreInfo>
                {
                    new GenreInfo
                    {
                        Id = Guid.Empty,
                        Name="Select a genre"
                    }
                };

                    base.DeletePickerItem.Execute(genres);
                });
            }
        }

        public override bool Validate(NewGameInfo gamesInfo)
        {
            ValidationContext<NewGameInfo> validationContext = new ValidationContext<NewGameInfo>(gamesInfo);
            ValidationResult validationResult = NewValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
            {
                switch(error.PropertyName)
                {
                    case nameof(gamesInfo.Name):
                        NameError = error.ErrorMessage;
                        break;

                    case nameof(gamesInfo.PublisherId):
                        PublisherError = error.ErrorMessage;
                        break;

                    case nameof(gamesInfo.Price):
                        GamePriceError = error.ErrorMessage;
                        break;

                    default:
                        NameError = "Unknown Error";
                        PublisherError = "Unknown Error";
                        GamePriceError = "Unknown Error";
                        break;
                }
            }

            return validationResult.IsValid;
        }

        public override bool Validate(UpdateGameInfo gamesInfo)
        {
            ValidationContext<UpdateGameInfo> validationContext = new ValidationContext<UpdateGameInfo>(gamesInfo);
            ValidationResult validationResult = UpdateValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
            {
                switch(error.PropertyName)
                {
                    case nameof(gamesInfo.Name):
                        NameError = error.ErrorMessage;
                        break;

                    case nameof(gamesInfo.PublisherId):
                        PublisherError = error.ErrorMessage;
                        break;

                    case nameof(gamesInfo.Price):
                        GamePriceError = error.ErrorMessage;
                        break;

                    default:
                        NameError = "Unknown Error";
                        PublisherError = "Unknown Error";
                        GamePriceError = "Unknown Error";
                        break;
                }
            }

            return validationResult.IsValid;
        }

        public override void SetAdd()
        {
            Title = "New game";

            EnablePublisher = true;

            List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
            {
                Id= Guid.Empty,
                Name="Select a publisher"
            }};

            foreach(PublisherInfo publisher in Task.Run(async () => await PublisherService.GetAll()).Result)
            {
                selectPublisher.Add(publisher);
            }

            Publishers = new ObservableCollection<PublisherInfo>(selectPublisher);

            ChosenPublisher = Publishers.FirstOrDefault();

            PublisherId = Guid.Empty;

            NewItem = new NewGameInfo
            {
                Name = "",
                Price = 0,
                PublisherId = Guid.Empty,
                GenreId = new List<Guid>()
            };

            base.SetAdd();
        }

        public override void SetRead()
        {
            Title = CurrentItem.Name;
            EnablePublisher = false;

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.Name;
            EnablePublisher = true;

            base.SetEdit();
        }
    }
}