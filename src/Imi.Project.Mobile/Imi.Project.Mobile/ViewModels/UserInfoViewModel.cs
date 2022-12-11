using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserInfoViewModel: BaseInfoViewModel
    {
        private UserInfo currentUserInfo;
        private readonly IUserService userService;

        public UserInfoViewModel(IUserService userService, IGameService gameService):base(gameService)
        {
            this.userService = userService;

            InfoValidator = new UserInfoValidator();
        }

        #region Properties

        public bool PasswordConfirmVisible => !string.IsNullOrWhiteSpace(NameError);

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
                RaisePropertyChanged(nameof(UserEmailErrorVisible));
            }
        }

        public bool UserEmailErrorVisible => !string.IsNullOrWhiteSpace(UserEmailError);

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
                RaisePropertyChanged(nameof(UserFirstNameErrorVisible));
            }
        }

        public bool UserFirstNameErrorVisible => !string.IsNullOrWhiteSpace(UserFirstNameError);

        private string userLastNameError;
        public string UserLastNameError
        {
            get => userLastNameError;
            set
            {
                userLastNameError = value;
                RaisePropertyChanged(nameof(UserLastNameError));
                RaisePropertyChanged(nameof(UserLastNameErrorVisible));
            }
        }

        public bool UserLastNameErrorVisible => !string.IsNullOrWhiteSpace(UserLastNameError);

        private string listAddOrDelete;
        public string ListAddOrDelete
        {
            get => listAddOrDelete;
            set
            {
                listAddOrDelete = value;
                RaisePropertyChanged(nameof(ListAddOrDelete));
            }
        }

        private bool enableGameList;
        public bool EnableGameList
        {
            get => enableGameList;
            set
            {
                enableGameList = value;
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        private bool enableGameAddDeleteList;
        public bool EnableGameAddDeleteList
        {
            get => enableGameAddDeleteList;
            set
            {
                enableGameAddDeleteList = value;
                RaisePropertyChanged(nameof(EnableGameAddDeleteList));
            }
        }

        private bool visableSaveGames;
        public bool VisableSaveGames
        {
            get => visableSaveGames;
            set
            {
                visableSaveGames = value;
                RaisePropertyChanged(nameof(VisableSaveGames));
            }
        }

        private ObservableCollection<GamesInfo> gamesPlayed;
        public ObservableCollection<GamesInfo> GamesPlayed
        {
            get => gamesPlayed;
            set
            {
                gamesPlayed = value;
                HeightListGames = gamesPlayed.Count() * 20;

                EnableGameList = GamesPlayed.Count() > 0;

                RaisePropertyChanged(nameof(GamesPlayed));
            }
        }

        private ObservableCollection<GamesInfo> gamesToAddDelete;
        public ObservableCollection<GamesInfo> GamesToAddDelete
        {
            get => gamesToAddDelete;
            set
            {
                gamesToAddDelete = value;
                HeightListGamesAddDelete = gamesToAddDelete.Count() * 125;
                RaisePropertyChanged(nameof(GamesToAddDelete));
            }
        }

        private ObservableCollection<GamesInfo> gamesAddDeleteList;
        public ObservableCollection<GamesInfo> GamesToAddDeleteList
        {
            get => gamesAddDeleteList;
            set
            {
                gamesAddDeleteList = value;
                RaisePropertyChanged(nameof(GamesToAddDeleteList));
            }
        }

        private ICollection<Guid> gameId;
        public ICollection<Guid> GameId
        {
            get => gameId;
            set
            {
                gameId = value;
                RaisePropertyChanged(nameof(GameId));
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

        private string gameListText;
        public string GameListText
        {
            get => gameListText;
            set
            {
                gameListText = value;
                RaisePropertyChanged(nameof(GameListText));
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

        private int heightListGamesAddDelete;
        public int HeightListGamesAddDelete
        {
            get => heightListGamesAddDelete;
            set
            {
                heightListGamesAddDelete = value;
                RaisePropertyChanged(nameof(HeightListGamesAddDelete));
            }
        }

        private bool visableButtonsUsers;
        public bool VisableButtonsUsers
        {
            get => visableButtonsUsers;
            set
            {
                visableButtonsUsers = value;
                RaisePropertyChanged(nameof(VisableButtonsUsers));
            }
        }

        private bool visableAddGame;
        public bool VisableAddGame
        {
            get => visableAddGame;
            set
            {
                visableAddGame = value;
                RaisePropertyChanged(nameof(VisableAddGame));
            }
        }

        private bool visableDeleteGames;
        public bool VisableDeleteGames
        {
            get => visableDeleteGames;
            set
            {
                visableDeleteGames = value;
                RaisePropertyChanged(nameof(VisableDeleteGames));
            }
        }

        private bool visableGamesCancel;
        public bool VisableGamesCancel
        {
            get => visableGamesCancel;
            set
            {
                visableGamesCancel = value;
                RaisePropertyChanged(nameof(VisableGamesCancel));
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

        #endregion

        public override void Init(object initData)
        {
            if(initData != null)
            {
                currentUserInfo = initData as UserInfo;

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
            GameId = new List<Guid> { };
            Password = null;

            Name = currentUserInfo.UserName;
            FirstName = currentUserInfo.FirstName;
            LastName = currentUserInfo.LastName;
            Email = currentUserInfo.Email;
            GameId = currentUserInfo.GameId;
            Password = currentUserInfo.Password;
            PasswordConfirm = currentUserInfo.ConfirmPassword;
        }

        public ICommand SaveUserInfoCommand => new Command(
            async () =>
            {
                SaveUserState();

                if(Validate(currentUserInfo))
                {
                    await userService.UpdateUser(currentUserInfo);
                    await CoreMethods.PopPageModel(currentUserInfo, false, true);
                }
            });

        private void SaveUserState()
        {
            currentUserInfo.UserName = Name;
            currentUserInfo.LastName = LastName;
            currentUserInfo.FirstName = FirstName;
            currentUserInfo.Email = Email;
            currentUserInfo.GameId = GameId;
            currentUserInfo.Password = Password;
            currentUserInfo.ConfirmPassword = PasswordConfirm;
        }

        public ICommand AddUserInfoCommand => new Command(
            async () =>
            {
                if(FirstName == null)
                {
                    FirstName = "";
                }

                if(LastName == null)
                {
                    LastName = "";
                }

                if(Name == null)
                {
                    Name = "";
                }

                if(Email == null)
                {
                    Email = "";
                }

                if(Password == null)
                {
                    Password = "";
                }

                if(PasswordConfirm == null)
                {
                    PasswordConfirm = "";
                }

                UserInfo userEdit = new UserInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = this.Name,
                    Email = Email,
                    GameId = new List<Guid> { },
                    Password = Password,
                    ConfirmPassword = PasswordConfirm
                };

                foreach(GamesInfo a in GamesPlayed)
                {
                    userEdit.GameId.Add(a.Id);
                }

                if(Validate(userEdit))
                {
                    if(userEdit.Password != userEdit.ConfirmPassword)
                    {
                        UserPasswordConfirmError = "Password and confirm password aren't the same";
                    } else
                    {
                        await userService.AddUser(userEdit);
                        await CoreMethods.PopPageModel(userEdit, false, true);
                    }
                }
            });

        public ICommand EditCommand => new Command(() =>
        {
            SetEdit();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            LoadUserState();
            SetRead();
        });

        public ICommand AddGamesInfoCommand => new Command(async () =>
        {
            IEnumerable<GamesInfo> allGames = await GameService.GetAllGames();

            GamesToAddDelete = new ObservableCollection<GamesInfo>(allGames.Where(gamess => !currentUserInfo.GameId.Contains(gamess.Id)));
            GamesToAddDeleteList = new ObservableCollection<GamesInfo>();

            ListAddOrDelete = "Add";
            EnableGameAddDeleteList = true;
            VisableSaveGames = true;
            AddGame = true;
            VisableButtonsUsers = false;
            VisableDeleteGames = false;
            VisableAddGame = false;
            VisableGamesCancel = true;
        });

        public ICommand DeleteGamesCommand => new Command(async () =>
        {
            ListAddOrDelete = "Delete";

            AddGame = false;

            IEnumerable<GamesInfo> allGames = await GameService.GetAllGames();

            GamesToAddDelete = new ObservableCollection<GamesInfo>(allGames.Where(gamess => currentUserInfo.GameId.Contains(gamess.Id)));

            GamesToAddDeleteList = new ObservableCollection<GamesInfo>();
            VisableGamesCancel = true;
            VisableSaveGames = true;
            VisableAddGame = false;
            VisableDeleteGames = false;
            EnableGameAddDeleteList = true;
            VisableButtonsUsers = false;
        });

        public ICommand CancelGamesCommand => new Command(() =>
        {
            GamesToAddDeleteList = new ObservableCollection<GamesInfo>();
            VisableButtonsUsers = true;
            VisableGamesCancel = false;
            VisableSaveGames = false;
            EnableGameAddDeleteList = false;
            VisableAddGame = true;
            VisableDeleteGames = true;
        });

        public ICommand GameAddDelete => new Command<GamesInfo>((GamesInfo game) =>
        {
            if(GamesToAddDeleteList == null)
            {
                GamesToAddDeleteList = new ObservableCollection<GamesInfo>();
            }

            GamesToAddDeleteList.Add(game);
            GamesToAddDelete.Remove(game);

            GamesToAddDelete = GamesToAddDelete;
        });

        public ICommand SaveGamesCommand => new Command(() =>
        {
            if(AddGame)
            {

                ObservableCollection<GamesInfo> gamesPlayed = GamesPlayed;
                foreach(GamesInfo newGames in GamesToAddDeleteList)
                {
                    gamesPlayed.Add(newGames);
                }

                GamesPlayed = new ObservableCollection<GamesInfo>(gamesPlayed.OrderBy(game => game.Id));
            } else
            {
                ObservableCollection<GamesInfo> gamesPlayed = GamesPlayed;
                foreach(GamesInfo removeGames in GamesToAddDeleteList)
                {
                    gamesPlayed.Remove(gamesPlayed.Where(gaga => gaga.Id == removeGames.Id).Single());
                }

                GamesPlayed = gamesPlayed;
            }

            GamesToAddDeleteList = new ObservableCollection<GamesInfo>();
            currentUserInfo.GameId = new List<Guid> { };

            foreach(GamesInfo gamePlayed in GamesPlayed)
            {
                currentUserInfo.GameId.Add(gamePlayed.Id);
            }

            GameId = currentUserInfo.GameId;

            EnableGameAddDeleteList = false;
            VisableSaveGames = false;
            VisableButtonsUsers = true;
            VisableDeleteGames = true;
            VisableAddGame = true;
            VisableGamesCancel = false;
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await userService.DeleteUser(currentUserInfo.Id);

            await CoreMethods.PopPageModel(new UserInfo(), false, true);
        });

        private bool Validate(UserInfo userInfo)
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

            VisablePassword = true;
            VisableDeleteGames = true;
            VisableAddGame = true;
            VisableButtonsUsers = true;

            currentUserInfo = new UserInfo
            {
                Id = Guid.Empty,
                GameId = new List<Guid> { }
            };

            GamesPlayed = new ObservableCollection<GamesInfo>();

            base.SetAdd();
        }

        public override async void SetRead()
        {
            Title = currentUserInfo.UserName;

            VisablePassword = false;
            VisableDeleteGames = false;
            VisableAddGame = false;
            VisableButtonsUsers = true;

            EnableGameList = false;

            IEnumerable<GamesInfo> allGames = await GameService.GetAllGames();

            GamesPlayed = new ObservableCollection<GamesInfo>(allGames.Where(gamess => currentUserInfo.GameId.Contains(gamess.Id)));

            if(GamesPlayed.Count() > 0)
            {
                EnableGameList = true;
            }
            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + currentUserInfo.UserName;

            VisablePassword = false;
            VisableDeleteGames = true;
            VisableAddGame = true;
            VisableButtonsUsers = true;

            base.SetEdit();
        }
    }
}