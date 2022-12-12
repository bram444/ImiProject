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
            : base(gameService)
        {
            this.genreService = genreService;
            this.publisherService = publisherService;

            InfoValidator = new GameInfoValidator();
        }

        #region Properties
        private int columnSpanAdd;
        public int ColumnSpanAdd
        {
            get => columnSpanAdd;
            set
            {
                columnSpanAdd = value;
                RaisePropertyChanged(nameof(ColumnSpanAdd));
            }
        }

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

        private string textPicker;
        public string TextPicker
        {
            get => textPicker;
            set
            {
                textPicker = value;
                RaisePropertyChanged(nameof(TextPicker));
            }
        }

        private string listSave;
        public string ListSave
        {
            get => listSave;
            set
            {
                listSave = value;
                RaisePropertyChanged(nameof(ListSave));
            }
        }

        private string listError;
        public string ListError
        {
            get => listError;
            set
            {
                listError= value;
                RaisePropertyChanged(nameof(ListError));
            }
        }

        private bool createItem;
        public bool CreateItem
        {
            get => createItem;
            set
            {
                createItem = value;
                RaisePropertyChanged(nameof(CreateItem));
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

        private bool visibleGenreList;
        public bool VisibleGenreList
        {
            get => visibleGenreList;
            set
            {
                visibleGenreList = value;
                RaisePropertyChanged(nameof(VisibleGenreList));
            }
        }

        private bool addGenre;
        public bool AddGenre
        {
            get => addGenre;
            set
            {
                addGenre = value;
                RaisePropertyChanged(nameof(AddGenre));
            }
        }

        private bool visableAddGenre;
        public bool VisableAddGenre
        {
            get => visableAddGenre;
            set
            {
                visableAddGenre = value;
                ColumnDelete = VisableAddGenre ? 1 : 0;
                ColumnSpanDelete = VisableAddGenre ? 1 : 2;
                RaisePropertyChanged(nameof(VisableAddGenre));
            }
        }

        private int columnSpanDelete;
        public int ColumnSpanDelete
        {
            get => columnSpanDelete;
            set
            {
                columnSpanDelete = value;
                RaisePropertyChanged(nameof(ColumnSpanDelete));
            }
        }

        private int columnDelete;
        public int ColumnDelete
        {
            get => columnDelete;
            set
            {
                columnDelete = value;
                RaisePropertyChanged(nameof(ColumnDelete));
            }
        }

        private bool visableDeleteGenre;
        public bool VisableDeleteGenre
        {
            get => visableDeleteGenre;
            set
            {
                visableDeleteGenre = value;
                ColumnSpanAdd = VisableDeleteGenre ? 1 : 2;
                RaisePropertyChanged(nameof(VisableDeleteGenre));
            }
        }

        private bool visableGenreSave;
        public bool VisableGenreSave
        {
            get => visableGenreSave;
            set
            {
                visableGenreSave = value;
                RaisePropertyChanged(nameof(VisableGenreSave));
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

        private ObservableCollection<Guid> genreId;
        public ObservableCollection<Guid> GenreId
        {
            get => genreId;
            set
            {
                genreId = value;
                RaisePropertyChanged(nameof(GenreId));
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

        private ObservableCollection<GenreInfo> genres;
        public ObservableCollection<GenreInfo> Genres
        {
            get => genres;
            set
            {
                genres = new ObservableCollection<GenreInfo>(value);
                HeightListGenres = Genres.Count() * 20;
                RaisePropertyChanged(nameof(Genres));
                RaisePropertyChanged(nameof(EnableGenreList));
            }
        }

        private int heightListGenres;
        public int HeightListGenres
        {
            get => heightListGenres;
            set
            {
                heightListGenres = value;
                RaisePropertyChanged(nameof(HeightListGenres));
            }
        }

        public bool EnableGenreList => Genres.Any();

        public bool EnableAddGenre => (Task.Run(async () => await genreService.GetAllGenre()).Result.Count() != GenreId.Count());

        private ObservableCollection<GenreInfo> genrePickList;
        public ObservableCollection<GenreInfo> GenrePickList
        {
            get => genrePickList;
            set
            {
                genrePickList = new ObservableCollection<GenreInfo>(value);
                RaisePropertyChanged(nameof(GenrePickList));
            }
        }

        private GenreInfo chosenGenre;
        public GenreInfo ChosenGenre
        {
            get => chosenGenre;
            set
            {
                chosenGenre = value;
                RaisePropertyChanged(nameof(ChosenGenre));
                ListError = "";
            }
        }

        private ObservableCollection<GenreInfo> genreEditList;
        public ObservableCollection<GenreInfo> GenreEditList
        {
            get => genreEditList;
            set
            {
                genreEditList = new ObservableCollection<GenreInfo>(value);
                RaisePropertyChanged(nameof(GenreEditList));
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

        public override void Init(object initData)
        {
            if(initData != null)
            {
                currentGameInfo = initData as GamesInfo;

                LoadGameState();
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
                var allGenre = Genres;

                List<Guid> gameGenreId = new List<Guid>();

                foreach(GenreInfo genre in allGenre.Distinct())
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

        public ICommand CancelCommand => new Command(() =>
        {
            LoadGameState();
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

        public ICommand AddGameGenre => new Command(() =>
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
            
            foreach(GenreInfo genre in Task.Run(async () => await genreService.GetAllGenre()).Result)
            {
                if(!GenreId.Contains(genre.Id))
                {
                    genres.Add(genre);
                }
            }

            GenrePickList = new ObservableCollection<GenreInfo>(genres);

            ChosenGenre = genres.First();

            VisibleGenreList = true;
            VisableGenreSave = true;
            AddGenre = true;
            VisableAddGenre=false;
            VisableDeleteGenre = false;
            VisableAdd=false;
            VisableCancel = false;
            VisableSave = false;
        });

        public ICommand DeleteGameGenre => new Command(() =>
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

                foreach(GenreInfo genre in Task.Run(async () => await genreService.GetAllGenre()).Result)
                {
                    if(GenreId.Contains(genre.Id))
                    {
                        genres.Add(genre);
                    }
                }

                GenrePickList = new ObservableCollection<GenreInfo>(genres);

                ChosenGenre = genres.First();

                VisableAdd = false;
                VisibleGenreList = true;
                VisableGenreSave = true;
                AddGenre = false;
                VisableCancel = false;
                VisableSave = false;
                VisableAddGenre = false;
                VisableDeleteGenre = false;
            });

        public ICommand SaveDeleteGameGenre => new Command(()=>
            {
                if(ChosenGenre.Id != Guid.Empty)
                {
                        var genrePlayedList = Genres;
                    if(AddGenre)
                    {
                        genrePlayedList.Add(ChosenGenre);
                        GenreId.Add(ChosenGenre.Id);

                    } else
                    {
                        genrePlayedList.Remove(genrePlayedList.Where(genre=>genre.Id==ChosenGenre.Id).Single());
                        GenreId.Remove(ChosenGenre.Id);
                    }

                    Genres = new ObservableCollection<GenreInfo>(genrePlayedList.OrderBy(genre=>genre.Id));

                if(CreateItem)
                    {
                        VisableAdd = true;
                    } else
                    {
                    VisableCancel = true;
                    VisableSave = true;
                    }
                    VisibleGenreList = false;
                    VisableGenreSave=false;
                    VisableAddGenre = EnableAddGenre;
                    VisableDeleteGenre = EnableGenreList;
                } else
                {
                    ListError = "Pick a valid genre";
                }


            });

        public ICommand CancelDeleteGameGenre => new Command(() =>
        {
            GenreId = new ObservableCollection<Guid>(currentGameInfo.GenreId);
            VisibleGenreList = false;
            VisableSave = true;
            VisableAddGenre = EnableAddGenre;
            VisableDeleteGenre = true;
            VisableGenreSave = false;
            if(CreateItem)
            {
                VisableAdd = true;
            } else
            {
                VisableCancel = true;
                VisableSave = true;
            }
        });


        private void LoadGameState()
        {
            PublisherId = Guid.Empty;

            GenreId = new ObservableCollection<Guid>
            {
                Guid.Empty
            };

            if(currentGameInfo != null)
            {
                Name = currentGameInfo.Name;
                GamePrice = currentGameInfo.Price.ToString();
                PublisherId = currentGameInfo.PublisherId;
                GenreId = new ObservableCollection<Guid>( currentGameInfo.GenreId);

                List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
                {
                    Id= Guid.Empty,
                    Name="Select a publisher"
                }};

                foreach(PublisherInfo publisher in Task.Run(async () => await publisherService.GetAllPublisher()).Result)
                {
                    selectPublisher.Add(publisher);
                }

                Publishers =new ObservableCollection<PublisherInfo>( selectPublisher);

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


                foreach(GenreInfo genre in Task.Run(async () => await genreService.GetAllGenre()).Result)
                {
                    selectGenre.Add(genre);
                }

                Genres = new ObservableCollection<GenreInfo>(selectGenre.Where(genre => GenreId.Contains(genre.Id)));
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

        public override void SetAdd()
        {
            Title = "New game";

            EnablePublisher = true;
            VisibleGenreList = false;
            VisableGenreSave = false;

            List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
            {
                Id= Guid.Empty,
                Name="Select a publisher"
            }};

            foreach(PublisherInfo publisher in Task.Run(async () => await publisherService.GetAllPublisher()).Result)
            {
                selectPublisher.Add(publisher);
            }

            Publishers = new ObservableCollection<PublisherInfo>(selectPublisher);

            ChosenPublisher = Publishers.FirstOrDefault();

            PublisherId = Guid.Empty;

            GenreId = new ObservableCollection<Guid>
            {
                Guid.Empty
            };

            GamePrice = string.Empty;
            PublisherError = string.Empty;
            GamePriceError = string.Empty;
            GenreEditList = new ObservableCollection<GenreInfo>();
            ChosenGenre = new GenreInfo();
            GenrePickList = new ObservableCollection<GenreInfo>();
            Genres = new ObservableCollection<GenreInfo>();
            ListError = string.Empty;
            ListSave = string.Empty;
            TextPicker = string.Empty;
            VisableDeleteGenre = EnableGenreList;
            VisableAddGenre = EnableAddGenre;
            CreateItem = true;

            base.SetAdd();
        }

        public override void SetRead()
        {
            if(currentGameInfo != null)
            {
                Title = currentGameInfo.Name;
            }

            VisibleGenreList = false;
            VisableAddGenre = false;
            VisableDeleteGenre = false;
            VisableGenreSave = false;
            EnablePublisher = false;
            CreateItem=false;

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + currentGameInfo.Name;
            VisibleGenreList = false;
            VisableDeleteGenre = EnableGenreList;
            VisableAddGenre = EnableAddGenre;
            VisableGenreSave=false;

            EnablePublisher = true;

            base.SetEdit();
        }
    }
}