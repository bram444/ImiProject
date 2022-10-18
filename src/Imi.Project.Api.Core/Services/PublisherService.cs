using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class PublisherService : IPublisherService
    {

        private readonly IPublisherRepository _publisherRespository;

        public PublisherService(IPublisherRepository publisherRespository)
        {
            _publisherRespository = publisherRespository;
        }

        private Publisher CreateEntity(PublisherResponseDto publisherResponseDto)
        {
            Publisher genre = new Publisher
            {
                Id = publisherResponseDto.Id,
                 Country = publisherResponseDto.Country,
                  Name= publisherResponseDto.Name,
            };
            return genre;
        }

        public async Task<Publisher> AddAsync(PublisherResponseDto entity)
        {
            return await _publisherRespository.AddAsync(CreateEntity(entity));
        }

        public async Task<Publisher> DeleteAsync(PublisherResponseDto entity)
        {
            return await _publisherRespository.DeleteAsync(CreateEntity(entity));
        }

        public IQueryable<Publisher> GetAll()
        {
            return _publisherRespository.GetAll();
        }

        public async Task<Publisher> GetByIdAsync(Guid id)
        {
            return await _publisherRespository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Publisher>> ListAllAsync()
        {
            return await _publisherRespository.ListAllAsync();
        }

        public async Task<IEnumerable<Publisher>> SearchAsync(string search)
        {
            return await _publisherRespository.SearchAsync(search);

        }

        public async Task<IEnumerable<Publisher>> SearchByCountryAsync(string country)
        {
            return await _publisherRespository.SearchByCountryAsync(country);

        }

        public async Task<Publisher> UpdateAsync(PublisherResponseDto entity)
        {
            return await _publisherRespository.UpdateAsync(CreateEntity(entity));
        }
    }
}
