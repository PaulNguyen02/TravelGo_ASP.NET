using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class DatVeXeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatVeXe
        public ActionResult Index()
        {
            var datVeXes = db.DatVeXes.Include(d => d.Nhaxe).Include(d => d.TuyenDuong).ToList();
            return View(datVeXes);
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