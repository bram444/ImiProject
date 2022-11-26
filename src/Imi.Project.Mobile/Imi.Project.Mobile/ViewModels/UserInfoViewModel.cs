using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Validators;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserInfoViewModel : FreshBasePageModel
    {
        private UserInfo currentUserInfo;
        private readonly IValidator userInfoValidator;

        private readonly IUserService userService;

        public UserInfoViewModel(IUserService userService)
        {
            this.userService = userService;

            userInfoValidator = new UserInfoValidator();
        }

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

        public override void Init(object initData)
        {
            if (initData != null)
            {
                currentUserInfo = initData as UserInfo;

                Title = currentUserInfo.UserName;
                LoadUserState();
                SetRead();

            }
            else
            {
                Title = "New User";
                SetAdd();
            }

            base.Init(initData);
        }

        private void LoadUserState()
        {
            UserName = null;
            FirstName = null;
            lastName = null;
            Email = null;

            UserName = currentUserInfo.UserName;
            FirstName = currentUserInfo.FirstName;
            lastName = currentUserInfo.LastName;
            Email = currentUserInfo.Email;
        }

        private void SaveUserState()
        {
            currentUserInfo.UserName = UserName;
            currentUserInfo.LastName = LastName;
            currentUserInfo.FirstName = FirstName;
            currentUserInfo.Email = Email;
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

                    UserInfo userEdit = new UserInfo
                    {
                        Id = Guid.NewGuid(),
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        UserName = this.UserName,
                        Email = this.Email,
                    };

                    if (Validate(userEdit))
                    {

                        await userService.AddUser(userEdit);
                        await CoreMethods.PopPageModel(userEdit, false, true);
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

        public ICommand DeleteCommand => new Command(async () =>
        {
            await userService.DeleteUser(currentUserInfo.Id);
            await CoreMethods.PopPageModel(new UserInfo(),false,true);
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
            VisableAdd = true;
            VisableCancel = false;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;
        }

        private void SetRead()
        {
            Title = currentUserInfo.UserName;
            VisableAdd = false;
            VisableCancel = false;

            EnableEditData = false;

            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;
        }

        private void SetEdit()
        {
            Title = "Edit " + currentUserInfo.UserName;

            VisableAdd = false;
            VisableCancel = true;

            EnableEditData = true;

            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;
        }
    }
}
