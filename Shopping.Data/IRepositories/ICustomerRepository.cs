using Shopping.Domain.Entities.Customers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity);
        Task<bool> Delete(Expression<Func<Customer, bool>> expression);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null);
    }
}
