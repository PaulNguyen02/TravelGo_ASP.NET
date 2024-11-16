using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class DatVeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatVe
        public ActionResult Index()
        {
            var datVes = db.DatVes.ToList();
            return View(datVes);
        }

        // GET: DatVe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // GET: DatVe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatVe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NgayDat,Ten,SoDienThoai,Email,SoNguoi")] DatVe datVe)
        {
            if (ModelState.IsValid)
            {
                db.DatVes.Add(datVe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datVe);
        }

        // GET: DatVe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // POST: DatVe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NgayDat,Ten,SoDienThoai,Email,SoNguoi")] DatVe datVe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datVe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datVe);
        }

        // GET: DatVe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // POST: DatVe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatVe datVe = db.DatVes.Find(id);
            db.DatVes.Remove(datVe);
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