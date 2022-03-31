using AutoMapper;
using Shopping.Data.IRepositories;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Orders;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Orders;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper; 
        }



        public async Task<BaseResponse<Order>> UpdateAsync(Order order)
        {
            BaseResponse<Order> baseResponse = new BaseResponse<Order>();

            var entity = await unitOfWork.Orders.GetAsync(obj => obj.Id == order.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Order not found");
                return baseResponse;
            }

            var temp = await unitOfWork.Orders.UpdateAsync(order);
            baseResponse.Data = temp;
            await unitOfWork.SaveChangesAsync();
            return baseResponse;
        }

        public async Task<BaseResponse<Order>> CreateAsync(OrderCreateViewModel order)
        {
            BaseResponse<Order> baseResponse = new BaseResponse<Order>();

            try
            {
                var orderMap = mapper.Map<Order>(order);

                baseResponse.Data = await unitOfWork.Orders.CreateAsync(orderMap);
                await unitOfWork.SaveChangesAsync();
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.Error = new ErrorModel(404, ex.Message);
                return baseResponse;
            }
        }

        public async Task<BaseResponse<Order>> GetAsync(Expression<Func<Order, bool>> expression)
        {
            BaseResponse<Order> baseResponse = new BaseResponse<Order>();

            var entity = await unitOfWork.Orders.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Order not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Orders.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Order not Found");
                return baseResponse;
            }

            entity.State = Domain.Enums.ItemState.deleted;
            await unitOfWork.Orders.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = true;

            return baseResponse;
        }

        public async Task<BaseResponse<IQueryable<Order>>> GetAllAsync(Expression<Func<Order, bool>> expression = null)
        {
            BaseResponse<IQueryable<Order>> baseResponse = new BaseResponse<IQueryable<Order>>();
            var entities = await unitOfWork.Orders.GetAllAsync(expression);
            baseResponse.Data = entities;
            return baseResponse;
        }

    }
}
