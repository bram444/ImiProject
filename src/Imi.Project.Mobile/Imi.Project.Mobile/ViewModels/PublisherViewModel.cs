using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class PublisherViewModel: BaseViewModel<PublisherInfo, IPublisherService, PublisherInfoViewModel, NewPublisherInfo, UpdatePublisherInfo>
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