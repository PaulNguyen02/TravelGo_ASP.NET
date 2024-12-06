using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class MaybayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maybay
        public ActionResult Index()
        {
            return View(db.Maybays.ToList());
        }

        // GET: Maybay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maybay maybay = db.Maybays.Find(id);
            if (maybay == null)
            {
                return HttpNotFound();
            }
            return View(maybay);
        }

        // GET: Maybay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maybay/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tenhang,SoDienThoai,Email")] Maybay maybay)
        {
            if (ModelState.IsValid)
            {
                db.Maybays.Add(maybay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maybay);
        }

        // GET: Maybay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maybay maybay = db.Maybays.Find(id);
            if (maybay == null)
            {
                return HttpNotFound();
            }
            return View(maybay);
        }

        // POST: Maybay/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tenhang,SoDienThoai,Email")] Maybay maybay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maybay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maybay);
        }

        // GET: Maybay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maybay maybay = db.Maybays.Find(id);
            if (maybay == null)
            {
                return HttpNotFound();
            }
            return View(maybay);
        }

        // POST: Maybay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maybay maybay = db.Maybays.Find(id);
            db.Maybays.Remove(maybay);
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