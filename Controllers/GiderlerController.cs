using Mecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class GiderlerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Giderler
        public ActionResult Index()
        {
            ViewBag.purchaseInvoiceId = new SelectList(db.PurchaseInvoices, "id", "explanation");
            return View();
        }

        public ActionResult GiderEkle(Payment p)
        {
            var pur = db.PurchaseInvoices.Find(p.purchaseInvoiceId);
            pur.amount += p.amount;
            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
            db.Payments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GiderDuzenle(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = db.Payments.Find(id);
            if(p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GiderDuzenle(Payment p)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult GiderSil(int? id)
        {
            Payment p = db.Payments.Find(id);
            db.Payments.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetAllPayment()
        {
            var p = db.Payments.ToList();
            return PartialView("~/Views/Giderler/_GetAllPaymentPartial.cshtml", p);
        }
    }
}