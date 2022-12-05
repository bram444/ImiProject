using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class PublisherViewModel : FreshBasePageModel
    {
        private PublisherInfo currentPublisherInfo;
        private readonly IPublisherService publisherService;

        public PublisherViewModel(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        #region Properties

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private ObservableCollection<PublisherInfo> publisherInfo;
        public ObservableCollection<PublisherInfo> PublisherInfo
        {
            get { return publisherInfo; }
            set
            {
                publisherInfo = value;
                RaisePropertyChanged(nameof(PublisherInfo));
            }
        }

        private string publisherName;
        public string PublisherName
        {
            get { return publisherName; }
            set
            {
                publisherName = value;
                RaisePropertyChanged(nameof(PublisherName));
            }
        }

        private string publisherCountry;
        public string PublisherCountry
        {
            get { return publisherCountry; }
            set
            {
                publisherCountry = value;
                RaisePropertyChanged(nameof(PublisherCountry));
            }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get { return visableAdd; }
            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        #endregion

        public async override void Init(object initData)
        {
            base.Init(initData);

            currentPublisherInfo = initData as PublisherInfo;

            await RefreshPublisher();
        }

        public async override void ReverseInit(object initData)
        {
            base.ReverseInit(initData);

            if (initData is PublisherInfo)
            {
                currentPublisherInfo = initData as PublisherInfo;
            }

            await RefreshPublisher();
        }

        private async Task RefreshPublisher()
        {
            PublisherInfo = null;

            VisableAdd = false;
            Title = "Loading";

            PublisherInfo = new ObservableCollection<PublisherInfo>(await publisherService.GetAllPublisher());

            VisableAdd = true;
            Title = "Publishers";

            currentPublisherInfo = new PublisherInfo
            {
                Id = Guid.NewGuid()
            };

            LoadPublisherState();
        }

        public ICommand AddPublisherItem => new Command<PublisherInfo>(
            async (PublisherInfo publisher) =>
            {
                SavePublisherState();
                await CoreMethods.PushPageModel<PublisherInfoViewModel>(publisher);
            });

        private void LoadPublisherState()
        {
            PublisherName = currentPublisherInfo.Name;
            PublisherCountry = currentPublisherInfo.Country;
        }
        private void SavePublisherState()
        {
            currentPublisherInfo.Name = PublisherName;
            currentPublisherInfo.Country = PublisherCountry;
        }
    }
}