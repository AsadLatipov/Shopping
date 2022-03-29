using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Orders;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService) =>
            this.orderService = orderService;

        [HttpPost]
        public async ValueTask<ActionResult<BaseResponse<Order>>> CreateAsync(OrderCreateViewModel order)
        {
            var entity = await orderService.CreateAsync(order);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet("{orderId}")]
        public async ValueTask<ActionResult<BaseResponse<Order>>> GetAsync(Guid orderId)
        {
            var entity = await orderService.GetAsync(obj =>obj.Id == orderId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpGet]
        public async ValueTask<ActionResult<BaseResponse<IEnumerable<Order>>>> GetAllAsync()
        {
            var entities = await orderService.GetAllAsync();

            return StatusCode(entities.Code ?? entities.Error.Code.Value, entities);
        }

        [HttpPut]
        public async ValueTask<ActionResult<BaseResponse<Order>>> UpdateAsync(Order order)
        {
            var entity = await orderService.UpdateAsync(order);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

        [HttpDelete("{productId}")]
        public async ValueTask<ActionResult<BaseResponse<bool>>> CreateAsync(Guid orderId)
        {
            var entity = await orderService.DeleteAsync(obj => obj.Id == orderId);

            return StatusCode(entity.Code ?? entity.Error.Code.Value, entity);
        }

    }
}
