using AutoMapper;
using Customerr.Microservice.Context;
using Customerr.Microservice.CustomerDtos;
using Customerr.Microservice.Interface;
using Customerr.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerr.Microservice.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Customer AddCustomer(AddCustomerDto model)
        {
            var customer = _mapper.Map<Customer>(model);
            _context.Customers.Add(customer);
            Savechanges();

            return customer;
            
        }

        public Customer DeleteCustomer(int Id)
        {
            var findUser = _context.Customers.FirstOrDefault(x => x.Id == Id);
            if (findUser == null)
            {
                throw new ArgumentNullException(nameof(findUser));
            }

            var cust = new Customer
            {
                FirstName = findUser.FirstName,
                LastName = findUser.LastName,
                Email =  findUser.Email,
                DeltedDate = DateTime.Now, 
                ModifiedDate = findUser.ModifiedDate,
                CreatedDate = findUser.CreatedDate
            };

            _context.Customers.Update(cust);
            Savechanges();

            return cust;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int Id)
        {
            var findUser = _context.Customers.FirstOrDefault(x => x.Id == Id);
            if (findUser == null)
            {
                throw new ArgumentNullException(nameof(findUser));
            }

            return findUser;
        }

        public Customer UpdateCustomer(int Id, UpdateCustomerDto model)
        {
            var findUser = _context.Customers.FirstOrDefault(x => x.Id == Id);
            if (findUser == null)
            {
                throw new ArgumentNullException(nameof(findUser));
            }

            var updatedRecords = new Customer
            {
                FirstName = model.FirstName ?? findUser.FirstName,
                LastName = model.LastName ?? findUser.LastName,
                Email = model.Email ?? findUser.Email,
                CreatedDate = findUser.CreatedDate,
                ModifiedDate = model.ModifiedDate,
                DeltedDate = findUser.DeltedDate
            };

            var result = _context.Customers.Update(updatedRecords);
            Savechanges();

            return updatedRecords;
        }


        public bool Savechanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
