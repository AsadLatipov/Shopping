using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using Shopping.Domain.Entities.Products;

namespace Shopping.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MYDBContext mYDBContext) : base(mYDBContext)
        {
        }
    }
}
