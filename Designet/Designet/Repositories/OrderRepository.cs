using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Designet.Models;
using Designet.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace Designet.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(order);
                    transaction.Commit();
                }
            }
        }

        public void Update(Order order)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(order);
                    transaction.Commit();
                }
            }
        }

        public void Remove(Order order)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(order);
                    transaction.Commit(); ;
                }
            }
        }

        public Order GetById(int orderId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Order>().First(x => x.Id == orderId);
            }
        }

        public IEnumerable<Order> GetOrdersByCustomer(int customerId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Order>().Where(x => x.CustomerId == customerId).ToList();
            }
        }
    }
}