using Customerr.Microservice.CustomerDtos;
using Customerr.Microservice.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerr.Microservice.Controllers
{
    [ApiController]
    [Route("api/[Controller]/")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customer;

        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }

        [HttpPost]
        [Route("addCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerDto customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            return Ok(_customer.AddCustomer(customer));
        }

        [HttpGet]
        [Route("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(_customer.GetAllCustomers());
        }

        [HttpGet]
        [Route("getCustomerById")]
        public async Task<IActionResult> GetCustomerById([FromQuery]int Id)
        {
            return Ok(_customer.GetCustomerById(Id));
        }

        [HttpPut]
        [Route("updateCustomer")]
        public ActionResult updateCustomer([FromQuery]int Id,[FromForm]UpdateCustomerDto customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var updateCust = _customer.UpdateCustomer(Id, customer);

            return Ok($"Details Updated Successfully on : {updateCust.ModifiedDate}");
        }

        [HttpDelete]
        [Route("removeCustomer")]
        public ActionResult removeCustomer([FromQuery]int Id)
        {
            var removeUserRecords = _customer.DeleteCustomer(Id);

            return Ok($"records deleted Succesfully on : {removeUserRecords.DeltedDate}");
        }
    }
}
