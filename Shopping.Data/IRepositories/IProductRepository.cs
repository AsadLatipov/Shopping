using Shopping.Domain.Entities.Products;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task<bool> Delete(Expression<Func<Product, bool>> expression);
        Task<Product> GetAsync(Expression<Func<Product, bool>> expression);
        Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null);
    }
}
