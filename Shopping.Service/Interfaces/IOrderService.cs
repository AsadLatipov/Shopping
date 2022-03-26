using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Orders;
using Shopping.Service.ViewModels.Orders;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResponse<Order>> UpdateAsync(Order customer);
        Task<BaseResponse<Order>> CreateAsync(OrderCreateViewModel customer);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<BaseResponse<Order>> GetAsync(Expression<Func<Order, bool>> expression);
        Task<BaseResponse<IQueryable<Order>>> GetAllAsync(Expression<Func<Order, bool>> expression = null);
    }
}
