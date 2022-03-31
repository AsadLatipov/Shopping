using AutoMapper;
using Shopping.Domain.Entities.Customers;
using Shopping.Domain.Entities.Orders;
using Shopping.Domain.Entities.Products;
using Shopping.Service.ViewModels.Customers;
using Shopping.Service.ViewModels.Orders;
using Shopping.Service.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerCreateViewModel>().ReverseMap();
            CreateMap<Order, OrderCreateViewModel>().ReverseMap();
            CreateMap<Product, ProductCreateViewModel>().ReverseMap();
            CreateMap<Customer, CustomerCreateViewModel>().ReverseMap();

        }

    }
}
