using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Mapping;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Publisher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class PublisherService:BaseService<Publisher,IPublisherRepository>, IPublisherService
    {
        private readonly IGameRepository _gameRepository;

        public PublisherService(IPublisherRepository publisherRespository, IGameRepository gameRepository):base(publisherRespository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<Publisher>>> SearchByCountryAsync(string country)
        {
            ServiceResultModel<IEnumerable<Publisher>> result = new();
            try
            {
                result.Data = await _itemRepository.GetFilteredListAsync(publisher=>publisher.Country.Contains(country));
                return result;

            } catch(Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }

        public async Task<ServiceResultModel<Publisher>> AddAsync(NewPublisherModel response)
        {
            ServiceResultModel<Publisher> result = new();

            try
            {
                if((await _itemRepository.DoesExistAsync(pub => pub.Name == response.Name)))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher with name {response.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                Publisher publisher= response.MapToEntity();

                await _itemRepository.AddAsync(publisher);

                result.Data = publisher;
                return result;
            } catch(Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }

        public async Task<ServiceResultModel<Publisher>> UpdateAsync(UpdatePublisherModel response)
        {
            ServiceResultModel<Publisher> result = new();

            try
            {
                if(!await _itemRepository.DoesExistAsync(response.Id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Publisher does not exist"));
                }

                if((await _itemRepository.DoesExistAsync(pub => pub.Name == response.Name && (pub.Id != response.Id))))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher with name {response.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                Publisher publisher = response.MapToEntity();

                await _itemRepository.UpdateAsync(publisher);

                result.Data = publisher;
                return result;
            } catch(Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }

        public override async Task<ServiceResultModel<Publisher>> DeleteAsync(Guid id)
        {
            ServiceResultModel<Publisher> result = new();

            try
            {
                if(!await _itemRepository.DoesExistAsync(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Publisher does not exist"));
                }

                if(await _gameRepository.DoesExistAsync(game=>game.PublisherId==id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Please delete the games before deleting the publisher"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _itemRepository.DeleteAsync(await _itemRepository.GetByIdAsync(id));
                return result;
            } catch(Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                if(ex.InnerException != null)
                {
                    result.ValidationErrors.Add(new ValidationResult(ex.InnerException.Message));
                }
                return result;
            }
        }
    }
}