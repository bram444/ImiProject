using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserInfoViewModel : FreshBasePageModel
    {
        private UserInfo currentUserInfo;
        private readonly IValidator userInfoValidator;
        private readonly IUserService userService;
        private readonly IGameService gameService;

        public UserInfoViewModel(IUserService userService, IGameService gameService)
        {
            this.userService = userService;
            this.gameService = gameService;

            userInfoValidator = new UserInfoValidator();
        }

        #region Properties

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                UserUserNameError = null;
                RaisePropertyChanged(nameof(UserName));
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
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
            get { return lastName; }
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
            get { return email; }
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
            get { return userEmailError; }
            set
            {
                userEmailError = value;
                RaisePropertyChanged(nameof(UserEmailError));
                RaisePropertyChanged(nameof(UserEmailErrorVisible));

            }
        }

        public bool UserEmailErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(UserEmailError); }
        }

        private string password;
        public string Password
        {
            get { return password; }
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
            get { return userPasswordError; }
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
            get { return passwordConfirm; }
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
            get { return userPasswordConfirmError; }
            set
            {
                userPasswordConfirmError = value;
                RaisePropertyChanged(nameof(PasswordConfirm));
                RaisePropertyChanged(nameof(UserPasswordConfirmError));
            }
        }

        public bool PasswordConfirmVisible
        {
            get { return !string.IsNullOrWhiteSpace(UserUserNameError); }
        }

        private string userUserNameError;
        public string UserUserNameError
        {
            get { return userUserNameError; }
            set
            {
                userUserNameError = value;
                RaisePropertyChanged(nameof(UserUserNameError));
                RaisePropertyChanged(nameof(UserUserNameErrorVisible));
            }
        }

        public bool UserUserNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(UserUserNameError); }
        }

        private string userFirstNameError;
        public string UserFirstNameError
        {
            get { return userFirstNameError; }
            set
            {
                userFirstNameError = value;
                RaisePropertyChanged(nameof(UserFirstNameError));
                RaisePropertyChanged(nameof(UserFirstNameErrorVisible));
            }
        }

        public bool UserFirstNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(UserFirstNameError); }
        }

        private string userLastNameError;
        public string UserLastNameError
        {
            get { return userLastNameError; }
            set
            {
                userLastNameError = value;
                RaisePropertyChanged(nameof(UserLastNameError));
                RaisePropertyChanged(nameof(UserLastNameErrorVisible));
            }
        }

        public bool UserLastNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(UserLastNameError); }
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

        private string listAddOrDelete;
        public string ListAddOrDelete
        {
            get { return listAddOrDelete; }
            set
            {
                listAddOrDelete = value;
                RaisePropertyChanged(nameof(ListAddOrDelete));
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

        private bool enableGameList;
        public bool EnableGameList
        {
            get { return enableGameList; }
            set
            {
                enableGameList = value;
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        private bool enableGameAddDeleteList;
        public bool EnableGameAddDeleteList
        {
            get { return enableGameAddDeleteList; }
            set
            {
                enableGameAddDeleteList = value;
                RaisePropertyChanged(nameof(EnableGameAddDeleteList));
            }
        }

        private bool visableSaveGames;
        public bool VisableSaveGames
        {
            get { return visableSaveGames; }
            set
            {
                visableSaveGames = value;
                RaisePropertyChanged(nameof(VisableSaveGames));
            }
        }

        private ObservableCollection<GamesInfo> gamesPlayed;
        public ObservableCollection<GamesInfo> GamesPlayed
        {
            get { return gamesPlayed; }
            set
            {
                gamesPlayed = value;
                HeightListGames = gamesPlayed.Count() * 20;

                if (GamesPlayed.Count() > 0)
                {
                    EnableGameList = true;
                }
                else
                {
                    EnableGameList = false;
                }

                RaisePropertyChanged(nameof(GamesPlayed));
            }
        }

        private ObservableCollection<GamesInfo> gamesToAddDelete;
        public ObservableCollection<GamesInfo> GamesToAddDelete
        {
            get { return gamesToAddDelete; }
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
            get { return gamesAddDeleteList; }
            set
            {
                gamesAddDeleteList = value;
                RaisePropertyChanged(nameof(GamesToAddDeleteList));
            }
        }

        private ICollection<Guid> gameId;
        public ICollection<Guid> GameId
        {
            get { return gameId; }
            set
            {
                gameId = value;
                RaisePropertyChanged(nameof(GameId));
            }
        }

        private bool addGame;
        public bool AddGame
        {
            get { return addGame; }
            set
            {
                addGame = value;
                RaisePropertyChanged(nameof(AddGame));
            }
        }

        private string gameListText;
        public string GameListText
        {
            get
            {
                return gameListText;
            }
            set
            {
                gameListText = value;
                RaisePropertyChanged(nameof(GameListText));
            }
        }

        private int heightListGames;
        public int HeightListGames
        {
            get { return heightListGames; }
            set
            {
                heightListGames = value;
                RaisePropertyChanged(nameof(HeightListGames));
            }
        }

        private int heightListGamesAddDelete;
        public int HeightListGamesAddDelete
        {
            get { return heightListGamesAddDelete; }
            set
            {
                heightListGamesAddDelete = value;
                RaisePropertyChanged(nameof(HeightListGamesAddDelete));
            }
        }

        private bool visableButtonsUsers;
        public bool VisableButtonsUsers
        {
            get { return visableButtonsUsers; }
            set
            {
                visableButtonsUsers = value;
                RaisePropertyChanged(nameof(VisableButtonsUsers));
            }
        }

        private bool visableAddGame;
        public bool VisableAddGame
        {
            get { return visableAddGame; }
            set
            {
                visableAddGame = value;
                RaisePropertyChanged(nameof(VisableAddGame));
            }
        }

        private bool visableDeleteGames;
        public bool VisableDeleteGames
        {
            get { return visableDeleteGames; }
            set
            {
                visableDeleteGames = value;
                RaisePropertyChanged(nameof(VisableDeleteGames));
            }
        }

        private bool visableGamesCancel;
        public bool VisableGamesCancel
        {
            get { return visableGamesCancel; }
            set
            {
                visableGamesCancel = value;
                RaisePropertyChanged(nameof(VisableGamesCancel));
            }
        }

        private bool visablePassword;
        public bool VisablePassword
        {
            get { return visablePassword; }
            set
            {
                visablePassword = value;
                RaisePropertyChanged(nameof(VisablePassword));
            }
        }

        #endregion

        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentUserInfo = initData as UserInfo;

                LoadUserState();
                SetRead();
            }
            else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadUserState()
        {
            UserName = null;
            FirstName = null;
            LastName = null;
            Email = null;
            GameId = new List<Guid> { };
            Password = null;

            UserName = currentUserInfo.UserName;
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

                if (Validate(currentUserInfo))
                {
                    await userService.UpdateUser(currentUserInfo);
                    await CoreMethods.PopPageModel(currentUserInfo, false, true);
                }
            });

        private void SaveUserState()
        {
            currentUserInfo.UserName = UserName;
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
                if (FirstName == null)
                {
                    FirstName = "";
                }

                if (LastName == null)
                {
                    LastName = "";
                }

                if (UserName == null)
                {
                    UserName = "";
                }

                if (Email == null)
                {
                    Email = "";
                }

                if(Password == null)
                {
                    Password = "";
                }

                if(PasswordConfirm==null)
                {
                    PasswordConfirm = "";
                }

                UserInfo userEdit = new UserInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    UserName = this.UserName,
                    Email = this.Email,
                    GameId = new List<Guid>{},
                    Password = this.Password,
                    ConfirmPassword = this.PasswordConfirm
                };

                foreach (var a in GamesPlayed)
                {
                    userEdit.GameId.Add(a.Id);
                }

                if (Validate(userEdit))
                {
                    if (userEdit.Password != userEdit.ConfirmPassword)
                    {
                        UserPasswordConfirmError = "Password and confirm password aren't the same";
                    }
                    else
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
            var allGames = await gameService.GetAllGames();

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
            var allGames = await gameService.GetAllGames();

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
            if (GamesToAddDeleteList == null)
            {
                GamesToAddDeleteList = new ObservableCollection<GamesInfo>();
            }

            GamesToAddDeleteList.Add(game);
            GamesToAddDelete.Remove(game);

            GamesToAddDelete = GamesToAddDelete;
        });

        public ICommand SaveGamesCommand => new Command(() =>
        {
            if (AddGame)
            {

                ObservableCollection<GamesInfo> gamesPlayed = GamesPlayed;
                foreach (GamesInfo newGames in GamesToAddDeleteList)
                {

                    gamesPlayed.Add(newGames);
                }
                GamesPlayed = new ObservableCollection<GamesInfo>(gamesPlayed.OrderBy(game => game.Id));

            }
            else
            {
                ObservableCollection<GamesInfo> gamesPlayed = GamesPlayed;
                foreach (GamesInfo removeGames in GamesToAddDeleteList)
                {

                    gamesPlayed.Remove(gamesPlayed.Where(gaga => gaga.Id == removeGames.Id).Single());
                }

                GamesPlayed = gamesPlayed;
            }
            GamesToAddDeleteList = new ObservableCollection<GamesInfo>();
            currentUserInfo.GameId = new List<Guid> { };

            foreach (GamesInfo gamePlayed in GamesPlayed)
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
            if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }

            await userService.DeleteUser(currentUserInfo.Id);

            await CoreMethods.PopPageModel(new UserInfo(), false, true);
        });

        private bool Validate(UserInfo userInfo)
        {
            var validationContext = new ValidationContext<UserInfo>(userInfo);
            var validationResult = userInfoValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                switch (error.PropertyName)
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
                        UserUserNameError = error.ErrorMessage;
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

        private void SetAdd()
        {
            Title = "New User";

            VisablePassword = true;
            VisableDeleteGames = true;
            VisableAddGame = true;
            VisableButtonsUsers = true;
            VisableAdd = true;
            VisableCancel = false;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;

            EnableEditData = true;

            currentUserInfo = new UserInfo
            {
                Id = Guid.Empty,
                GameId = new List<Guid>{}
            };

            GamesPlayed = new ObservableCollection<GamesInfo>();
        }

        private async void SetRead()
        {
            Title = currentUserInfo.UserName;

            VisablePassword = false;
            VisableDeleteGames = false;
            VisableAddGame = false;
            VisableButtonsUsers = true;
            VisableAdd = false;
            VisableCancel = false;
            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;

            EnableEditData = false;
            EnableGameList = false;

            var allGames = await gameService.GetAllGames();

            GamesPlayed = new ObservableCollection<GamesInfo>(allGames.Where(gamess => currentUserInfo.GameId.Contains(gamess.Id)));

            if (GamesPlayed.Count() > 0)
            {
                EnableGameList = true;
            }
        }

        private void SetEdit()
        {
            Title = "Edit " + currentUserInfo.UserName;

            VisablePassword = false;
            VisableDeleteGames = true;
            VisableAddGame = true;
            VisableButtonsUsers = true;
            VisableAdd = false;
            VisableCancel = true;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;

            EnableEditData = true;
        }
    }
}