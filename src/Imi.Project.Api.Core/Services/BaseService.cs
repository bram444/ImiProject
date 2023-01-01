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
    public abstract class BaseService<T, BR, NM, UM>: IBaseService<T, NM, UM> where T : BaseEntity
        where BR : IBaseRepository<T>
    {
        protected BR _itemRepository;

        public BaseService(BR itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ServiceResultModel<IEnumerable<T>>> ListAllAsync()
        {
            try
            {
                return new ServiceResultModel<IEnumerable<T>>
                {
                    Data = await _itemRepository.ListAllAsync()
                };
            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public async Task<ServiceResultModel<T>> GetByIdAsync(Guid id)
        {
            try
            {
                return new ServiceResultModel<T>
                {
                    Data = await _itemRepository.GetByIdAsync(id)
                };
            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public async Task<ServiceResultModel<IEnumerable<T>>> SearchAsync(string search)
        {
            try
            {
                return new ServiceResultModel<IEnumerable<T>>
                {
                    Data = await _itemRepository.GetFilteredListAsync(g => g.Name.Contains(search))
                };

            } catch(Exception ex)
            {
                return SetErrorList(ex);
            }
        }

        public abstract Task<ServiceResultModel<T>> AddAsync(NM response);
        public abstract Task<ServiceResultModel<T>> UpdateAsync(UM response);

        public virtual async Task<ServiceResultModel<T>> DeleteAsync(Guid id)
        {
            try
            {
                if(!await _itemRepository.DoesExistAsync(id))
                {
                    return new ServiceResultModel<T>
                    {
                        IsSuccess = false,
                        ValidationErrors = new List<ValidationResult>
                         {
                             new ValidationResult($"{nameof(T)} does not exist")
                         }
                    };
                }

                await _itemRepository.DeleteAsync(await _itemRepository.GetByIdAsync(id));

                return new ServiceResultModel<T> { };

            } catch(Exception ex)
            {
                return SetError(ex);
            }
        }

        public ServiceResultModel<T> SetError(Exception ex)
        {
            return new ServiceResultModel<T>
            {
                IsSuccess = false,
                ValidationErrors = GetResult(ex)
            };
        }

        public ServiceResultModel<IEnumerable<T>> SetErrorList(Exception ex)
        {
            return new ServiceResultModel<IEnumerable<T>>
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