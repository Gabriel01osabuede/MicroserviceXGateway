using Product.Microservice.Dtos;
using Product.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Products> GetAllProduct();
        Products GetProductById(int Id);
        Products AddProduct(Products product);
        Products UpdateProduct(int Id, Products product);
        Products DeleteProduct(int Id);
    }
}
