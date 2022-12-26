using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IPublisherService
    {
        Task<ServiceResultModel<IEnumerable<Publisher>>> ListAllAsync();
        Task<ServiceResultModel<Publisher>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<Publisher>>> SearchAsync(string search);
        Task<ServiceResultModel<IEnumerable<Publisher>>> SearchByCountryAsync(string country);
        Task<ServiceResultModel<Publisher>> AddAsync(PublisherModel response);
        Task<ServiceResultModel<Publisher>> UpdateAsync(PublisherModel response);
        Task<ServiceResultModel<Publisher>> DeleteAsync(Guid id);
    }
}