using Mecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class ServislerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: HizmetlerUrunler
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServisEkle(Service s)
        {
            db.Servicies.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ServisSil(int? id)
        {
            Service s = db.Servicies.Find(id);
            db.Servicies.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ServisDuzenle(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var s = db.Servicies.Find(id);
            if(s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ServisDuzenle([Bind(Include = "id,name,price")] Service s)
        {
            if(ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        [ChildActionOnly]
        public ActionResult GetAllService()
        {
            return PartialView("~/Views/Servisler/_GetAllServicePartial.cshtml");
        }

        public JsonResult GetAllServiceJson()
        {
            var serviceList = db.Servicies.ToList();
            return Json(serviceList, JsonRequestBehavior.AllowGet);
        }

    }
}