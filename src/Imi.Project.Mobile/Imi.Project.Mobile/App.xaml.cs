using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.ViewModels;
using Plugin.FirebasePushNotification;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
    public partial class App: Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IGameService, GameInfoService>();
            FreshIOC.Container.Register<IUserService, UserInfoService>();
            FreshIOC.Container.Register<IGenreService, GenreInfoService>();
            FreshIOC.Container.Register<IPublisherService, PublisherInfoService>();
            FreshIOC.Container.Register<IAuthenticationService, AuthenticationService>();
            FreshIOC.Container.Register<ITokenService, TokenService>();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenFresh;
            }
        }

        private void Current_OnTokenFresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}