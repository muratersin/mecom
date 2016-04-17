using Mecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class MusterilerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Musteriler
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(int? id)
        {
            Customer c = db.Customers.Find(id);
            db.Customers.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriDuzenle(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var c = db.Customers.Find(id);
            if(c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MusteriDuzenle([Bind(Include = "id,name,lastName,email,phone,companyName")] Customer c)
        {
            if(ModelState.IsValid)
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
            
        }


        [ChildActionOnly]
        public ActionResult GetAllCustomer()
        {
            return PartialView("~/Views/Musteriler/_GetAllCustomer.cshtml");
        }

        public JsonResult GetAllCustomerJson()
        {
            var customerList = db.Customers.ToList();
            return Json(customerList, JsonRequestBehavior.AllowGet);
        }
    }
}