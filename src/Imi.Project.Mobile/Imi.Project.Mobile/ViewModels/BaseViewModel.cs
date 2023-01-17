using FreshMvvm;
using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseViewModel<C, I, VM, N, U>: FreshBasePageModel
        where I : IBaseService<C, N, U>
        where VM : FreshBasePageModel
        //class, interface, ViewModel
    {
        public I Service;
        public ITokenService _tokenService = new TokenService();
        public BaseViewModel(I service)
        {
            Service = service;
        }

        private string token = null;
        public string Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
                RaisePropertyChanged(nameof(Token));
                RaisePropertyChanged(nameof(IsAdmin));
            }
        }

        public bool IsAdmin
        {
            get
            {
                return _tokenService.IsAdmin(Token);
            }
        }

        private ObservableCollection<C> collection;
        public ObservableCollection<C> Collection
        {
            get
            {
                return collection;
            }

            set
            {
                collection = value;
                RaisePropertyChanged(nameof(Collection));
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private bool displayList;
        public bool DisplayList
        {
            get
            {
                return displayList;
            }

            set
            {
                displayList = value;
                RaisePropertyChanged(nameof(DisplayList));
            }
        }

        public async void InitAsync(object initData)
        {
            if(initData is string)
            {
                Token = initData.ToString();
                Service.SetToken(Token);

                base.Init(true);
            } else
            {
                base.Init(initData);
            }

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

            DisplayList = false;

            Title = "Loading";

            Collection = new ObservableCollection<C>(await Service.GetAll());

            DisplayList = true;
        }

        public virtual ICommand AddItem
        {
            get
            {
                return new Command<C>(async (C item) =>
                {
                    if(IsAdmin)
                    {
                        await CoreMethods.PushPageModel<VM>(item);
                    }
                });
            }
        }
    }
}
