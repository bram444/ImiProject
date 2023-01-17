using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserInfoViewModel: BaseEditListViewModel<UserInfo, GamesInfo, IUserService, IGameService, RegistrationInfo, UpdateUserInfo, NewGameInfo, UpdateGameInfo>
    {

        public UserInfoViewModel(IUserService userService, IGameService gameService)
            : base(userService, gameService, new UpdateUserInfoValidator(), new RegistrationValidator())
        { }

        #region Properties
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }

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
            get
            {
                return lastName;
            }

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
            get
            {
                return email;
            }

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
            get
            {
                return userEmailError;
            }

            set
            {
                userEmailError = value;
                RaisePropertyChanged(nameof(UserEmailError));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }

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
            get
            {
                return userPasswordError;
            }

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
            get
            {
                return passwordConfirm;
            }

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
            get
            {
                return userPasswordConfirmError;
            }

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
            get
            {
                return userFirstNameError;
            }

            set
            {
                userFirstNameError = value;
                RaisePropertyChanged(nameof(UserFirstNameError));
            }
        }

        private string userLastNameError;
        public string UserLastNameError
        {
            get
            {
                return userLastNameError;
            }

            set
            {
                userLastNameError = value;
                RaisePropertyChanged(nameof(UserLastNameError));
            }
        }

        private bool visablePassword;
        public bool VisablePassword
        {
            get
            {
                return visablePassword;
            }

            set
            {
                visablePassword = value;
                RaisePropertyChanged(nameof(VisablePassword));
            }
        }
        public bool ShowButton
        {
            get
            {
                return !CurrentItem.ApprovedTerms;
            }
        }

        private bool terms;
        public bool Terms
        {
            get
            {
                return terms;
            }

            set
            {
                terms = value;
                RaisePropertyChanged(nameof(Terms));
            }
        }
        #endregion

        public override void LoadState()
        {
            Name = CurrentItem.UserName;
            FirstName = CurrentItem.FirstName;
            LastName = CurrentItem.LastName;
            Email = CurrentItem.Email;
            Password = CurrentItem.Password;
            PasswordConfirm = CurrentItem.ConfirmPassword;
            CurrentItemIdList = new ObservableCollection<Guid>(CurrentItem.Games.Select(game => game.Id));
            Terms = CurrentItem.ApprovedTerms;
            List<GamesInfo> selectGame = new List<GamesInfo> { new GamesInfo
                {
                    Id = Guid.Empty,
                    Name = "Select a game"
                }};

            LoadList(selectGame);
        }

        public override ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
            {
                base.AddCommand.Execute(null);

                if(FirstName == null)
                {
                    FirstName = string.Empty;
                }

                if(LastName == null)
                {
                    LastName = string.Empty;
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

                ObservableCollection<GamesInfo> allGames = CurrentItemList;

                List<Guid> gameId = new List<Guid>();

                foreach(GamesInfo game in allGames.Distinct())
                {
                    gameId.Add(game.Id);
                }

                RegistrationInfo userEdit = new RegistrationInfo
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = Name,
                    Email = Email,
                    Password = Password,
                    ConfirmPassword = PasswordConfirm,
                    ApprovedTerms = true,
                    BirthDay = DateTime.Now
                };
                ApiResponse<UserInfo> apiResponse = await AddItem(userEdit);
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
                    ObservableCollection<GamesInfo> allGames = CurrentItemList;

                    List<Guid> gameId = new List<Guid>();

                    foreach(GamesInfo game in allGames.Distinct())
                    {
                        gameId.Add(game.Id);
                    }

                    UpdateUserInfo userValidate = new UpdateUserInfo
                    {
                        Id = CurrentItem.Id,
                        FirstName = FirstName,
                        LastName = LastName,
                        UserName = Name,
                        GameId = gameId,
                        ApprovedTerms = Terms,
                    };

                    ApiResponse<UserInfo> apiResponse = await SaveItem(userValidate);
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
            TextPicker = "Add game";

            List<GamesInfo> games = new List<GamesInfo>
            {
                new GamesInfo
                {
                     Id=Guid.Empty,
                     Name="Select a game"
                }
            };

            base.AddPickerItem.Execute(games);
        });
            }
        }

        public override ICommand DeletePickerItem
        {
            get
            {
                return new Command(() =>
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

            base.DeletePickerItem.Execute(games);
        });
            }
        }

        public override bool Validate(RegistrationInfo userInfo)
        {
            ValidationContext<RegistrationInfo> validationContext = new ValidationContext<RegistrationInfo>(userInfo);
            ValidationResult validationResult = NewValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
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

                    case nameof(userInfo.ConfirmPassword):
                        UserPasswordConfirmError = error.ErrorMessage;
                        break;

                    default:
                        NameError = "Unknown Error";
                        UserFirstNameError = "Unknown Error";
                        UserLastNameError = "Unknown Error";
                        UserEmailError = "Unknown Error";
                        break;
                }
            }

            return validationResult.IsValid;
        }

        public override bool Validate(UpdateUserInfo userInfo)
        {
            ValidationContext<UpdateUserInfo> validationContext = new ValidationContext<UpdateUserInfo>(userInfo);
            ValidationResult validationResult = UpdateValidator.Validate(validationContext);

            foreach(ValidationFailure error in validationResult.Errors)
            {
                switch(error.PropertyName)
                {
                    case nameof(userInfo.FirstName):
                        UserFirstNameError = error.ErrorMessage;
                        break;

                    case nameof(userInfo.LastName):
                        UserLastNameError = error.ErrorMessage;
                        break;

                    case nameof(userInfo.UserName):
                        NameError = error.ErrorMessage;
                        break;

                    default:
                        NameError = "Unknown Error";
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

            CurrentItem = new UserInfo
            {
                Id = Guid.Empty,
                Games = new List<GamesInfo>(),
            };

            base.SetAdd();
        }

        public override void SetRead()
        {
            Title = CurrentItem.UserName;
            VisablePassword = false;

            base.SetRead();
        }

        public override void SetEdit()
        {
            Title = "Edit " + CurrentItem.UserName;
            VisablePassword = false;

            base.SetEdit();
        }
    }
}