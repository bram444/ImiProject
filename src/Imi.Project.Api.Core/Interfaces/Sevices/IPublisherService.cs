using Imi.Project.Api.Core.Dto.Genre;
using Imi.Project.Api.Core.Dto.Publisher;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> SearchAsync(string search);
        Task<IEnumerable<Publisher>> SearchByCountryAsync(string country);

        IQueryable<Publisher> GetAll();
        Task<IEnumerable<Publisher>> ListAllAsync();
        Task< Publisher> GetByIdAsync(Guid id);
        Task<ServiceResult<Publisher>> UpdateAsync(PublisherResponseDto entity);
        Task<ServiceResult<Publisher>> AddAsync(PublisherResponseDto entity);
        Task<ServiceResult<Publisher>> DeleteAsync(PublisherResponseDto entity);
    }
}
