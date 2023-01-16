using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        private static List<string> GetResult(Exception ex)
        {
            List<string> error = new()
            {
                 ex.Message
            };

            if(ex.InnerException != null)
            {
                error.Add(ex.InnerException.Message);
            }

            return error;
        }
    }
}