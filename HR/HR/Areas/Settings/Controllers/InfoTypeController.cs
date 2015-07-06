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

        public ActionResult EditInfoType(Guid id)
        {
            if (id == Guid.Empty)
            {
                ViewBag.Title = "New Info Type";
                return View(new InfoType() { Active = true });
            } 
            else
            {
                InfoType infoType = null;
                using (var session = sessionFactory.OpenSession())
                {
                    infoType = session.Get<InfoType>(id);
                }    
                 
                if (infoType == null)
                {
                   return new HttpNotFoundResult(string.Format("InfoType with id = {0} was not found in database", id));
                }

                ViewBag.Title = infoType.Name;
                return View(infoType);
            }
        }

        public ActionResult SaveInfoType(InfoType infoType)
        {
            if (ModelState.IsValid)
            {
                using (var session = sessionFactory.OpenSession())
                {
                    session.BeginTransaction();
                    session.SaveOrUpdate(infoType);
                    session.Transaction.Commit();
                }
                return Redirect("Index");
            }
            else
            {
                return View("EditinfoType", infoType);
            }
            
        }

        public JsonResult ValidateInfoTypeName(string name, Guid id)
        {
            bool exists = false;
            using (var session = sessionFactory.OpenSession())
            {
                exists = session.Query<InfoType>().Any(_ => _.Name.Like(name) && _.Id != id);
            }

            if (!exists)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("This name is already taken.", JsonRequestBehavior.AllowGet);
            }

            
        }
    }
}