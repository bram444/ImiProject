using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class BaseService<T, BR>: IBaseService<T> where T : BaseEntity
        where BR : IBaseRepository<T>
    {
        protected BR _itemRepository;

        public BaseService(BR itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public virtual async Task<ServiceResultModel<IEnumerable<T>>> ListAllAsync()
        {
            ServiceResultModel<IEnumerable<T>> result = new();
            try
            {
                result.Data = await _itemRepository.ListAllAsync();
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
 
        public virtual async Task<ServiceResultModel<T>> GetByIdAsync(Guid id)
        {
            ServiceResultModel<T> result = new();
            try
            {
                result.Data = await _itemRepository.GetByIdAsync(id);
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

        public virtual async Task<ServiceResultModel<IEnumerable<T>>> SearchAsync(string search)
        {
            ServiceResultModel<IEnumerable<T>> result = new();

            try
            {
                result.Data = await _itemRepository.GetFilteredListAsync(g => g.Name.Contains(search));
                return result;

            } catch(Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));

                return result;
            }
        }

        public virtual async Task<ServiceResultModel<T>> DeleteAsync(Guid id)
        {
            ServiceResultModel<T> result = new();

            try
            {
                if(!await _itemRepository.DoesExistAsync(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{typeof(T).Name} does not exist"));
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
