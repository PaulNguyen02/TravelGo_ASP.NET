using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class CongTyDuLichController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CongTyDuLich
        public ActionResult Index()
        {
            return View(db.CongTyDuLiches.ToList());
        }

        // GET: CongTyDuLich/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTyDuLich congTyDuLich = db.CongTyDuLiches.Find(id);
            if (congTyDuLich == null)
            {
                return HttpNotFound();
            }
            return View(congTyDuLich);
        }

        // GET: CongTyDuLich/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongTyDuLich/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ten,ThongTinLienHe")] CongTyDuLich congTyDuLich)
        {
            if (ModelState.IsValid)
            {
                db.CongTyDuLiches.Add(congTyDuLich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congTyDuLich);
        }

        // GET: CongTyDuLich/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTyDuLich congTyDuLich = db.CongTyDuLiches.Find(id);
            if (congTyDuLich == null)
            {
                return HttpNotFound();
            }
            return View(congTyDuLich);
        }

        // POST: CongTyDuLich/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ten,ThongTinLienHe")] CongTyDuLich congTyDuLich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congTyDuLich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congTyDuLich);
        }

        // GET: CongTyDuLich/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongTyDuLich congTyDuLich = db.CongTyDuLiches.Find(id);
            if (congTyDuLich == null)
            {
                return HttpNotFound();
            }
            return View(congTyDuLich);
        }

        // POST: CongTyDuLich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CongTyDuLich congTyDuLich = db.CongTyDuLiches.Find(id);
            db.CongTyDuLiches.Remove(congTyDuLich);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}