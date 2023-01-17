using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using Imi.Project.Api.Core.Models.Publisher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Sevices
{
    public interface IPublisherService: IBaseService<Publisher, NewPublisherModel, UpdatePublisherModel>
    {
        Task<ServiceResultModel<IEnumerable<Publisher>>> SearchByCountryAsync(string country);
    }
}