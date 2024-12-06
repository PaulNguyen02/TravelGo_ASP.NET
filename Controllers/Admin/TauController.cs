using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class TauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tau
        public ActionResult Index()
        {
            return View(db.Taus.ToList());
        }

        // GET: Tau/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tau tau = db.Taus.Find(id);
            if (tau == null)
            {
                return HttpNotFound();
            }
            return View(tau);
        }

        // GET: Tau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tau/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tenhang,SoDienThoai,Email")] Tau tau)
        {
            if (ModelState.IsValid)
            {
                db.Taus.Add(tau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tau);
        }

        // GET: Tau/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tau tau = db.Taus.Find(id);
            if (tau == null)
            {
                return HttpNotFound();
            }
            return View(tau);
        }

        // POST: Tau/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tenhang,SoDienThoai,Email")] Tau tau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tau);
        }

        // GET: Tau/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tau tau = db.Taus.Find(id);
            if (tau == null)
            {
                return HttpNotFound();
            }
            return View(tau);
        }

        // POST: Tau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tau tau = db.Taus.Find(id);
            db.Taus.Remove(tau);
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