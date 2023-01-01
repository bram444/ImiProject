using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;

namespace Imi.Project.Api.Core.Services
{
    public abstract class BaseGameMTMService<IR, MTM, TM>: IBaseGameMTMService<MTM, TM>
        where MTM : BaseGameMTM
        where TM : BaseGameMTMModel
        where IR : IBaseGameMTMRepository<MTM>
    {
        protected IR _irespository;

        public BaseGameMTMService(IR ir)
        {
            _irespository = ir;
        }

        public async Task<ServiceResultModel<IEnumerable<MTM>>> GetByGameIdAsync(Guid id)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<MTM>>
                {
                    Data = await _irespository.GetByGameIdAsync(id)
                };
            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public abstract Task<ServiceResultModel<MTM>> AddAsync(TM TModel);

        public abstract Task<ServiceResultModel<MTM>> DeleteAsync(TM TModel);

        public ServiceResultModel<MTM> SetError(Exception ex)
        {
            return new ServiceResultModel<MTM>
            {
                IsSuccess = false,
                ValidationErrors = GetResult(ex)
            };
        }

        public ServiceResultModel<IEnumerable<MTM>> SetErrorList(Exception ex)
        {
            return new ServiceResultModel<IEnumerable<MTM>>
            {
                IsSuccess = false,
                ValidationErrors = GetResult(ex)
            };
        }

        private static IList<ValidationResult> GetResult(Exception ex)
        {
            List<ValidationResult> error = new()
            {
                new ValidationResult(ex.Message)
            };

            if(ex.InnerException != null)
            {
                error.Add(new ValidationResult(ex.InnerException.Message));
            }

            return error;
        }
    }
}