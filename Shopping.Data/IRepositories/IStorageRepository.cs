using Shopping.Domain.Entities.Storages;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IStorageRepository
    {
        Task<Storage> CreateAsync(Storage entity);
        Task<Storage> UpdateAsync(Storage entity);
        Task<bool> Delete(Expression<Func<Storage, bool>> expression);
        Task<Storage> GetAsync(Expression<Func<Storage, bool>> expression);
        Task<IQueryable<Storage>> GetAllAsync(Expression<Func<Storage, bool>> expression = null);
    }
}
