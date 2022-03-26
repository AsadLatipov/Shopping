using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using Shopping.Domain.Entities.Orders;

namespace Shopping.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(MYDBContext mYDBContext) : base(mYDBContext)
        {
        }
    }
}
