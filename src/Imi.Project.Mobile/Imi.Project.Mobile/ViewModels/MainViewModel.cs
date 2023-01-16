using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel: FreshBasePageModel
    {
        private readonly ITokenService _tokenService;
        public MainViewModel(ITokenService tokenService)
        {
            AppName = AppInfo.Name;
            AppVersion = AppInfo.VersionString;
            _tokenService = tokenService;
        }

        public override void ReverseInit(object returnedData)
        {
            if(returnedData.GetType() == typeof(string))
            {
                Token = returnedData.ToString();
            }
        }

        private string token = null;
        public string Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
                IsLoggedIn = token != null;
                RaisePropertyChanged(nameof(ShowUsers));
                RaisePropertyChanged(nameof(Token));

            }
        }

        private string appName;
        public string AppName
        {
            get
            {
                return appName;
            }

            set
            {
                appName = value;
                RaisePropertyChanged(nameof(AppName));
            }
        }

        public bool IsNotLoggedIn
        {
            get { return !IsLoggedIn; }
        }

        private bool isLoggedIn = false;

        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }

            set
            {
                isLoggedIn = value;
                RaisePropertyChanged(nameof(IsLoggedIn));
                RaisePropertyChanged(nameof(IsNotLoggedIn));
            }
        }

        private string appVersion;
        public string AppVersion
        {
            get
            {
                return appVersion;
            }

            set
            {
                appVersion = value;
                RaisePropertyChanged(nameof(AppVersion));
            }
        }
        public bool ShowUsers
        {
            get
            {
                return Token != null && _tokenService.IsAdmin(Token);
            }
        }

        public ICommand OpenGame
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsLoggedIn)
                    {
                        await CoreMethods.PushPageModel<GameViewModel>(Token);
                    } else
                    {
                        await CoreMethods.PushPageModel<GameViewModel>(true);
                    }
                });
            }
        }

        public ICommand OpenUser
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsLoggedIn)
                    {
                        await CoreMethods.PushPageModel<UserViewModel>(Token);
                    } else
                    {
                        await CoreMethods.PushPageModel<UserViewModel>(true);
                    }
                });
            }
        }

        public ICommand OpenPublisher
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsLoggedIn)
                    {
                        await CoreMethods.PushPageModel<PublisherViewModel>(Token);
                    } else
                    {
                        await CoreMethods.PushPageModel<PublisherViewModel>(true);
                    }
                });
            }
        }

        public ICommand OpenGenre
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsLoggedIn)
                    {
                        await CoreMethods.PushPageModel<GenreViewModel>(Token);
                    } else
                    {
                        await CoreMethods.PushPageModel<GenreViewModel>(true);
                    }
                });
            }
        }

        public ICommand OpenLogin
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<LoginViewModel>(true);
                });
            }
        }

        public ICommand OpenRegister
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsLoggedIn)
                    {
                        await CoreMethods.PushPageModel<RegistrationViewModel>(Token);
                    } else
                    {
                        await CoreMethods.PushPageModel<RegistrationViewModel>(true);
                    }
                });
            }
        }
        public ICommand LogOut
        {
            get
            {
                return new Command(() =>
                {
                    Token = null;
                });
            }
        }
    }
}