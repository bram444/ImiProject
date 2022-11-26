using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class PublisherViewModel : FreshBasePageModel
    {
        private readonly IPublisherService publisherService;

        private PublisherInfo currentPublisherInfo;

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

        private List<PublisherInfo> publisherInfo;
        public List<PublisherInfo> PublisherInfo
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

        public PublisherViewModel(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

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

            PublisherInfo = publisherService.GetAllPublisher().Result;

                Title = "Publishers";
            if (currentPublisherInfo != null&&currentPublisherInfo.Id != Guid.Empty)
            {
                currentPublisherInfo = await publisherService.PublisherById(currentPublisherInfo.Id);
            }
            else
            {
                currentPublisherInfo = new PublisherInfo
                {
                    Id = Guid.NewGuid()
                };
            }
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
