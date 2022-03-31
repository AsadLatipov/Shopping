using AutoMapper;
using Shopping.Data.IRepositories;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
       

        public async Task<BaseResponse<Customer>> UpdateAsync(Customer customer)
        {
            BaseResponse<Customer> baseResponse = new BaseResponse<Customer>();

            var entity = await unitOfWork.Customers.GetAsync(obj => obj.Id == customer.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            var temp = await unitOfWork.Customers.UpdateAsync(customer);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = temp;
            return baseResponse;
        }

        public async Task<BaseResponse<Customer>> CreateAsync(CustomerCreateViewModel customer)
        {
            BaseResponse<Customer> baseResponse = new BaseResponse<Customer>();
            var entity = await unitOfWork.Customers.GetAsync(obj => obj.Phone == customer.Phone);

            if (entity != null)
            {
                baseResponse.Error = new ErrorModel(400, "Customer is exsist");
                return baseResponse;
            }

            var customerMap = mapper.Map<Customer>(customer);

            var result = await unitOfWork.Customers.CreateAsync(customerMap);
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;

            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Customer, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Customers.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not Found");
                return baseResponse;
            }

            entity.State = Domain.Enums.ItemState.deleted;
            await unitOfWork.Customers.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = true;

            return baseResponse;
        }

        public async Task<BaseResponse<Customer>> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            BaseResponse<Customer> baseResponse = new BaseResponse<Customer>();

            var entity = await unitOfWork.Customers.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<Customer>>> GetAllAsync(Expression<Func<Customer, bool>> expression = null)
        {
            BaseResponse<IEnumerable<Customer>> baseResponse = new BaseResponse<IEnumerable<Customer>>();
            var entities = await unitOfWork.Customers.GetAllAsync(expression);
            baseResponse.Data = entities;
            return baseResponse;

        }
    }
}
