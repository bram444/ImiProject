using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class GenreViewModel: BaseViewModel<GenreInfo, IGenreService, GenreInfoViewModel, NewGenreInfo, UpdateGenreInfo>
    {
        public GenreViewModel(IGenreService genreService) : base(genreService)
        { }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Genres";
        }
    }
}