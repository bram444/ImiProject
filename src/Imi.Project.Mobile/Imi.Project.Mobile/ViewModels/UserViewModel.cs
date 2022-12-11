using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        private readonly IUserService userService;

        public UserViewModel(IUserService userService) : base()
        {
            this.userService = userService;
        }

        #region Properties
        private ObservableCollection<UserInfo> userInfo;
        public ObservableCollection<UserInfo> UserInfo
        {
            get => userInfo;
            set
            {
                userInfo = value;
                RaisePropertyChanged(nameof(UserInfo));
            }
        }
        #endregion

        public override async void Init(object initData)
        {
            base.Init(initData);


            await Refresh();
        }

        public override async void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            await Refresh();
        }

        public override async Task Refresh()
        {
            UserInfo = null;

            VisableAdd = false;

            Title = "Loading";

            UserInfo = new ObservableCollection<UserInfo>(await userService.GetAllUser());

            VisableAdd = true;

            Title = "Users";
        }

        public ICommand AddUserItem => new Command<UserInfo>(
            async (UserInfo userInfo) =>
            {
                await CoreMethods.PushPageModel<UserInfoViewModel>(userInfo, false, true);
            });
    }
}