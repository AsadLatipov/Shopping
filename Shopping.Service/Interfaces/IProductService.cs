using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Products;
using Shopping.Service.ViewModels.Products;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<Product>> UpdateAsync(Product customer);
        Task<BaseResponse<Product>> CreateAsync(ProductCreateViewModel customer);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression);
        Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression);
        Task<BaseResponse<IQueryable<Product>>> GetAllAsync(Expression<Func<Product, bool>> expression = null);
    }
}
