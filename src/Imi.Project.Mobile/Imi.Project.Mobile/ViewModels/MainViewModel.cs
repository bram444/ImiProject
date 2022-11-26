using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel:FreshBasePageModel
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;
        private readonly IUserService userService;

        public MainViewModel(IGameService gameService, IGenreService genreService, IPublisherService publisherService, IUserService userService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.publisherService = publisherService;
            this.userService = userService;
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
