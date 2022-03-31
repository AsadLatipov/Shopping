using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Customers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class customersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public customersController(ICustomerService customerService) =>
            this.customerService = customerService;


        [HttpPost]
        public async Task<ActionResult<BaseResponse<Customer>>> CreateAsync(CustomerCreateViewModel customer)
        {
            var entity = await customerService.CreateAsync(customer);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet("{customer-id}")]
        public async Task<ActionResult<BaseResponse<Customer>>> GetAsync([FromRoute(Name = "customer-id")] Guid customerId)
        {
            var entity = await customerService.GetAsync(obj => obj.Id == customerId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IQueryable<Customer>>>> GetAllAsync()
        {
            var entity = await customerService.GetAllAsync();

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<Customer>>> UpdateAsync(Customer customer)
        {
            var entity = await customerService.UpdateAsync(customer);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpDelete("{customer-id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync([FromRoute(Name = "customer-id")] Guid customerId)
        {
            var entity = await customerService.DeleteAsync(obj => obj.Id == customerId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

    }
}
