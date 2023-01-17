using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;

namespace Imi.Project.Mobile.Domain.Interface
{
    public class PublisherInfoService: BaseService<PublisherInfo, NewPublisherInfo, UpdatePublisherInfo>, IPublisherService
    {
        public PublisherInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Publisher")
        {
        }
    }
}