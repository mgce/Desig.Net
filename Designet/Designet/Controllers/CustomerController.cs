using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Helpers;
using System.Web.Http;

using Designet.Dtos;
using Designet.Models;
using Designet.NHibernate;
using Designet.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace Designet.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            var customers = customerRepository.GetAllCustomers();         
            return customers;
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public IHttpActionResult Post(CustomerDto dto)
        {
            var customer = new Customer { Name = dto.Name };
            customerRepository.Add(customer);
            return Ok(customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, CustomerDto dto)
        {         
            var editedCustomer = customerRepository.GetById(id);
            editedCustomer.Name = dto.Name;
            customerRepository.Update(editedCustomer);         
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {                    
            var customer = customerRepository.GetById(id);
            customerRepository.Remove(customer);         
        }
    }
}
