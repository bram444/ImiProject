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
        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public PublisherInfoService(CustomHttpClient customHttpClient)
        {
            _httpClient = customHttpClient;
        }
        public async Task<List<PublisherInfo>> GetAllPublisher()
        {
            return await _httpClient.GetApiResult<List<PublisherInfo>>("https://172.31.224.1:5001/api/Publisher/");
        }

        public async Task<PublisherInfo> PublisherById(Guid id)
        {
            return await _httpClient.GetApiResult<PublisherInfo>($"https://172.31.224.1:5001/api/Publisher/{id}");
        }

        public async Task<PublisherInfo> UpdatePublisher(PublisherInfo publisher)
        {
            return await _httpClient.PutCallApi<PublisherInfo, PublisherInfo>($"https://172.31.224.1:5001/api/Publisher/{publisher.Id}", publisher);
        }

        public async Task<PublisherInfo> DeletePublisher(Guid id)
        {
            return await _httpClient.DeleteCallApi<PublisherInfo>($"https://172.31.224.1:5001/api/Publisher/{id}");

        }

        public async Task<PublisherInfo> AddPublisher(PublisherInfo publisher)
        {
            return await _httpClient.PostCallApi<PublisherInfo, PublisherInfo>($"https://172.31.224.1:5001/api/Publisher", publisher);
        }
    }
}
