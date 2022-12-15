using FluentValidation;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserInfoViewModel: BaseEditListViewModel<UserInfo, GamesInfo, IUserService, IGameService>
    {
        public UserInfoViewModel(IUserService userService, IGameService gameService)
            : base(userService, gameService, new UserInfoValidator())
        { }

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
        #endregion

        public override void LoadState()
        {
            Name = CurrentItem.UserName;
            FirstName = CurrentItem.FirstName;
            LastName = CurrentItem.LastName;
            Email = CurrentItem.Email;
            Password = CurrentItem.Password;
            PasswordConfirm = CurrentItem.ConfirmPassword;
            CurrentItemIdList = new ObservableCollection<Guid>(CurrentItem.GameId);

            List<GamesInfo> selectGame = new List<GamesInfo> { new GamesInfo
                {
                    Id = Guid.Empty,
                    Name = "Select a game"
                }};

            LoadList(selectGame);
        }

        public override ICommand AddCommand => new Command(() =>
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

                var allGames = CurrentItemList;

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

                AddItem(userEdit);
            });

        public override ICommand SaveCommand => new Command(() =>
            {
                var allGames = CurrentItemList;

                List<Guid> gameId = new List<Guid>();

                foreach(GamesInfo game in allGames.Distinct())
                {
                    gameId.Add(game.Id);
                }

                UserInfo userValidate = new UserInfo
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

                SaveItem(userValidate);
            });

        public override ICommand AddPickerItem => new Command(() =>
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

        public override ICommand DeletePickerItem => new Command(() =>
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

        public override void SetAdd()
        {
            Title = "New User";
            VisablePassword = true;

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