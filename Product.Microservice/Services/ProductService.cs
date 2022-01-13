using Product.Microservice.Context;
using Product.Microservice.Dtos;
using Product.Microservice.Interfaces;
using Product.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Products AddProduct(Products product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Add(product);
            SaveChanges();

            return product;
        }

        public Products DeleteProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);
            var updateProduct = new Products
            {
                DeletedAt = product.DeletedAt
            };

            _context.Products.Update(updateProduct);
            SaveChanges();

            return updateProduct;
        }

        public IEnumerable<Products> GetAllProduct()
        {
            List<Products> availableProducts = new List<Products>(); 
            var products = _context.Products.ToList();
            foreach (var product in products)
            {
                if (product.DeletedAt == null)
                {
                    availableProducts.Add(product);
                }
            }
            return availableProducts;
        }

        public Products GetProductById(int Id)
        {
            var newProduct = new Products();
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);
            if (product.DeletedAt == null)
                newProduct = product;

            return newProduct;
            
        }

        public Products UpdateProduct(int Id, Products product)
        {
            var retriveProduct = _context.Products.FirstOrDefault(x => x.Id == Id);
            //var updateProduct = new Products
            //{
            //    Name = product.Name,
            //    Description = product.Description,
            //    ModifiedDate = product.ModifiedDate
            //};

            var result = _context.Products.Update(product);
            
            SaveChanges();

            return product;

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
