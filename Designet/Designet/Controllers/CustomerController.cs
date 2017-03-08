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
using NHibernate;
using NHibernate.Linq;

namespace Designet.Controllers
{
    public class CustomerController : ApiController
    {
        protected ISession CurrentSession { get; set; }

        public CustomerController()
        {
            SessionHelper sessionHelper = new SessionHelper();
            CurrentSession = sessionHelper.Current;
        }
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            var customers = CurrentSession.Query<Customer>().ToList();           
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
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                var customer = new Customer {Name = dto.Name};
                CurrentSession.Save(customer);
                transaction.Commit();
                return Ok(customer);
            }
            
        }

        // PUT: api/Customer/5
        public void Put(int id, CustomerDto dto)
        {
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                var editedCustomer = CurrentSession.Query<Customer>().First(x => x.Id == id);
                editedCustomer.Name = dto.Name;
                CurrentSession.Save(editedCustomer);
                transaction.Commit();
            }
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {           
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                var customer = CurrentSession.Query<Customer>().First((x => x.Id == id));
                CurrentSession.Delete(customer);
                transaction.Commit();
            }
        }
    }
}
