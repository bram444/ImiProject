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
    public class PublisherViewModel: BaseViewModel
    {
        private readonly IPublisherService publisherService;

        public PublisherViewModel(IPublisherService publisherService) : base()
        {
            this.publisherService = publisherService;
        }

        #region Properties

        private ObservableCollection<PublisherInfo> publisherInfo;
        public ObservableCollection<PublisherInfo> PublisherInfo
        {
            get => publisherInfo;
            set
            {
                publisherInfo = value;
                RaisePropertyChanged(nameof(PublisherInfo));
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
            PublisherInfo = null;

            VisableAdd = false;

            Title = "Loading";

            PublisherInfo = new ObservableCollection<PublisherInfo>(await publisherService.GetAllPublisher());

            VisableAdd = true;

            Title = "Publishers";
        }

        public ICommand AddPublisherItem => new Command<PublisherInfo>(
            async (PublisherInfo publisher) =>
            {
                await CoreMethods.PushPageModel<PublisherInfoViewModel>(publisher);
            });
    }
}