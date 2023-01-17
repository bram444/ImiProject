using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserViewModel: BaseViewModel<UserInfo, IUserService, UserInfoViewModel, RegistrationInfo, UpdateUserInfo>
    {
        public UserViewModel(IUserService userService) : base(userService)
        { }

        public override async void ReverseInit(object initData)
        {
            if(initData.GetType() == typeof(Guid))
            {

                if(_tokenService.GetId(Token) == Guid.Parse(initData.ToString()))
                {
                    await CoreMethods.PopPageModel(initData);
                }
            }
            await Refresh();
        }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Users";
        }
    }
}