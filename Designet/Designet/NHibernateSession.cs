﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;


namespace Designet
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var customerConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mapping\Customer.hbm.xml");
            configuration.AddFile(customerConfigurationFile);
            var orderConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mapping\Order.hbm.xml");
            configuration.AddFile(orderConfigurationFile);
            var noteConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mapping\Note.hbm.xml");
            configuration.AddFile(noteConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}