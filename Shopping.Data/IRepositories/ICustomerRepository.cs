using Shopping.Domain.Entities.Customers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
