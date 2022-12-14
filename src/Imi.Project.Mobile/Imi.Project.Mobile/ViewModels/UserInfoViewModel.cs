using FluentValidation;
using FreshMvvm;
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
    public class UserInfoViewModel: BaseInfoViewModel<UserInfo>
    {
        private readonly IUserService userService;

        public UserInfoViewModel(IUserService userService, IGameService gameService):base(gameService)
        {
            this.userService = userService;

            InfoValidator = new UserInfoValidator();
        }

        #region Properties
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                UserFirstNameError = null;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                UserLastNameError = null;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                UserEmailError = null;
                RaisePropertyChanged(nameof(Email));
            }
        }

        private string userEmailError;
        public string UserEmailError
        {
            get => userEmailError;
            set
            {
                userEmailError = value;
                RaisePropertyChanged(nameof(UserEmailError));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                UserPasswordError = null;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private string userPasswordError;
        public string UserPasswordError
        {
            get => userPasswordError;
            set
            {
                userPasswordError = value;
                RaisePropertyChanged(nameof(Password));
                RaisePropertyChanged(nameof(UserPasswordError));
            }
        }

        private string passwordConfirm;
        public string PasswordConfirm
        {
            get => passwordConfirm;
            set
            {
                passwordConfirm = value;
                UserPasswordConfirmError = null;
                RaisePropertyChanged(nameof(PasswordConfirm));
            }
        }

        private string userPasswordConfirmError;
        public string UserPasswordConfirmError
        {
            get => userPasswordConfirmError;
            set
            {
                userPasswordConfirmError = value;
                RaisePropertyChanged(nameof(PasswordConfirm));
                RaisePropertyChanged(nameof(UserPasswordConfirmError));
            }
        }

        private string userFirstNameError;
        public string UserFirstNameError
        {
            get => userFirstNameError;
            set
            {
                userFirstNameError = value;
                RaisePropertyChanged(nameof(UserFirstNameError));
            }
        }

        private string userLastNameError;
        public string UserLastNameError
        {
            get => userLastNameError;
            set
            {
                userLastNameError = value;
                RaisePropertyChanged(nameof(UserLastNameError));
            }
        }

        private bool visablePassword;
        public bool VisablePassword
        {
            get => visablePassword;
            set
            {
                visablePassword = value;
                RaisePropertyChanged(nameof(VisablePassword));
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
                listError = value;
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

        private bool addGame;
        public bool AddGame
        {
            get => addGame;
            set
            {
                addGame = value;
                RaisePropertyChanged(nameof(AddGame));
            }
        }

        private bool visibleGameList;
        public bool VisibleGameList
        {
            get => visibleGameList;
            set
            {
                visibleGameList = value;
                RaisePropertyChanged(nameof(VisibleGameList));
            }
        }

        private bool visableAddGame;
        public bool VisableAddGame
        {
            get => visableAddGame;
            set
            {
                visableAddGame = value;
                ColumnDelete = VisableAddGame ? 1 : 0;
                ColumnSpanDelete = VisableAddGame ? 1 : 2;
                RaisePropertyChanged(nameof(VisableAddGame));
            }
        }

        private bool visableDeleteGame;
        public bool VisableDeleteGame
        {
            get => visableDeleteGame;
            set
            {
                visableDeleteGame = value;
                ColumnSpanAdd = VisableDeleteGame ? 1 : 2;
                RaisePropertyChanged(nameof(VisableDeleteGame));
            }
        }

        private bool visableGameSave;
        public bool VisableGameSave
        {
            get => visableGameSave;
            set
            {
                visableGameSave = value;
                RaisePropertyChanged(nameof(VisableGameSave));
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

        private ObservableCollection<Guid> gameId;
        public ObservableCollection<Guid> GameId
        {
            get => gameId;
            set
            {
                gameId = value;
                RaisePropertyChanged(nameof(GameId));
            }
        }

        private ObservableCollection<GamesInfo> games;
        public ObservableCollection<GamesInfo> Games
        {
            get => games;
            set
            {
                games = value;
                HeightListGames = games.Count() * 20;
                RaisePropertyChanged(nameof(Games));
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        private ObservableCollection<GamesInfo> gamePickList;
        public ObservableCollection<GamesInfo> GamePickList
        {
            get => gamePickList;
            set
            {
                gamePickList = new ObservableCollection<GamesInfo>(value);
                RaisePropertyChanged(nameof(GamePickList));
            }
        }

        private ObservableCollection<GamesInfo> gameEditList;
        public ObservableCollection<GamesInfo> GameEditList
        {
            get => gameEditList;
            set
            {
                gameEditList = value;
                RaisePropertyChanged(nameof(GameEditList));
            }
        }

        private GamesInfo chosenGame;
        public GamesInfo ChosenGame
        {
            get => chosenGame;
            set
            {
                chosenGame = value;
                RaisePropertyChanged(nameof(ChosenGame));
                ListError = "";
            }
        }

        private int heightListGames;
        public int HeightListGames
        {
            get => heightListGames;
            set
            {
                heightListGames = value;
                RaisePropertyChanged(nameof(HeightListGames));
            }
        }

        public bool EnableGameList => Games.Any();

        public bool EnableAddGame => (Task.Run(async () => await GameService.GetAll()).Result.Count() != GameId.Count());

        #endregion

        public override void Init(object initData)
        {
            if(initData != null)
            {
                CurrentItem = initData as UserInfo;

                LoadUserState();
                SetRead();
            } else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadUserState()
        {
            Name = null;
            FirstName = null;
            LastName = null;
            Email = null;
            Password = null;

            GameId = new ObservableCollection<Guid>();

            Name = CurrentItem.UserName;
            FirstName = CurrentItem.FirstName;
            LastName = CurrentItem.LastName;
            Email = CurrentItem.Email;
            GameId = new ObservableCollection<Guid>(CurrentItem.GameId);
            Password = CurrentItem.Password;
            PasswordConfirm = CurrentItem.ConfirmPassword;

            List<GamesInfo> selectGame = new List<GamesInfo>
            {
                new GamesInfo
                {
                    Id = Guid.Empty,
                    Name = "Select a game"
                }};

            foreach(GamesInfo game in Task.Run(async () => await GameService.GetAll()).Result)
            {
                selectGame.Add(game);
            }

            Games = new ObservableCollection<GamesInfo>(selectGame.Where(game=> GameId.Contains(game.Id)));
        }

        public ICommand AddCommand => new Command(async () =>
            {
                if(FirstName == null)
                {
                    FirstName = string.Empty;
                }

                if(LastName == null)
                {
                    LastName = string.Empty;
                }

                if(Name == null)
                {
                    Name = string.Empty;
                }

                if(Email == null)
                {
                    Email = string.Empty;
                }

                if(Password == null)
                {
                    Password = string.Empty;
                }

                if(PasswordConfirm == null)
                {
                    PasswordConfirm = string.Empty;
                }

                var allGames = Games;

                List<Guid> gameId = new List<Guid>();

                foreach(GamesInfo game in allGames.Distinct())
                {
                    gameId.Add(game.Id);
                }

                UserInfo userEdit = new UserInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = Name,
                    Email = Email,
                    GameId = gameId,
                    Password = Password,
                    ConfirmPassword = PasswordConfirm
                };

                if(Validate(userEdit))
                {
                    if(userEdit.Password != userEdit.ConfirmPassword)
                    {
                        UserPasswordConfirmError = "Password and confirm password aren't the same";
                    } else
                    {
                        await userService.Add(userEdit);
                        await CoreMethods.PopPageModel(userEdit, false, true);
                    }
                }
            });

        public override ICommand DeleteCommand => new Command(async () =>
        {
            base.DeleteCommand.Execute(null);

            await userService.Delete(CurrentItem.Id);
            await CoreMethods.PopPageModel(new UserInfo(), false, true);
        });

        public ICommand SaveCommand => new Command(async () =>
            {
                var allGames = Games;

                List<Guid> gameId = new List<Guid>();

                foreach(GamesInfo game in allGames.Distinct())
                {
                    gameId.Add(game.Id);
                }

                UserInfo userEdit = new UserInfo
                {
                    Id = CurrentItem.Id,
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = Name,
                    Email = Email,
                    GameId = gameId,
                    Password = Password,
                    ConfirmPassword = PasswordConfirm
                };

                if(Validate(userEdit))
                {
                    await userService.Update(userEdit);
                    await CoreMethods.PopPageModel(userEdit, false, true);
                }
            });

        public override ICommand CancelCommand => new Command(() =>
        {
            LoadUserState();

            base.CancelCommand.Execute(null);
        });

        public ICommand AddUserGame => new Command(() =>
        {
            TextPicker = "Add game";

            List<GamesInfo> games = new List<GamesInfo>
            {
                new GamesInfo
                {
                     Id=Guid.Empty,
                     Name="Select a game"
                }
            };

            foreach(GamesInfo game in Task.Run(async () => await GameService.GetAll()).Result)
            {
                if(!GameId.Contains(game.Id))
                {
                    games.Add(game);
                }
            }

            GamePickList = new ObservableCollection<GamesInfo>(games);

            ChosenGame = games.First();

            VisibleGameList = true;
            VisableAdd = false;
            VisableCancel = false;
            VisableSave = false;
            VisableGameSave = true;
            AddGame = true;
            VisableDeleteGame = false;
            VisableAddGame = false;
        });

        public ICommand DeleteUserGame => new Command(() =>
        {
            TextPicker = "Delete game";

            List<GamesInfo> games = new List<GamesInfo>
                {
                    new GamesInfo
                    {
                        Id = Guid.Empty,
                        Name="Select a game"
                    }
                };

            foreach(GamesInfo game in Task.Run(async () => await GameService.GetAll()).Result)
            {
                if(GameId.Contains(game.Id))
                {
                    games.Add(game);
                }
            }

            GamePickList = new ObservableCollection<GamesInfo>(games);

            ChosenGame = games.First();

            VisableAdd = false;
            VisibleGameList = true;
            VisableGameSave = true;
            AddGame = false;
            VisableCancel = false;
            VisableSave = false;
            VisableAddGame= false;
            VisableDeleteGame = false;
        });

        public ICommand SaveUserGame => new Command(() =>
        {
            if(ChosenGame.Id != Guid.Empty)
            {
                var gamePlayedList = Games;
                if(AddGame)
                {
                    gamePlayedList.Add(ChosenGame);
                    GameId.Add(ChosenGame.Id);

                } else
                {
                    gamePlayedList.Remove(gamePlayedList.Where(game=> game.Id == ChosenGame.Id).Single());
                    GameId.Remove(ChosenGame.Id);
                }

                Games = new ObservableCollection<GamesInfo>(gamePlayedList.OrderBy(game => game.Id));

                if(CreateItem)
                {
                    VisableAdd = true;
                } else
                {
                    VisableCancel = true;
                    VisableSave = true;
                }
                VisibleGameList = false;
                VisableGameSave = false;
                VisableAddGame= EnableAddGame;
                VisableDeleteGame= EnableGameList;
            } else
            {
                ListError = "Pick a valid game";
            }
        });

        public ICommand CancelUserGame => new Command(() =>
        {
            VisibleGameList = false;
            VisableAddGame= EnableAddGame;
            VisableDeleteGame = true;
            VisableGameSave = false;
            if(CreateItem)
            {
                VisableAdd = true;
            } else
            {
                VisableCancel = true;
                VisableSave = true;
            }
        });

        public override bool Validate(UserInfo userInfo)
        {
            ValidationContext<UserInfo> validationContext = new ValidationContext<UserInfo>(userInfo);
            FluentValidation.Results.ValidationResult validationResult = InfoValidator.Validate(validationContext);

            foreach(FluentValidation.Results.ValidationFailure error in validationResult.Errors)
            {
                switch(error.PropertyName)
                {
                    case nameof(userInfo.Email):
                        UserEmailError = error.ErrorMessage;
                        break;

                    case nameof(userInfo.FirstName):
                        UserFirstNameError = error.ErrorMessage;
                        break;

                    case nameof(userInfo.LastName):
                        UserLastNameError = error.ErrorMessage;
                        break;

                    case nameof(userInfo.UserName):
                        NameError = error.ErrorMessage;
                        break;

                    case nameof(userInfo.Password):
                        UserPasswordError = error.ErrorMessage;
                        break;

                    default:
                        UserEmailError = "Unknown Error";
                        UserFirstNameError = "Unknown Error";
                        UserLastNameError = "Unknown Error";
                        UserEmailError = "Unknown Error";
                        break;
                }
            }

            return validationResult.IsValid;
        }

        public override void SetAdd()
        {
            Title = "New User";

            GameId = new ObservableCollection<Guid>();







            VisibleGameList = false;
            VisableGameSave = false;
            VisablePassword = true;
            ChosenGame = new GamesInfo();
            Games = new ObservableCollection<GamesInfo>();
            VisableDeleteGame = EnableGameList;
            VisableAddGame = EnableAddGame;
            CreateItem = true;

            CurrentItem = new UserInfo
            {
                Id = Guid.Empty,
                GameId = new List<Guid>(),
            };

            base.SetAdd();
        }

        public override void SetRead()
        {
            Title = CurrentItem.UserName;

            VisablePassword = false;
            VisibleGameList = false;
            VisableAddGame= false;
            VisableDeleteGame= false;
            VisableGameSave = false;
            CreateItem = false;



            //Games = new ObservableCollection<GamesInfo>();


            //IEnumerable<GamesInfo> allGames = await GameService.GetAll();

            //Games = new ObservableCollection<GamesInfo>(allGames.Where(gamess => CurrentItem.GameId.Contains(gamess.Id)));

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.UserName;

            VisablePassword = false;
            VisibleGameList = false;
            VisableDeleteGame= EnableGameList;
            VisableAddGame = EnableAddGame;
            VisableGameSave = false;

            base.SetEdit();
        }
    }
}