﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Designet.Models;
using Designet.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace Designet.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(customer);
                    transaction.Commit();
                }
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Customer>().ToList();
            }
        }

        public Customer GetById(int customerId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Customer>().First(x => x.Id == customerId);
            }
        }

        public void Remove(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(customer);
                    transaction.Commit(); ;
                }
            }
        }

        public void Update(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(customer);
                    transaction.Commit();
                }
            }
        }
    }
}