using Shopping.Data.IRepositories;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Products;
using Shopping.Domain.Entities.Storages;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Products;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IStorageRepository storageRepository;

        public ProductService(
            IProductRepository productRepository,
            IStorageRepository storageRepository)
        {
            this.productRepository = productRepository;
            this.storageRepository = storageRepository;
        }

        public async Task<BaseResponse<Product>> UpdateAsync(Product customer)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            var entity = await productRepository.GetAsync(obj => obj.Id == customer.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Product not found");
                return baseResponse;
            }

            var temp = await productRepository.UpdateAsync(customer);
            baseResponse.Data = temp;
            return baseResponse;
        }
        public async Task<BaseResponse<Product>> CreateAsync(ProductCreateViewModel product)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            // Check for exist Storage
            var entity = await storageRepository.GetAsync(obj => obj.Product.Name == product.Name);
            if (entity is not null && entity.State != Domain.Enums.ItemState.deleted)
            {
                entity.TotalCount += product.Count;
                await storageRepository.UpdateAsync(entity);

                baseResponse.Data = new Product()
                {
                    Name = product.Name,
                    CompanyName = product.CompanyName,
                    Price = product.Price,
                    ExpiredDate = product.ExpiredDate,
                    AdoptedDate = product.AdoptedDate
                };

                return baseResponse;
            }

            //Add products table
            var productMap = new Product()
            {
                Name = product.Name,
                CompanyName = product.CompanyName,
                Price = product.Price,
                ExpiredDate = product.ExpiredDate,
                AdoptedDate = product.AdoptedDate,
            };
            var temp = await productRepository.CreateAsync(productMap);

            //Add to storage table
            await storageRepository.CreateAsync(new Storage
            {
                ProductId = temp.Id,
                TotalCount = product.Count
            });

            baseResponse.Data = temp;
            return baseResponse;
        }
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();

            var productMap = await productRepository.GetAsync(expression);
            if (productMap is null)
            {
                baseResponse.Error = new ErrorModel(404, "Not found");
                return baseResponse;
            }

            await productRepository.Delete(expression);
            baseResponse.Data = await storageRepository.Delete(obj => obj.Id == productMap.Id);

            return baseResponse;

        }
        public async Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            var entity = await productRepository.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Product not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }
        public async Task<BaseResponse<IQueryable<Product>>> GetAllAsync(Expression<Func<Product, bool>> expression = null)
        {
            BaseResponse<IQueryable<Product>> baseResponse = new BaseResponse<IQueryable<Product>>();
            var entities = await productRepository.GetAllAsync(expression);
            baseResponse.Data = entities;
            return baseResponse;
        }


    }
}
