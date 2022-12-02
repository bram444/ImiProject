using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
