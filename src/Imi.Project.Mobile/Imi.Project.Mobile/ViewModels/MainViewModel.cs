using FreshMvvm;
using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel: FreshBasePageModel
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public MainViewModel(ITokenService tokenService, IUserService userService)
        {
            AppName = AppInfo.Name;
            AppVersion = AppInfo.VersionString;
            _tokenService = tokenService;
            _userService = userService;
        }

        public override void ReverseInit(object returnedData)
        {
            if(returnedData.GetType() == typeof(string))
            {
                Token = returnedData.ToString();
                _userService.SetToken(Token);
            } else if(returnedData.GetType() == typeof(Guid))
            {
                Guid id = Guid.Parse(returnedData.ToString());
                if(_tokenService.GetId(Token) == id)
                {
                    Token = null;
                    _userService.SetToken(null);
                }
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
                RaisePropertyChanged(nameof(ShowCurrent));
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

        public bool ShowCurrent
        {
            get
            {
                return Token != null;
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

        public ICommand OpenCurrentUser
        {
            get
            {
                return new Command(async () =>
                {

                    UserInfo user = await _userService.GetById(_tokenService.GetId(Token));

                    if(IsLoggedIn)
                    {

                        await CoreMethods.PushPageModel<UserInfoViewModel>(user);
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

        public ICommand CurrentUser
        {
            get
            {
                return new Command(async () =>
                {
                    if(IsLoggedIn)
                    {
                        object obj = Token;

                        await CoreMethods.PushPageModel<UserInfoViewModel>(Token);
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
                    _userService.SetToken(null);
                });
            }
        }
    }
}