using HR.Infrastructure.Repository;
using HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Areas.Settings.Controllers
{
    public class InfoTypeController : Controller
    {
        private IHRRepository repository;

        public InfoTypeController(IHRRepository repository)
        {
            this.repository = repository;
            ViewBag.Title = "Settings > Info Types";
        }

        public ActionResult Index()
        {
            List<InfoType> infoTypes = repository.GetAllInfoType.ToList();
            return View(infoTypes);
        }

        public ActionResult EditInfoType(Guid id)
        {
            ViewBag.InfoTypes = repository.GetAllInfoType.ToList();
            if (id == Guid.Empty)
            {
                return View(new InfoType() { Active = true });
            }
            else
            {
                InfoType infoType = repository.GetAllInfoType.Where(_ => _.Id == id).FirstOrDefault();
                if (infoType == null)
                {
                    return new HttpNotFoundResult(string.Format("InfoType with id = {0} was not found in database", id));
                }
                return View(infoType);
            }
        }

        [HttpPost]
        public ActionResult SaveInfoType(InfoType infoType)
        {
            if (ModelState.IsValid)
            {
                infoType.Id = Guid.NewGuid();
                repository.SaveInfoType(infoType);
                return Redirect("Index");
            }
            else
            {
                return View("EditinfoType", infoType);
            }
        }

        public JsonResult ValidateInfoTypeName(string name, Guid id)
        {
            bool exists = repository.GetAllInfoType.Any(_ => _.Name.Contains(name) && _.Id != id);
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