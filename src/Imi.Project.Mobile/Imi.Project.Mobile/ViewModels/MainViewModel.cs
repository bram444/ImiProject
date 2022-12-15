using FreshMvvm;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel: FreshBasePageModel
    {
        public MainViewModel()
        {
            AppName = AppInfo.Name;
            AppVersion = AppInfo.VersionString;
        }

        public string appName;
        public string AppName
        {
            get => appName;
            set
            {
                appName = value;
                RaisePropertyChanged(nameof(AppName));
            }
        }

        public string appVersion;
        public string AppVersion
        {
            get => appVersion;
            set
            {
                appVersion = value;
                RaisePropertyChanged(nameof(AppVersion));
            }
        }

        public ICommand OpenGame => new Command(async () =>
        {
            await CoreMethods.PushPageModel<GameViewModel>(true);
        });

        public ICommand OpenUser => new Command(async () =>
        {
            await CoreMethods.PushPageModel<UserViewModel>(true);
        });

        public ICommand OpenPublisher => new Command(async () =>
        {
            await CoreMethods.PushPageModel<PublisherViewModel>(true);
        });

        public ICommand OpenGenre => new Command(async () =>
        {
            await CoreMethods.PushPageModel<GenreViewModel>(true);
        });
    }
}