using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Designet.Models;
using NHibernate;
using NHibernate.Linq;

namespace Designet.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ISession session;

        public CustomerController()
        {
            session = WebApiApplication.SessionFactory.GetCurrentSession();
        }
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {           
            var customers = session.Query<Customer>().ToList();
            return customers;
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
