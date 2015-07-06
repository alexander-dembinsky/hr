using HR.Models;
using NHibernate;
using NHibernate.Linq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Areas.Settings.Controllers
{
    public class InfoTypeController : Controller
    {
        readonly ISessionFactory sessionFactory;

        [Inject]
        public InfoTypeController(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public ActionResult Index()
        {
            List<InfoType> infoTypes = null;

            using (var session = sessionFactory.OpenSession())
            {
                infoTypes = (from infoType in session.Query<InfoType>() select infoType).ToList();
            }

            return View(infoTypes);
        }

        public ActionResult NewInfoType()
        {
            return View();
        }

        public ActionResult InfoTypeForm(InfoType infoType)
        {
            return PartialView(infoType);
        }
    }
}