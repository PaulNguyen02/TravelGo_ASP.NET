using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class DiaDiemDuLichController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DiaDiemDuLich
        public ActionResult Index()
        {
            var diaDiemDuLiches = db.DiaDiemDuLiches.ToList();
            return View(diaDiemDuLiches);
        }

        // GET: DiaDiemDuLich/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDiemDuLich diaDiemDuLich = db.DiaDiemDuLiches.Find(id);
            if (diaDiemDuLich == null)
            {
                return HttpNotFound();
            }
            return View(diaDiemDuLich);
        }

        // GET: DiaDiemDuLich/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiaDiemDuLich/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ten,MoTa,ViTri")] DiaDiemDuLich diaDiemDuLich, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(image.FileName);
                    var directoryPath = Server.MapPath("~/Images/");
                    var path = System.IO.Path.Combine(directoryPath, fileName);

                    // Ensure the directory exists
                    if (!System.IO.Directory.Exists(directoryPath))
                    {
                        System.IO.Directory.CreateDirectory(directoryPath);
                    }

                    image.SaveAs(path);
                    diaDiemDuLich.UrlHinhAnh = "/Images/" + fileName;
                }

                db.DiaDiemDuLiches.Add(diaDiemDuLich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diaDiemDuLich);
        }

        // GET: DiaDiemDuLich/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDiemDuLich diaDiemDuLich = db.DiaDiemDuLiches.Find(id);
            if (diaDiemDuLich == null)
            {
                return HttpNotFound();
            }
            return View(diaDiemDuLich);
        }

        // POST: DiaDiemDuLich/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ten,MoTa,ViTri,UrlHinhAnh")] DiaDiemDuLich diaDiemDuLich, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(image.FileName);
                    var directoryPath = Server.MapPath("~/Images/");
                    var path = System.IO.Path.Combine(directoryPath, fileName);

                    // Ensure the directory exists
                    if (!System.IO.Directory.Exists(directoryPath))
                    {
                        System.IO.Directory.CreateDirectory(directoryPath);
                    }

                    image.SaveAs(path);
                    diaDiemDuLich.UrlHinhAnh = "/Images/" + fileName;
                }

                db.Entry(diaDiemDuLich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diaDiemDuLich);
        }

        // GET: DiaDiemDuLich/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDiemDuLich diaDiemDuLich = db.DiaDiemDuLiches.Find(id);
            if (diaDiemDuLich == null)
            {
                return HttpNotFound();
            }
            return View(diaDiemDuLich);
        }

        // POST: DiaDiemDuLich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaDiemDuLich diaDiemDuLich = db.DiaDiemDuLiches.Find(id);
            db.DiaDiemDuLiches.Remove(diaDiemDuLich);
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