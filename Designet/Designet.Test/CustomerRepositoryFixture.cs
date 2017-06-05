using System;
using Designet.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Designet.Repositories;

namespace Designet.Test
{
    [TestFixture]
    public class CustomerRepositoryFixture
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private readonly Customer[] _customers = new[]
        {
            new Customer() {Name = "Adam"},
            new Customer() {Name = "Michal"},
            new Customer() {Name = "Kuba"},
            new Customer() {Name = "Jacek"}
        };

        private void CreateInitialData()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var customer in _customers)
                        session.Save(customer);
                    transaction.Commit();
                }
            }
        }
#pragma warning disable 618
        [TestFixtureSetUp]
#pragma warning restore 618
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();            
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(true, false, false);
            CreateInitialData();
        }

        [Test]
        public void Can_add_customer()
        {
            var customer = new Customer {Name = "Adam"};
            ICustomerRepository repository = new CustomerRepository();
            repository.Add(customer);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Customer>(customer.Id);
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(customer, fromDb);
                Assert.AreEqual(customer.Name, fromDb.Name);
            }
        }       

        [Test]
        public void Can_update_existing_customer()
        {
            var customer = _customers[0];
            customer.Name = "Tomek";
            ICustomerRepository repository = new CustomerRepository();
            repository.Update(customer);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Customer>(customer.Id);
                Assert.AreEqual(customer.Name, fromDb.Name);
            }
        }

        [Test]
        public void Can_remove_exisitng_customer()
        {
            var customer = _customers[0];
            ICustomerRepository repository = new CustomerRepository();
            repository.Remove(customer);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Customer>(customer.Id);
                Assert.IsNull(fromDb);              
            }
        }
    }
}
