using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.ViewModels;
using Plugin.FirebasePushNotification;
using System;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IGameService>(new GameInfoService());
            FreshIOC.Container.Register<IUserService>(new UserInfoService());
            FreshIOC.Container.Register<IGenreService>(new GenreInfoService());
            FreshIOC.Container.Register<IPublisherService>(new PublisherInfoService());


            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenFresh;
            }
        }

        private void Current_OnTokenFresh(object source,FirebasePushNotificationTokenEventArgs e)
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
