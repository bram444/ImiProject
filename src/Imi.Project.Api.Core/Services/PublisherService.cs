using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public async Task<ServiceResultModel<Publisher>> AddAsync(PublisherModel response)
        {
            ServiceResultModel<Publisher> result = new()
            {
                IsSuccess = true
            };

            try
            {

                var allPublishers = await _publisherRespository.SearchAsync(response.Name);

                if(allPublishers.Any(publisher => (publisher.Name == response.Name) && (publisher.Id != response.Id)) && allPublishers.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher with name {response.Name} already exists"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _publisherRespository.AddAsync(new Publisher
                {
                    Id = response.Id,
                    Name = response.Name,
                    Country = response.Country,
                });

                result.Data = new Publisher { Id = response.Id, Country = response.Country, Name = response.Name };
                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
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

        public async Task<ServiceResultModel<Publisher>> DeleteAsync(Guid id)
        {
            ServiceResultModel<Publisher> result = new()
            {
                IsSuccess = true
            };

            try
            {
                if(await _publisherRespository.GetByIdAsync(id) == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Publisher does not exist"));
                }

                if(await _gameRepository.GetByPublisherIdAsync(id) != null && _gameRepository.GetByPublisherIdAsync(id).Result.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("Please delete the games before deleting the publisher"));
                }

                if(!result.IsSuccess)
                {
                    return result;
                }

                await _publisherRespository.DeleteAsync(await _publisherRespository.GetByIdAsync(id));
                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
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

        public async Task<ServiceResultModel<Publisher>> GetByIdAsync(Guid id)
        {
            ServiceResultModel<Publisher> result = new();
            try
            {
                Publisher publisher = await _publisherRespository.GetByIdAsync(id);
                result.IsSuccess = true;
                result.Data = publisher;
                return result;
            }
            catch (Exception ex)
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

        public async Task<ServiceResultModel<IEnumerable<Publisher>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<Publisher>> result = new();
            try
            {
                result.Data = await _publisherRespository.ListAllAsync();
                result.IsSuccess = true;
                return result;

            }
            catch (Exception ex)
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

        public async Task<ServiceResultModel<IEnumerable<Publisher>>> SearchAsync(string search)
        {
            ServiceResultModel<IEnumerable<Publisher>> result = new();
            try
            {
                result.Data = await _publisherRespository.SearchAsync(search);
                result.IsSuccess = true;
                return result;

            }
            catch (Exception ex)
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

        public async Task<ServiceResultModel<IEnumerable<Publisher>>> SearchByCountryAsync(string country)
        {
            ServiceResultModel<IEnumerable<Publisher>> result = new();
            try
            {
                result.Data = await _publisherRespository.SearchByCountryAsync(country);
                result.IsSuccess = true;
                return result;

            }
            catch (Exception ex)
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

        public async Task<ServiceResultModel<Publisher>> UpdateAsync(PublisherModel response)
        {
            ServiceResultModel<Publisher> result = new()
            {
                IsSuccess = true
            };

            try
            {
                if(await _publisherRespository.GetByIdAsync(response.Id) == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult("publisher does not exist"));
                }

                var allPublishers = await _publisherRespository.SearchAsync(response.Name);

                if(allPublishers.Any(publisher => (publisher.Name == response.Name) && (publisher.Id != response.Id)) && allPublishers.Any())
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Publisher with name {response.Name} already exists"));
                }
                if(!result.IsSuccess)
                {
                    return result;
                }

                await _publisherRespository.UpdateAsync(new Publisher
                {
                    Id = response.Id,
                    Name = response.Name,
                    Country = response.Country,
                });

                result.IsSuccess = true;
                result.Data = new Publisher
                {
                    Id = response.Id,
                    Name = response.Name,
                    Country = response.Country,
                };
                return result;
            }
            catch (Exception ex)
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