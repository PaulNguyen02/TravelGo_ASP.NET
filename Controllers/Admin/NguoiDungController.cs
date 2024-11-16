using System.Linq;
using System.Web.Mvc;
using dulich.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace dulich.Controllers.Admin
{
    public class NguoiDungController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/NguoiDung
        public ActionResult Index()
        {
            var users = db.NguoiDungs.ToList();
            return View(users);
        }

        // GET: Admin/NguoiDung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDung/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                user.MatKhau = HashPassword(user.MatKhau); // Hash the password before saving
                user.NgayTao = DateTime.Now; // Automatically set the creation date
                db.NguoiDungs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // GET: Admin/NguoiDung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            NguoiDung user = db.NguoiDungs.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/NguoiDung/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // POST: Admin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung user = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}