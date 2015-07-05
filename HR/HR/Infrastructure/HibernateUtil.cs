using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Infrastructure
{
    public class HibernateUtil
    {
        const string DatabaseName = "HRDatabase";
        static Lazy<ISessionFactory> sessionFactory = new Lazy<ISessionFactory>(InitSessionFactory);

        public static ISessionFactory GetSessionFactory()
        {
            return sessionFactory.Value;
        }

        static ISessionFactory InitSessionFactory() 
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ToString();

            ISessionFactory factory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<HibernateUtil>())
                .BuildSessionFactory();

            return factory;
        }

    }

}