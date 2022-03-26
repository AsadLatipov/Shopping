using Shopping.Domain.Entities.Orders;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order entity);
        Task<Order> UpdateAsync(Order entity);
        Task<bool> Delete(Expression<Func<Order, bool>> expression);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
        Task<IQueryable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null);
    }
}
