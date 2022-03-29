using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Products;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService) =>
            this.productService = productService;

        [HttpPost]
        public async ValueTask<ActionResult<BaseResponse<Product>>> CreateAsync(ProductCreateViewModel product)
        {
            var entity = await productService.CreateAsync(product);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet("{productId}")]
        public async ValueTask<ActionResult<BaseResponse<Product>>> GetAsync(Guid productId)
        {
            var entity = await productService.GetAsync(obj => obj.Id == productId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet]
        public async ValueTask<ActionResult<BaseResponse<IEnumerable<Product>>>> GetAllAsync()
        {
            var entities = await productService.GetAllAsync();

            return StatusCode(entities.Code ?? entities.Error.Code.Value, entities);
        }

        [HttpPut]
        public async ValueTask<ActionResult<BaseResponse<Product>>> UpdateAsync(Product product)
        {
            var entity = await productService.UpdateAsync(product);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpDelete("{productId}")]
        public async ValueTask<ActionResult<BaseResponse<bool>>> CreateAsync(Guid productId)
        {
            var entity = await productService.DeleteAsync(obj => obj.Id == productId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

    }
}
