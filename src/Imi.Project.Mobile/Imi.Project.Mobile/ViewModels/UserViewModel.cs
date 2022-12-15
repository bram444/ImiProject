using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class UserViewModel: BaseViewModel<UserInfo, IUserService, UserInfoViewModel>
    {
        public UserViewModel(IUserService userService) : base(userService)
        { }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Users";
        }
    }
}