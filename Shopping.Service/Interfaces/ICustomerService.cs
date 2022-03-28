using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Service.ViewModels.Customers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Interfaces
{
    public interface ICustomerService
    {
        ValueTask<BaseResponse<Customer>> UpdateAsync(Customer customer);
        ValueTask<BaseResponse<Customer>> CreateAsync(CustomerCreateViewModel customer);
        ValueTask<BaseResponse<bool>> DeleteAsync(Expression<Func<Customer, bool>> expression);
        ValueTask<BaseResponse<Customer>> GetAsync(Expression<Func<Customer, bool>> expression);
        ValueTask<BaseResponse<IQueryable<Customer>>> GetAllAsync(Expression<Func<Customer, bool>> expression = null);

    }
}
