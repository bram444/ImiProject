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
        string baseUrl = Constants.baseUrl;

        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public PublisherInfoService(CustomHttpClient customHttpClient)
        {
            _httpClient = customHttpClient;
        }
        public async Task<IEnumerable<PublisherInfo>> GetAllPublisher()
        {
            return await _httpClient.GetApiResult<List<PublisherInfo>>($"{baseUrl}/api/Publisher/");
        }

        public async Task<PublisherInfo> PublisherById(Guid id)
        {
            return await _httpClient.GetApiResult<PublisherInfo>($"{baseUrl}/api/Publisher/{id}");
        }

        public async Task<PublisherInfo> UpdatePublisher(PublisherInfo publisher)
        {
            return await _httpClient.PutCallApi<PublisherInfo, PublisherInfo>($"{baseUrl}/api/Publisher/", publisher);
        }

        public async Task<PublisherInfo> DeletePublisher(Guid id)
        {
            return await _httpClient.DeleteCallApi<PublisherInfo>($"{baseUrl}/api/Publisher/{id}");

        }

        public async Task<PublisherInfo> AddPublisher(PublisherInfo publisher)
        {
            return await _httpClient.PostCallApi<PublisherInfo, PublisherInfo>($"{baseUrl}/api/Publisher", publisher);
        }
    }
}
