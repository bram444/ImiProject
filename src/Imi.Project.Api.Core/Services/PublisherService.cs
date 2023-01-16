using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapper;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class PublisherService: BaseService<Publisher, IPublisherRepository, NewPublisherModel, UpdatePublisherModel>, IPublisherService
    {
        private readonly IGameRepository _gameRepository;

        public PublisherService(IPublisherRepository publisherRespository, IGameRepository gameRepository) : base(publisherRespository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<Publisher>>> SearchByCountryAsync(string country)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<Publisher>>
                {
                    Data = await _itemRepository.GetFilteredListAsync(publisher =>
                    publisher.Country.Contains(country))
                };
            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public override async Task<ServiceResultModel<Publisher>> AddAsync(NewPublisherModel response)
        {
            try
            {
                if(await _itemRepository.DoesExistAsync(pub => pub.Name == response.Name))
                {
                    return new ServiceResultModel<Publisher>
                    {
                        IsSuccess = false,
                        ValidationErrors = new List<string> { $"Publisher with name {response.Name} already exists" }
                    };
                }

                Publisher publisher = response.MapToEntity();

                await _itemRepository.AddAsync(publisher);

                return new ServiceResultModel<Publisher>
                {
                    Data = publisher
                };
            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public override async Task<ServiceResultModel<Publisher>> UpdateAsync(UpdatePublisherModel response)
        {
            try
            {
                ServiceResultModel<Publisher> result = new();

                if(!await _itemRepository.DoesExistAsync(response.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add("Publisher does not exist");
                }

                if(await _itemRepository.DoesExistAsync(pub => pub.Name == response.Name && (pub.Id != response.Id)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add($"Publisher with name {response.Name} already exists");
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                Publisher publisher = response.MapToEntity();

                await _itemRepository.UpdateAsync(publisher);

                return new ServiceResultModel<Publisher>
                {
                    Data = publisher
                };
            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public override async Task<ServiceResultModel<Publisher>> DeleteAsync(Guid id)
        {
            try
            {
                ServiceResultModel<Publisher> result = new();

                if(!await _itemRepository.DoesExistAsync(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add("Publisher does not exist");
                }

                if(await _gameRepository.DoesExistAsync(game => game.PublisherId == id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add("Please delete the games before deleting the publisher");
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _itemRepository.DeleteAsync(await _itemRepository.GetByIdAsync(id));

                return new ServiceResultModel<Publisher> { };
            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }
    }
}