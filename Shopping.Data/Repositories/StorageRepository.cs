using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using Shopping.Domain.Entities.Storages;

namespace Shopping.Data.Repositories
{
    public class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(MYDBContext mYDBContext) : base(mYDBContext)
        {
        }
    }
}
