using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using HR.Infrastructure;
using Ninject;
using NHibernate;

namespace HR
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(PrepareKernel()));
        }

        /// <summary>
        /// Dependency injection configuration.
        /// </summary>
        /// <returns>NInject kernel</returns>
        IKernel PrepareKernel()
        {
            IKernel kernel = new StandardKernel();

            // Common
            kernel.Bind<ISessionFactory>().ToMethod((_) => HibernateUtil.GetSessionFactory());
            
            // Main Screen
            kernel.Bind<HR.Controllers.HomeController>().ToSelf();

            // Settings
            kernel.Bind<HR.Areas.Settings.Controllers.HomeController>().ToSelf();

            return kernel;
        }
    }
}