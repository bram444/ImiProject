using FreshMvvm;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel: FreshBasePageModel
    {

        public MainViewModel()
        {
            AppName = AppInfo.Name;
            AppVersion = AppInfo.VersionString;
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

        public ICommand OpenGame
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<GameViewModel>(true);
                });
            }
        }

        public ICommand OpenUser
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<UserViewModel>(true);
                });
            }
        }

        public ICommand OpenPublisher
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<PublisherViewModel>(true);
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
                    await CoreMethods.PushPageModel<RegistrationViewModel>(true);
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