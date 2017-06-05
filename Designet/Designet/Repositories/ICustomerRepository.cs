using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designet.Models;

namespace Designet.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        Customer GetById(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
