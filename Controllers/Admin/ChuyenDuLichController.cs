using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class ChuyenDuLichController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChuyenDuLich
        public ActionResult Index()
        {
            var chuyenDuLiches = db.ChuyenDuLiches.Include(c => c.DiaDiemDuLich);
            return View(chuyenDuLiches.ToList());
        }

        // GET: ChuyenDuLich/Create
        public ActionResult Create()
        {
            var diaDiemDuLichList = db.DiaDiemDuLiches.ToList();

            ViewBag.DiaDiemDuLich = diaDiemDuLichList;

            return View();
        }

        // POST: ChuyenDuLich/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenChuyen,NgayKhoiHanh,NgayKetThuc,DiaDiemDuLichId,CongTyDuLichId,Gia,HinhAnh")] ChuyenDuLich chuyenDuLich, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    // Generate a unique file name
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var uploadDir = Server.MapPath("~/Uploads");
                    var path = Path.Combine(uploadDir, fileName);

                    // Ensure the directory exists
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    // Save the file
                    HinhAnh.SaveAs(path);

                    // Set the file path to the model
                    chuyenDuLich.HinhAnh = "/Uploads/" + fileName;
                }

                // Save the model to the database
                db.ChuyenDuLiches.Add(chuyenDuLich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiaDiemDuLichId = new SelectList(db.DiaDiemDuLiches, "Id", "Ten", chuyenDuLich.DiaDiemDuLichId);
            return View(chuyenDuLich);
        }

        // GET: ChuyenDuLich/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenDuLich chuyenDuLich = db.ChuyenDuLiches.Find(id);
            if (chuyenDuLich == null)
            {
                return HttpNotFound();
            }
            var diaDiemDuLichList = db.DiaDiemDuLiches.ToList();

            ViewBag.DiaDiemDuLich = diaDiemDuLichList;
            return View(chuyenDuLich);
        }

        // POST: ChuyenDuLich/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenChuyen,NgayKhoiHanh,NgayKetThuc,DiaDiemDuLichId,CongTyDuLichId,Gia,HinhAnh")] ChuyenDuLich chuyenDuLich, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    // Generate a unique file name
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var uploadDir = Server.MapPath("~/Uploads");
                    var path = Path.Combine(uploadDir, fileName);

                    // Ensure the directory exists
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    // Save the file
                    HinhAnh.SaveAs(path);

                    // Set the file path to the model
                    chuyenDuLich.HinhAnh = "/Uploads/" + fileName;
                }

                db.Entry(chuyenDuLich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiaDiemDuLichId = new SelectList(db.DiaDiemDuLiches, "Id", "Ten", chuyenDuLich.DiaDiemDuLichId);
            return View(chuyenDuLich);
        }

        // GET: ChuyenDuLich/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenDuLich chuyenDuLich = db.ChuyenDuLiches.Find(id);
            if (chuyenDuLich == null)
            {
                return HttpNotFound();
            }
            return View(chuyenDuLich);
        }

        // POST: ChuyenDuLich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuyenDuLich chuyenDuLich = db.ChuyenDuLiches.Find(id);
            db.ChuyenDuLiches.Remove(chuyenDuLich);
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