using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using dulich.Models;

namespace dulich.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: Admin
        public ActionResult Index()
        {
            var userCount = db.NguoiDungs.Count();
            ViewBag.UserCount = userCount;

            var diaDiemCount = db.DiaDiemDuLiches.Count();
            ViewBag.DiaDiemCount = diaDiemCount;

            var chuyenDuLichCount = db.ChuyenDuLiches.Count();
            ViewBag.ChuyenDuLichCount = chuyenDuLichCount;

            var tours = db.DiaDiemDuLiches.ToList();
            return View(tours);
        }

    }
}