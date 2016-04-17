using Mecom.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class FaturalarController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //--------------------------Bill Of Sale---------------------------------------
        public ActionResult SatisFaturasi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SatisFaturasiEkle(BillOfSale b)
        {
            BillOfSale bos = new BillOfSale();
            bos.amount = 0;
            bos.creationDate = DateTime.Now;
            bos.explanation = b.explanation;
            bos.isPaid = b.isPaid;
            bos.userId = User.Identity.GetUserId();
                db.BillOfSales.Add(bos);
                db.SaveChanges();
                return RedirectToAction("SatisFaturasi");
        }

        public ActionResult SatisFaturasiSil(int? id)
        {
            var b = db.BillOfSales.Find(id);
            db.BillOfSales.Remove(b);
            db.SaveChanges();
            return RedirectToAction("SatisFaturasi");
        }

        public ActionResult SatisFaturasiDuzenle(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var b = db.BillOfSales.Find(id);
            if(b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  SatisFaturasiDuzenle([Bind(
            Include ="id,amount,explanation,isPaid")] BillOfSale b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SatisFaturasi");
            }
            return View(b);
        }

        [ChildActionOnly]
        public ActionResult GetAllBillOfSale()
        {
            var b = db.BillOfSales.ToList();
            return PartialView("~/Views/Faturalar/_GetAllBillOfSalePartial.cshtml", b);
        }

        //------------------------------PurchaseInvoice------------------------------------------
        public ActionResult AlimFaturasi()
        {
            ViewBag.supplierId = new SelectList(db.Suppliers, "id", "companyName");
            return View();
        }
        [HttpPost]
        public ActionResult AlimFaturasiEkle(PurchaseInvoice p)
        {
            p.amount = 0;
            p.creationDate = DateTime.Now;
            p.userId = User.Identity.GetUserId();
            db.PurchaseInvoices.Add(p);
            db.SaveChanges();
            return RedirectToAction("AlimFaturasi");
        }

        public ActionResult AlimFaturasiSil(int? id)
        {
            var p = db.PurchaseInvoices.Find(id);
            db.PurchaseInvoices.Remove(p);
            db.SaveChanges();
            return RedirectToAction("AlimFaturasi");
        }

        public ActionResult AlimFaturasiDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = db.PurchaseInvoices.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlimFaturasiDuzenle(PurchaseInvoice p)
        {
            var f = db.PurchaseInvoices.First(a => a.id == p.id);
            f.explanation = p.explanation;
            f.isPaid = p.isPaid;
            f.kind = p.kind;           
            db.SaveChanges();
                return RedirectToAction("AlimFaturasi");

        }

        [ChildActionOnly]
        public ActionResult GetAllPi()
        {
            var p = db.PurchaseInvoices.ToList();
            return PartialView("~/Views/Faturalar/_GetAllPiPartial.cshtml", p);
        }

    }
}