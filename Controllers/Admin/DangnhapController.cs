using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using dulich.Models;
using AdminUser = dulich.Models.Admin;

namespace dulich.Controllers
{
    public class DangnhapController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dangnhap
        public ActionResult Index()
        {
            return View();
        }

        // POST: Dangnhap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string password, bool rememberMe = false)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Username: {username}, Password: {password}");

                if (ModelState.IsValid)
                {
                    var user = AuthenticateUser(username, password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.TenDangNhap, rememberMe);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }

            return View();
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

        private AdminUser AuthenticateUser(string username, string password)
        {
            var admin = db.Admins.SingleOrDefault(u => u.TenDangNhap == username);
            if (admin != null && admin.MatKhau == HashPassword(password))
            {
                System.Diagnostics.Debug.WriteLine($"Username: {admin.TenDangNhap}, Password: {admin.MatKhau}");
                return admin;
            }
            return null;
        }

        // GET: Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Dangnhap");
        }
    }
}