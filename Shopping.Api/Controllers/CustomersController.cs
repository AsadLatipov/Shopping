using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService) => 
            this.customerService = customerService;


        [HttpPost]
        public async ValueTask<ActionResult<BaseResponse<Customer>>> CreateAsync(CustomerCreateViewModel createViewModel)
        {
            var entity = await customerService.CreateAsync(createViewModel);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<BaseResponse<Customer>>> GetAsync(Guid id)
        {
            var entity = await customerService.GetAsync(obj => obj.Id == id);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpPost]
        public async ValueTask<ActionResult<BaseResponse<IQueryable<Customer>>>> GetAllAsync()
        {
            var entity = await customerService.GetAllAsync();

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpPost]
        public async ValueTask<ActionResult<BaseResponse<Customer>>> UpdateAsync(Customer customer)
        {
            var entity = await customerService.UpdateAsync(customer);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpPost("{id}")]
        public async ValueTask<ActionResult<BaseResponse<bool>>> DeleteAsync(Guid id)
        {
            var entity = await customerService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

    }
}
