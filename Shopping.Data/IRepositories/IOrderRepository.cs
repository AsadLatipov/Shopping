using Shopping.Domain.Entities.Orders;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
