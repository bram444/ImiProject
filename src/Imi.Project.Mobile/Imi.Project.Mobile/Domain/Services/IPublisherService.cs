using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherInfo>> GetAllPublisher();
        Task<PublisherInfo> PublisherById(Guid id);
        Task<PublisherInfo> UpdatePublisher(PublisherInfo publisher);
        Task<PublisherInfo> DeletePublisher(Guid id);
        Task<PublisherInfo> AddPublisher(PublisherInfo publisher);
    }
}