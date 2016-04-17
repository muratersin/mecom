using Mecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class GuncelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        int odenmemisFatura;
        int odenmisFatura;
        int gecikmisFatura;
        double topSat = 0;
        double topAl = 0;

        public ActionResult Index()
        {
            getStats();
            ViewBag.odenmemis = odenmemisFatura;
            ViewBag.gecikmis = gecikmisFatura;
            ViewBag.odenmis = odenmisFatura;

            ViewBag.topgel = topSat;
            ViewBag.topgid= topAl;
            ViewBag.satis = db.Assets.Count();
            ViewBag.alis = db.Payments.Count();
            ViewBag.calisan = db.Staffs.Count();
            ViewBag.musteri = db.Customers.Count();
            ViewBag.tedarikci = db.Suppliers.Count();
         
            return View();
        }

        public void getStats()
        {

            // Ödenmemiş gider faturaları
            var odenmemis = from p in db.PurchaseInvoices
                            where p.isPaid == false
                            select p;
            odenmemisFatura = odenmemis.Count();

            // Ödenmiş gider faturaları
            var odenmis = from o in db.PurchaseInvoices
                          where o.isPaid == true
                          select o;
            odenmisFatura = odenmis.Count();

            // Gecikmiş gider faturaları
            var gecikmis = from ge in db.PurchaseInvoices
                           where ge.lastPaymentDate.Month > DateTime.Now.Month || ge.lastPaymentDate.Day > DateTime.Now.Day
                           || ge.lastPaymentDate.Month == DateTime.Now.Month && ge.lastPaymentDate.Day > DateTime.Now.Day
                           select ge;
            gecikmisFatura = gecikmis.Count();

            // Toplam gelir
            if(db.Assets.FirstOrDefault() != null)
            {
                topSat = db.Assets.Sum(o => o.services.price);
            } 
                

            // Toplam gider
            foreach (var p in db.Payments)
            {
                topAl += p.amount;
            }
        }

        public ActionResult err()
        {
            return View();
        }

        public bool isLate(PurchaseInvoice p)
        {
            int mouth = p.lastPaymentDate.Month;
            int day = p.lastPaymentDate.Day;
            int year = p.lastPaymentDate.Year;

            bool result;
            if (mouth > DateTime.Now.Month || day > DateTime.Now.Day)
                result = false;
            else
                result = true;

            return result;
        }
    }
}