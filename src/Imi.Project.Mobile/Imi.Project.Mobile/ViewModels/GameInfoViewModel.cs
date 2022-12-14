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
    public class GameInfoViewModel: BaseInfoViewModel<GamesInfo>
    {
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

        public bool EnableAddGenre => (Task.Run(async () => await genreService.GetAll()).Result.Count() != GenreId.Count());
        #endregion 

        public override void Init(object initData)
        {
            if(initData != null)
            {
                CurrentItem = initData as GamesInfo;

                LoadGameState();
                SetRead();
            } else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadGameState()
        {
            PublisherId = Guid.Empty;

            GenreId = new ObservableCollection<Guid>();

            Name = CurrentItem.Name;
            GamePrice = CurrentItem.Price.ToString();
            PublisherId = CurrentItem.PublisherId;
            GenreId = new ObservableCollection<Guid>(CurrentItem.GenreId);

            List<PublisherInfo> selectPublisher = new List<PublisherInfo> { new PublisherInfo
                {
                    Id= Guid.Empty,
                    Name="Select a publisher"
                }};

            foreach(PublisherInfo publisher in Task.Run(async () => await publisherService.GetAll()).Result)
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


            foreach(GenreInfo genre in Task.Run(async () => await genreService.GetAll()).Result)
            {
                selectGenre.Add(genre);
            }

            Genres = new ObservableCollection<GenreInfo>(selectGenre.Where(genre => GenreId.Contains(genre.Id)));
        }

        public ICommand AddCommand => new Command(async () =>
            {
                if(Name == null)
                {
                    Name = string.Empty;
                }

                var allGenre = Genres;

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

                if(Validate(gameEdit))
                {
                    await GameService.Add(gameEdit);
                    await CoreMethods.PopPageModel(gameEdit, false, true);
                }
            });

        public override ICommand DeleteCommand => new Command(async () =>
        {
            base.DeleteCommand.Execute(null);

            await GameService.Delete(CurrentItem.Id);
            await CoreMethods.PopPageModel(new GamesInfo(), false, true);
        });

        public ICommand SaveCommand => new Command(async () =>
            {
                var allGenre = Genres;

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
                    Name = this.Name,
                    Price = 0
                };

                if(GamePrice != null && float.TryParse(GamePrice, out float isfloat))
                {
                    gameValidate.Price = float.Parse(GamePrice);
                }

                if(Validate(gameValidate))
                {
                    await GameService.Update(gameValidate);
                    await CoreMethods.PopPageModel(gameValidate, false, true);
                }
            });

        public override ICommand CancelCommand => new Command(() =>
        {
            LoadGameState();

            base.CancelCommand.Execute(null);
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
            
            foreach(GenreInfo genre in Task.Run(async () => await genreService.GetAll()).Result)
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

                foreach(GenreInfo genre in Task.Run(async () => await genreService.GetAll()).Result)
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

        public ICommand SaveGameGenre => new Command(()=>
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
                        genrePlayedList.Remove(genrePlayedList.Where(genre => genre.Id == ChosenGenre.Id).Single());
                        GenreId.Remove(ChosenGenre.Id);
                    }

                    Genres = new ObservableCollection<GenreInfo>(genrePlayedList.OrderBy(genre => genre.Id));

                    if(CreateItem)
                    {
                        VisableAdd = true;
                    } else
                    {
                        VisableCancel = true;
                        VisableSave = true;
                    }
                    VisibleGenreList = false;
                    VisableGenreSave = false;
                    VisableAddGenre = EnableAddGenre;
                    VisableDeleteGenre = EnableGenreList;
                } else
                {
                    ListError = "Pick a valid genre";
                }
            });

        public ICommand CancelGameGenre => new Command(() =>
        {
            VisibleGenreList = false;
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

            foreach(PublisherInfo publisher in Task.Run(async () => await publisherService.GetAll()).Result)
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

            ChosenGenre = new GenreInfo();
            Genres = new ObservableCollection<GenreInfo>();
            VisableDeleteGenre = EnableGenreList;
            VisableAddGenre = EnableAddGenre;
            CreateItem = true;

            base.SetAdd();
        }

        public override void SetRead()
        {
                Title = CurrentItem.Name;

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
            Title = "Edit " + CurrentItem.Name;
            VisibleGenreList = false;
            VisableDeleteGenre = EnableGenreList;
            VisableAddGenre = EnableAddGenre;
            VisableGenreSave=false;

            EnablePublisher = true;

            base.SetEdit();
        }
    }
}