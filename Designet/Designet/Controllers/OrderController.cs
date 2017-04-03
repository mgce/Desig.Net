using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Designet.Models;
using Designet.Repositories;

namespace Designet.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderRepository orderRepository;

        public OrderController()
        {
            orderRepository = new OrderRepository();
        }

        // GET: api/Order
        public IEnumerable<Order> Get()
        {
            return orderRepository.Get();
        }


        // POST: api/Order
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
