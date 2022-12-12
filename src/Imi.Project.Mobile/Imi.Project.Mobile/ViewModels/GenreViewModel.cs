using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GenreViewModel: BaseViewModel<GenreInfo, IGenreService>
    {

        public GenreViewModel(IGenreService genreService) : base(genreService)
        {
        }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Genres";
        }

        public ICommand AddGenreItem => new Command<GenreInfo>(
            async (GenreInfo genreInfo) =>
            {
                await CoreMethods.PushPageModel<GenreInfoViewModel>(genreInfo);
            });
    }
}