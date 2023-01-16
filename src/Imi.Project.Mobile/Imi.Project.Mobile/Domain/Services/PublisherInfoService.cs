using Imi.Project.Mobile.Domain.Model;

namespace Imi.Project.Mobile.Domain.Services
{
    public class PublisherInfoService: BaseService<PublisherInfo, NewPublisherInfo, UpdatePublisherInfo>, IPublisherService
    {
        public PublisherInfoService(CustomHttpClient customHttpClient) : base(customHttpClient, "/api/Publisher")
        {
        }
    }
}