using Mecom.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Mecom.Controllers
{
    public class CalisanlarController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Calisanlar

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalisanEkle(Staff s)
        {
            db.Staffs.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CalisanSil(int? id)
        {
            Staff s = db.Staffs.Find(id);
            db.Staffs.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CalisanDuzenle(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var s = db.Staffs.Find(id);
            if(s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalisanDuzenle([Bind(Include = "id,Name,lastName,phone,email,profession,salary")] Staff s)
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
        public ActionResult GetAllStaff()
        {
            return PartialView("~/Views/Calisanlar/_GetAllStaff.cshtml");
        }

        public JsonResult GetAllStaffJson()
        {
            var staffList = db.Staffs.ToList();
            return Json(staffList, JsonRequestBehavior.AllowGet);
        }
    }
}