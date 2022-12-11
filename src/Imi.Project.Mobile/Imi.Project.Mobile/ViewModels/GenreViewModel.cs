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
    public class GenreViewModel: BaseViewModel
    {
        private readonly IGenreService genreService;

        public GenreViewModel(IGenreService genreService) : base()
        {
            this.genreService = genreService;
        }

        #region Properties

        private ObservableCollection<GenreInfo> genreInfo;
        public ObservableCollection<GenreInfo> GenreInfo
        {
            get => genreInfo;
            set
            {
                genreInfo = value;
                RaisePropertyChanged(nameof(GenreInfo));
            }
        }
        #endregion

        public override async void Init(object initData)
        {
            base.Init(initData);


            await Refresh();
        }

        public override async void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            await Refresh();
        }

        public override async Task Refresh()
        {
            GenreInfo = null;

            VisableAdd = false;

            Title = "Loading";

            GenreInfo = new ObservableCollection<GenreInfo>(await genreService.GetAllGenre());

            VisableAdd = true;

            Title = "Genres";
        }

        public ICommand AddGenreItem => new Command<GenreInfo>(
            async (GenreInfo genreInfo) =>
            {
                await CoreMethods.PushPageModel<GenreInfoViewModel>(genreInfo);
            });
    }
}