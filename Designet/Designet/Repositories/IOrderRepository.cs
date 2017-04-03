using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designet.Models;

namespace Designet.Repositories
{
    public interface IOrderRepository
    {       
        void Add(Order order);
        void Update(Order order);
        void Remove(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> Get();
    }
}
