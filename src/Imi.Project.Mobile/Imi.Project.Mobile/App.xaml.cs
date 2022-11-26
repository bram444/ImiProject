using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Net;
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
