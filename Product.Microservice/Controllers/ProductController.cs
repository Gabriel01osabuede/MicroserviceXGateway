using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Dtos;
using Product.Microservice.Interfaces;
using Product.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        //Route("createProduct")]
        public ActionResult <GetProducts> CreateProduct([FromForm]AddProduct addProduct)
        {
            if (addProduct == null)
            {
                throw new ArgumentNullException(nameof(addProduct));
            }

            var product = _mapper.Map<Products>(addProduct);
            
            var products = _productService.AddProduct(product);
            var result = _mapper.Map<GetProducts>(product);
            return Ok($"Product Created Successfully, { result}");
            //return CreatedAtRoute(nameof(GetProductById), new { Id = result.Id }, result);
        }

        [HttpGet]
        //[Route("getAllProducts")]
        public ActionResult<IEnumerable<GetProducts>> GetAllProducts()
        {

            var products = _productService.GetAllProduct();
            var result = _mapper.Map<IEnumerable<GetProducts>>(products);

            return Ok(result);
        }

        [HttpPut]
        //[Route("updateProduct")]
        public ActionResult <GetProducts> updateProduct(int Id,updateProduct model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var product = _mapper.Map<Products>(model);

            var updateProduct = _productService.UpdateProduct(Id, product);
            var result = _mapper.Map<GetProducts>(updateProduct);

            return Ok($"Product Updated Succeffully at : {result.ModifiedDate}");

        }

        [HttpDelete("{Id}")]
        //[Route("deleteProduct")]
        public ActionResult <GetProducts>  DeleteProduct(int Id)
        {
            var deleteProduct = _productService.DeleteProduct(Id);

            var result = _mapper.Map<GetProducts>(deleteProduct);

            return Ok($"Product deleted Successfully at : {result.DeletedAt}");
        }

        //[HttpGet("{Id}", Name = "GetProductById")]
        [HttpGet("{Id}")]
        //[Route("{Id}")]
        public ActionResult <GetProducts> GetProductById(int Id)
        { 
            var product = _productService.GetProductById(Id);
            var result = _mapper.Map<GetProducts>(product);

            return Ok(result);
        }

    }
}
