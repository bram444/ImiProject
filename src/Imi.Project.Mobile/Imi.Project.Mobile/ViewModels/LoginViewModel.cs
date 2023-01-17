using FreshMvvm;
using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel: FreshBasePageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                LoginError = null;
                RaisePropertyChanged(nameof(UserName));
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
                LoginError = null;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private bool isNotLoading = true;
        public bool IsNotLoading
        {
            get
            {
                return isNotLoading;
            }

            set
            {
                isNotLoading = value;
                RaisePropertyChanged(nameof(IsNotLoading));
            }
        }

        private string loginError;
        public string LoginError
        {
            get
            {
                return loginError;
            }

            set
            {
                loginError = value;
                RaisePropertyChanged(nameof(LoginError));
            }
        }

        public ICommand LogIn
        {
            get
            {
                return new Command(async () =>
                {

                    LogInInfo login = new LogInInfo
                    {
                        Password = Password,
                        UserName = UserName
                    };

                    if(login.Password != null && login.UserName != null)
                    {
                        IsNotLoading = false;
                        TokenResponse tokenResponse = await _authenticationService.Login(login);
                        if(tokenResponse.IsSuccess)
                        {
                            await CoreMethods.PopPageModel(tokenResponse.Token, false, true);
                        } else
                        {

                            LoginError = string.Join(System.Environment.NewLine, tokenResponse.Messages);
                        }
                    } else
                    {
                        LoginError = "Naam en wachtwoord moeten ingegeven worden.";
                    }

                    IsNotLoading = true;
                });
            }
        }
    }
}