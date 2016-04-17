using Mecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class TedarikcilerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Tedarikci
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TedarikciEkle(Supplier s)
        {
            db.Suppliers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TedarikciSil(int? id)
        {
            Supplier s = db.Suppliers.Find(id);
            db.Suppliers.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TedarikciDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var s = db.Suppliers.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TedarikciDuzenle([Bind(Include = "id,companyName,phone,email,adress")] Supplier s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        [ChildActionOnly]
        public ActionResult GetAllSupplier()
        {
            return PartialView("~/Views/Tedarikciler/_GetAllSupplierPartial.cshtml");
        }

        public JsonResult GetAllSupplierJson()
        {
            var supplierList = db.Suppliers.ToList();
            return Json(supplierList, JsonRequestBehavior.AllowGet);
        }
    }
}