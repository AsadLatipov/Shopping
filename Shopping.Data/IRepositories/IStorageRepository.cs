using Shopping.Domain.Entities.Storages;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IStorageRepository : IGenericRepository<Storage>
    {
    }
}
