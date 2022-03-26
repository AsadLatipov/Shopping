using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Storages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Interfaces
{
    public interface IStorageService
    {
        Task<BaseResponse<IEnumerable<Storage>>> GetAllAsync(Expression<Func<Storage, bool>> expression = null);
    }
}
