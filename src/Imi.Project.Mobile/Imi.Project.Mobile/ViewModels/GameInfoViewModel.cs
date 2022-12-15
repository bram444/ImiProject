using FluentValidation;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
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
    public class GameInfoViewModel: BaseEditListViewModel<GamesInfo, GenreInfo, IGameService, IGenreService>
    {
        private readonly IPublisherService PublisherService;

        public GameInfoViewModel(IGameService gameService, IGenreService genreService, IPublisherService publisherService)
            : base(gameService, genreService, new GameInfoValidator())
        {
            PublisherService = publisherService;
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

        private string gamePriceError;
        public string GamePriceError
        {
            get => gamePriceError;
            set
            {
                gamePriceError = value;
                RaisePropertyChanged(nameof(GamePriceError));
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

        private string publisherError;
        public string PublisherError
        {
            get => publisherError;
            set
            {
                publisherError = value;
                RaisePropertyChanged(nameof(PublisherError));
            }
        }

        private ObservableCollection<PublisherInfo> publishers;
        public ObservableCollection<PublisherInfo> Publishers
        {
            get => publishers;
            set
            {
                publishers = value;
                RaisePropertyChanged(nameof(Publishers));
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
        #endregion 

        public override void LoadState()
        {
            Name = CurrentItem.Name;
            GamePrice = CurrentItem.Price.ToString();
            PublisherId = CurrentItem.PublisherId;
            CurrentItemIdList = new ObservableCollection<Guid>(CurrentItem.GenreId);

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

        public override ICommand AddCommand => new Command(() =>
            {
                base.AddCommand.Execute(null);

                var allGenre = CurrentItemList;

                List<Guid> gameGenreId = new List<Guid>();

                foreach(GenreInfo genre in allGenre.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                GamesInfo gameEdit = new GamesInfo
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Price = 0.0f,
                    GenreId = gameGenreId,
                    PublisherId = ChosenPublisher.Id
                };

                if(GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameEdit.Price = float.Parse(GamePrice);
                }

                AddItem(gameEdit);
            });

        public override ICommand SaveCommand => new Command(() =>
            {
                var allGenre = CurrentItemList;

                List<Guid> gameGenreId = new List<Guid>();

                foreach(GenreInfo genre in allGenre.Distinct())
                {
                    gameGenreId.Add(genre.Id);
                }

                GamesInfo gameValidate = new GamesInfo
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

                SaveItem(gameValidate);
            });

        public override ICommand AddPickerItem => new Command(() =>
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

        public override ICommand DeletePickerItem => new Command(() =>
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

        public override bool Validate(GamesInfo gamesInfo)
        {
            ValidationContext<GamesInfo> validationContext = new ValidationContext<GamesInfo>(gamesInfo);
            FluentValidation.Results.ValidationResult validationResult = InfoValidator.Validate(validationContext);

            foreach(FluentValidation.Results.ValidationFailure error in validationResult.Errors)
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

            CurrentItem = new GamesInfo
            {
                Id = Guid.Empty,
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