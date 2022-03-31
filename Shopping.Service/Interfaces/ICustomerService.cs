using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Service.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseResponse<Customer>> UpdateAsync(Customer customer);
        Task<BaseResponse<Customer>> CreateAsync(CustomerCreateViewModel customer);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Customer, bool>> expression);
        Task<BaseResponse<Customer>> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<BaseResponse<IEnumerable<Customer>>> GetAllAsync(Expression<Func<Customer, bool>> expression = null);

    }
}
