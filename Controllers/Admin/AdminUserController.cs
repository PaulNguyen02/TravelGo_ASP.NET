using System.Linq;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers.Admin
{
    public class AdminUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminUser
        public ActionResult Index()
        {
            var adminUsers = db.Admins.ToList();
            return View(adminUsers);
        }
    }
}