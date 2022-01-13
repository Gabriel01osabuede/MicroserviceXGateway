using AutoMapper;
using Customerr.Microservice.CustomerDtos;
using Customerr.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerr.Microservice.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerDto, Customer>();
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<DeleteCustomerDto, Customer>();
        }
    }
}
