using System;
using Designet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Designet.Test
{
    [TestFixture]
    public class GenerateSchemaFixture
    {
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Customer).Assembly);

            new SchemaExport(cfg).Execute(true,false,false);
        }
    }
}
