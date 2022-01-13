using Customerr.Microservice.CustomerDtos;
using Customerr.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerr.Microservice.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer AddCustomer(AddCustomerDto model);
        Customer GetCustomerById(int Id);
        Customer UpdateCustomer(int Id, UpdateCustomerDto model);
        Customer DeleteCustomer(int Id);
    }
}
