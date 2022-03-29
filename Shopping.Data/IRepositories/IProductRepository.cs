using Shopping.Domain.Entities.Products;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        
    }
}
