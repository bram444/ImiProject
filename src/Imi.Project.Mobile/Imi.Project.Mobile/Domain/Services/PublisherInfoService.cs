using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class PublisherInfoService: BaseService<PublisherInfo>, IPublisherService
    {
        public PublisherInfoService(CustomHttpClient customHttpClient):base(customHttpClient, "/api/Publisher")
        {
        }
    }
}