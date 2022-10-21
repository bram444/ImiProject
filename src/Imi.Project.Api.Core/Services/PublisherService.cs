using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Dto.User;
using Imi.Project.Api.Core.Dto.UserGame;
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
        private readonly IGameRepository _gameRepository;


        public PublisherService(IPublisherRepository publisherRespository, IGameRepository gameRepository)
        {
            _publisherRespository = publisherRespository;
            _gameRepository = gameRepository;
        }

        private Publisher CreateEntity(PublisherResponseDto publisherResponseDto)
        {
            Publisher publisher = new Publisher
            {
                Id = publisherResponseDto.Id,
                 Country = publisherResponseDto.Country,
                  Name= publisherResponseDto.Name,
            };
            return publisher;
        }

        private PublisherResponseDto CreateDto(Publisher publisher)
        {
            PublisherResponseDto publisherResponseDto = new PublisherResponseDto
            {
                Id = publisher.Id,
                Country = publisher.Country,
                Name = publisher.Name,
            };
            return publisherResponseDto;
        }

        public async Task<ServiceResult<PublisherResponseDto>> AddAsync(PublisherResponseDto response)
        {
            var serviceResponse = new ServiceResult<PublisherResponseDto>();

            try
            {
                serviceResponse.Result = CreateDto(await _publisherRespository.AddAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public async Task<ServiceResult<PublisherResponseDto>> DeleteAsync(Guid id)
        {
            var serviceResponse = new ServiceResult<PublisherResponseDto>();

            if (await _publisherRespository.GetByIdAsync(id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("publisher does not exist");
                return serviceResponse;
            }

            if (await _gameRepository.GetByPublisherIdAsync(id) !=null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("Please delete the games before deleting the publisher");
                return serviceResponse;
            }

            try
            {
                serviceResponse.Result = CreateDto(await _publisherRespository.DeleteAsync(await _publisherRespository.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }

        public IQueryable<PublisherResponseDto> GetAll()
        {
            List<PublisherResponseDto> publisherResponseDtos = new List<PublisherResponseDto>();
            foreach (Publisher response in _publisherRespository.GetAll())
            {
                publisherResponseDtos.Add(CreateDto(response));
            }

            return publisherResponseDtos.AsQueryable();
        }

        public async Task<PublisherResponseDto> GetByIdAsync(Guid id)
        {
            return CreateDto( await _publisherRespository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<PublisherResponseDto>> ListAllAsync()
        {
            List<PublisherResponseDto> publisherResponseDtos = new List<PublisherResponseDto>();
            foreach (Publisher entity in await _publisherRespository.ListAllAsync())
            {
                publisherResponseDtos.Add(CreateDto(entity));
            }

            return publisherResponseDtos;
        }

        public async Task<IEnumerable<PublisherResponseDto>> SearchAsync(string search)
        {
            List<PublisherResponseDto> publisherResponseDtos = new List<PublisherResponseDto>();
            foreach (Publisher entity in await _publisherRespository.SearchAsync(search))
            {
                publisherResponseDtos.Add(CreateDto(entity));
            }

            return publisherResponseDtos;
        }

        public async Task<IEnumerable<PublisherResponseDto>> SearchByCountryAsync(string country)
        {
            List<PublisherResponseDto> publisherResponseDtos = new List<PublisherResponseDto>();
            foreach (Publisher entity in await _publisherRespository.SearchByCountryAsync(country))
            {
                publisherResponseDtos.Add(CreateDto(entity));
            }

            return publisherResponseDtos;
        }

        public async Task<ServiceResult<PublisherResponseDto>> UpdateAsync(PublisherResponseDto response)
        {
            var serviceResponse = new ServiceResult<PublisherResponseDto>();

            if (await _publisherRespository.GetByIdAsync(response.Id) == null)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add("publisher does not exist");
                return serviceResponse;
            }

            try
            {
                await _publisherRespository.UpdateAsync(CreateEntity(response));
                serviceResponse.Result = CreateDto(await _publisherRespository.UpdateAsync(CreateEntity(response)));
            }
            catch (Exception ex)
            {
                serviceResponse.HasErrors = true;
                serviceResponse.ErrorMessages.Add(ex.Message);
            }
            return serviceResponse;
        }
    }
}
