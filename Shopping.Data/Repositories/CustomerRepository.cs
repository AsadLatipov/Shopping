using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using Shopping.Domain.Entities.Customers;
using Shopping.Domain.Entities.Products;

namespace Shopping.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MYDBContext mYDBContext) : base(mYDBContext)
        {
        }
    }
}
