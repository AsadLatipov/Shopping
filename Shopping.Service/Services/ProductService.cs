using AutoMapper;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<BaseResponse<Product>> UpdateAsync(Product product)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            var entity = await unitOfWork.Products.GetAsync(obj => obj.Id == product.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Product not found");
                return baseResponse;
            }

            var temp = await unitOfWork.Products.UpdateAsync(product);
            baseResponse.Data = temp;
            await unitOfWork.SaveChangesAsync();
            return baseResponse;
        }

        public async Task<BaseResponse<Product>> CreateAsync(ProductCreateViewModel product)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            // Check for exist Storage
            var entity = await unitOfWork.Storage.GetAsync(obj => obj.Product.Name == product.Name);
            if (entity is not null && entity.State != Domain.Enums.ItemState.deleted)
            {
                entity.TotalCount += product.Count;
                await unitOfWork.Storage.UpdateAsync(entity);

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
            var productMap = mapper.Map<Product>(product);

            var temp = await unitOfWork.Products.CreateAsync(productMap);
            await unitOfWork.SaveChangesAsync();

            //Add to storage table
            await unitOfWork.Storage.CreateAsync(new Storage
            {
                ProductId = temp.Id,
                TotalCount = product.Count
            });

            baseResponse.Data = temp;
            await unitOfWork.SaveChangesAsync();
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();

            var productMap = await unitOfWork.Products.GetAsync(expression);
            if (productMap is null)
            {
                baseResponse.Error = new ErrorModel(404, "Not found");
                return baseResponse;
            }

            await unitOfWork.Products.Delete(expression);
            baseResponse.Data = await unitOfWork.Storage.Delete(obj => obj.Id == productMap.Id);
            await unitOfWork.SaveChangesAsync();

            return baseResponse;

        }

        public async Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression)
        {
            BaseResponse<Product> baseResponse = new BaseResponse<Product>();

            var entity = await unitOfWork.Products.GetAsync(expression);
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
            var entities = await unitOfWork.Products.GetAllAsync(expression);
            baseResponse.Data = entities;
            return baseResponse;
        }
    }
}
