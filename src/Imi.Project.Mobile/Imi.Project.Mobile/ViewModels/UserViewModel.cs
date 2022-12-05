using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserViewModel : FreshBasePageModel
    {
        private readonly IUserService userService;

        private UserInfo currentUserInfo;

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
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
                RaisePropertyChanged(nameof(Email));
            }
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

        private ObservableCollection<UserInfo> userInfo;
        public ObservableCollection<UserInfo> UserInfo
        {
            get { return userInfo; }
            set
            {
                userInfo = value;
                RaisePropertyChanged(nameof(UserInfo));
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

        public UserViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            currentUserInfo = initData as UserInfo;

            await RefreshUser();
        }

        public async override void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            if (initData is UserInfo)
            {
                currentUserInfo = initData as UserInfo;
            }
            await RefreshUser();
        }

        private async Task RefreshUser()
        {
            UserInfo = null;

            VisableAdd = false;

            Title = "Loading";

            UserInfo = new ObservableCollection<UserInfo>( await userService.GetAllUser());

            VisableAdd = true;

                Title = "Users";

            currentUserInfo = new UserInfo
            {
                Id = Guid.NewGuid()
            };

            //if (currentUserInfo != null && currentUserInfo.Id != Guid.Empty)
            //{
            //    currentUserInfo = await userService.UserById(currentUserInfo.Id);
            //}
            //else
            //{
            //    currentUserInfo = new UserInfo
            //    {
            //        Id = Guid.NewGuid()
            //    };
            //}
            LoadUserState();
        }

        public ICommand AddUserItem => new Command<UserInfo>(
            async (UserInfo userInfo) =>
            {
                SaveUserState();
                await CoreMethods.PushPageModel<UserInfoViewModel>(userInfo, false, true);
            });

        private void LoadUserState()
        {
            Email = currentUserInfo.Email;
            FirstName=currentUserInfo.FirstName;
            LastName = currentUserInfo.LastName;
            UserName = currentUserInfo.UserName;
        }

        private void SaveUserState()
        {
            currentUserInfo.Email = Email;
            currentUserInfo.FirstName = FirstName;
            currentUserInfo.LastName = LastName;
            currentUserInfo.UserName = UserName;
        }
    }
}
