using Mecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class SatislarController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Satislar
        public ActionResult Index()
        {
            ViewBag.billOfSaleId = new SelectList(db.BillOfSales, "id", "explanation");
            ViewBag.customerId = new SelectList(db.Customers, "id", "fullName");
            ViewBag.servicesId = new SelectList(db.Servicies, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SatisEkle(Asset a)
        {
            if(ModelState.IsValid)
            {
                var i = db.BillOfSales.Find(a.billOfSaleId);
                var s = db.Servicies.Find(a.servicesId);
                i.amount += s.price;
                db.Entry(i).State = System.Data.Entity.EntityState.Modified;
                db.Assets.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.billOfSaleId = new SelectList(db.BillOfSales, "id", "explanation");
            ViewBag.customerId = new SelectList(db.Customers, "id", "fullName");
            ViewBag.servicesId = new SelectList(db.Servicies, "id", "name", "price");
            return View(a);
        }

        public ActionResult SatisSil(int? id)
        {
            Asset a = db.Assets.Find(id);
            var i = db.BillOfSales.Find(a.billOfSaleId);
            var s = db.Servicies.Find(a.servicesId);
            i.amount -= s.price;
            db.Assets.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDuzenle(int? id)
        {
            ViewBag.customerId = new SelectList(db.Customers, "id", "fullName");
            ViewBag.servicesId = new SelectList(db.Servicies, "id", "name");
            if (id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var a = db.Assets.Find(id);
            if(a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SatisDuzenle([Bind(Include = "id,amount,customerId,servicesId,isPaid")] Asset a)
        {
            if(ModelState.IsValid)
            {
                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a);
        }

        [ChildActionOnly]
        public ActionResult GetAllAsset()
        {
            var a = db.Assets.ToList();
            return PartialView("~/Views/Satislar/_GetAllAssetPartial.cshtml", a);
        }

        public JsonResult GetAllAssetJson()
        {
            var assetList = db.Assets.ToList();
            return Json(assetList, JsonRequestBehavior.AllowGet);
        }
    }
}