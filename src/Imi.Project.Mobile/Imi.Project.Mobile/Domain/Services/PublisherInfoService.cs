using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Services
{
    public class PublisherInfoService:IPublisherService
    {
        private static List<PublisherInfo> inMemoryPublisher = new List<PublisherInfo>
        {
            new PublisherInfo
            {
                Id= Guid.Parse("00000000-0000-0000-0000-000000000001"),
                 Country="Japan",
                  Name="Nintendo"
            }

        };
        public async Task<List<PublisherInfo>> GetAllPublisher()
        {
            return await Task.FromResult(inMemoryPublisher);
        }

        public async Task<PublisherInfo> PublisherById(Guid id)
        {
            return await Task.FromResult(inMemoryPublisher.Where(publisher => publisher.Id == id).First());
        }

        public Task<PublisherInfo> UpdatePublisher(PublisherInfo publisher)
        {
            var publisherInfoEdit = PublisherById(publisher.Id);
            publisherInfoEdit.Result.Name = publisher.Name;
            publisherInfoEdit.Result.Country = publisher.Country;

            return publisherInfoEdit;
        }

        public Task DeletePublisher(Guid id)
        {
            inMemoryPublisher.Remove(PublisherById(id).Result);
            return Task.CompletedTask;
        }

        public Task<PublisherInfo> AddPublisher(PublisherInfo publisher)
        {
            inMemoryPublisher.Add(publisher);
            return PublisherById(publisher.Id);
        }
    }
}
