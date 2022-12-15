using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class PublisherViewModel: BaseViewModel<PublisherInfo, IPublisherService, PublisherInfoViewModel>
    {
        public PublisherViewModel(IPublisherService publisherService) : base(publisherService)
        { }

        public override async Task Refresh()
        {
            await base.Refresh();

            Title = "Publishers";
        }
    }
}