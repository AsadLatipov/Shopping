using Shopping.Data.IRepositories;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Customers;
using Shopping.Service.Interfaces;
using Shopping.Service.ViewModels.Customers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository) =>
            this.customerRepository = customerRepository;

        public async ValueTask<BaseResponse<Customer>> UpdateAsync(Customer customer)
        {
            BaseResponse<Customer> baseResponse = new BaseResponse<Customer>();

            var entity = await customerRepository.GetAsync(obj => obj.Id == customer.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            var temp = await customerRepository.UpdateAsync(customer);
            baseResponse.Data = temp;
            return baseResponse;
        }

        public async ValueTask<BaseResponse<Customer>> CreateAsync(CustomerCreateViewModel customer)
        {
            BaseResponse<Customer> baseResponse = new BaseResponse<Customer>();
            var entity = customerRepository.GetAsync(obj => obj.Phone == customer.Phone);

            if (entity == null)
            {
                baseResponse.Error = new ErrorModel(400, "Customer is exsist");
                return baseResponse;
            }

            var customerMap = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };

            baseResponse.Data = await customerRepository.CreateAsync(customerMap);
            return baseResponse;
        }
        
        public async ValueTask<BaseResponse<bool>> DeleteAsync(Expression<Func<Customer, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await customerRepository.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not Found");
                return baseResponse;
            }

            entity.State = Domain.Enums.ItemState.deleted;
            await customerRepository.UpdateAsync(entity);
            baseResponse.Data = true;

            return baseResponse;
        }
        
        public async ValueTask<BaseResponse<Customer>> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            BaseResponse<Customer> baseResponse = new BaseResponse<Customer>();

            var entity = await customerRepository.GetAsync(expression);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;

        }
        
        public async ValueTask<BaseResponse<IQueryable<Customer>>> GetAllAsync(Expression<Func<Customer, bool>> expression = null)
        {
            BaseResponse<IQueryable<Customer>> baseResponse = new BaseResponse<IQueryable<Customer>>();
            var entities = await customerRepository.GetAllAsync(expression);
            baseResponse.Data = entities;
            return baseResponse;

        }
    }
}
