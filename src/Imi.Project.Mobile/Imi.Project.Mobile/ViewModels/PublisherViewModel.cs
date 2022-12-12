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
    public class PublisherViewModel: BaseViewModel<PublisherInfo, IPublisherService>
    {

        public PublisherViewModel(IPublisherService publisherService) : base(publisherService)
        {}

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Publishers";
        }

        public ICommand AddPublisherItem => new Command<PublisherInfo>(
            async (PublisherInfo publisher) =>
            {
                await CoreMethods.PushPageModel<PublisherInfoViewModel>(publisher);
            });
    }
}