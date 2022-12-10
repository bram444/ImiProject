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
    public class GenreViewModel: FreshBasePageModel
    {
        private readonly IGenreService genreService;

        private GenreInfo currentGenreInfo;

        public GenreViewModel(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        #region Properties

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

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

        private string genreName;
        public string GenreName
        {
            get => genreName;
            set
            {
                genreName = value;
                RaisePropertyChanged(nameof(GenreName));
            }
        }

        private string genreDescription;
        public string GenreDescription
        {
            get => genreDescription;
            set
            {
                genreDescription = value;
                RaisePropertyChanged(nameof(GenreDescription));
            }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get => visableAdd;
            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        #endregion

        public override async void Init(object initData)
        {
            base.Init(initData);

            currentGenreInfo = initData as GenreInfo;

            await RefreshGenre();
        }

        public override async void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            if(initData is GenreInfo)
            {
                currentGenreInfo = initData as GenreInfo;
            }
            await RefreshGenre();
        }

        private async Task RefreshGenre()
        {
            GenreInfo = null;

            VisableAdd = false;

            Title = "Loading";

            GenreInfo = new ObservableCollection<GenreInfo>(await genreService.GetAllGenre());

            VisableAdd = true;

            Title = "Genres";

            currentGenreInfo = new GenreInfo
            {
                Id = Guid.NewGuid()
            };

            LoadGenreState();
        }

        public ICommand AddGenreItem => new Command<GenreInfo>(
            async (GenreInfo genreInfo) =>
            {
                SaveGenreState();
                await CoreMethods.PushPageModel<GenreInfoViewModel>(genreInfo);
            });

        private void LoadGenreState()
        {
            GenreName = currentGenreInfo.Name;
            GenreDescription = currentGenreInfo.Description;
        }

        private void SaveGenreState()
        {
            currentGenreInfo.Description = GenreDescription;
            currentGenreInfo.Name = GenreName;
        }
    }
}