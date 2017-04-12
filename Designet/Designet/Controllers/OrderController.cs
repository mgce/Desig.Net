using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Designet.Dtos;
using Designet.Models;
using Designet.Repositories;

namespace Designet.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;

        public OrderController()
        {
            orderRepository = new OrderRepository();
            customerRepository = new CustomerRepository();
        }

        // GET: api/Order
        public IEnumerable<Order> Get()
        {
            return orderRepository.Get();
        }

        public IEnumerable<Order> GetByCustomer(int id)
        {
            return orderRepository.GetByCustomer(id);
        }


        // POST: api/Order
        public void Post(OrderDto dto)
        {
            var customer = customerRepository.GetById(dto.CustomerId);

            var order = new Order
            {
                Description = dto.Description,
                Created = DateTime.UtcNow.Date,
                CustomerId = dto.CustomerId,
                Customer = customer,
                Deadline = DateTime.UtcNow.Date.AddDays(10)
            };
            customerRepository.Update(customer);
            orderRepository.Add(order);
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
