using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using Shopping.Domain.Entities.Products;

namespace Shopping.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Product>, IProductRepository
    {
        public CustomerRepository(MYDBContext mYDBContext) : base(mYDBContext)
        {
        }
    }
}
