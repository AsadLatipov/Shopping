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
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService) => 
            this.customerService = customerService;


        [HttpPost]
        public async ValueTask<ActionResult<BaseResponse<Customer>>> CreateAsync(CustomerCreateViewModel customer)
        {
            var entity = await customerService.CreateAsync(customer);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet("{customerId}")]
        public async ValueTask<ActionResult<BaseResponse<Customer>>> GetAsync(Guid customerId)
        {
            var entity = await customerService.GetAsync(obj => obj.Id == customerId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet]
        public async ValueTask<ActionResult<BaseResponse<IQueryable<Customer>>>> GetAllAsync()
        {
            var entity = await customerService.GetAllAsync();

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpPut]
        public async ValueTask<ActionResult<BaseResponse<Customer>>> UpdateAsync(Customer customer)
        {
            var entity = await customerService.UpdateAsync(customer);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpDelete("{customerId}")]
        public async ValueTask<ActionResult<BaseResponse<bool>>> DeleteAsync(Guid customerId)
        {
            var entity = await customerService.DeleteAsync(obj => obj.Id == customerId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

    }
}
