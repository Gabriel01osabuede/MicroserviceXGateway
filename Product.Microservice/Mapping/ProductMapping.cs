using AutoMapper;
using Product.Microservice.Dtos;
using Product.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            //AcceptingFrom => SendingTo
            CreateMap<Products, GetProducts>();
            CreateMap<AddProduct, Products>();
            CreateMap<Products, AddProduct>();
        }
    }
}
