using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseViewModel<C, I, VM>: FreshBasePageModel
        where I : IBaseService<C>
        where VM : FreshBasePageModel
        //class, interface, ViewModel
    {
        public I Service;

        public BaseViewModel(I service)
        {
            Service = service;
        }

        private ObservableCollection<C> collection;
        public ObservableCollection<C> Collection
        {
            get => collection;
            set
            {
                collection = value;
                RaisePropertyChanged(nameof(Collection));
            }
        }

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

        public virtual async Task Refresh()
        {
            Collection = null;

            VisableAdd = false;

            Title = "Loading";

            Collection = new ObservableCollection<C>(await Service.GetAll());

            VisableAdd = true;
        }

        public virtual ICommand AddItem => new Command<C>(async (C item) =>
        {
            await CoreMethods.PushPageModel<VM>(item);
        });
    }
}