using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel:FreshBasePageModel
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;
        private readonly IUserService userService;

        public string appName;
        public string AppName
        {
            get { return appName; }
            set
            {
                appName = value;
                RaisePropertyChanged(nameof(AppName));
            }
        }

        public string appVersion;
        public string AppVersion
        {
            get { return appVersion; }
            set
            {
                appVersion = value;
                RaisePropertyChanged(nameof(AppVersion));
            }
        }

        public MainViewModel(IGameService gameService, IGenreService genreService, IPublisherService publisherService, IUserService userService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.publisherService = publisherService;
            this.userService = userService;

            AppName = AppInfo.Name;

            AppVersion = AppInfo.VersionString;

        }

        public ICommand OpenGame => new Command(async () =>
        {
            await CoreMethods.PushPageModel<GameViewModel>(true);
        });

        public ICommand OpenUser=> new Command(async () =>
        {
            await CoreMethods.PushPageModel<UserViewModel>(true);
        });

        public ICommand OpenPublisher => new Command(async () =>
        {
            await CoreMethods.PushPageModel<PublisherViewModel>(true);
        });

        public ICommand OpenGenre=> new Command(async () =>
        {
            await CoreMethods.PushPageModel<GenreViewModel>(true);
        });
    }
}
