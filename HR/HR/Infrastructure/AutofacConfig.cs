using Autofac;
using Autofac.Integration.Mvc;
using HR.Areas.Settings.Controllers;
using HR.Controllers;
using HR.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Infrastructure
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<ImageController>().InstancePerRequest();
            builder.RegisterType<InfoTypeController>().InstancePerRequest();

            builder.RegisterType<HRRepository>().As<IHRRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}