using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class DatVeMayBayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatVeMayBay
        public ActionResult Index()
        {
            var datVeMayBays = db.DatVeMayBays.Include(d => d.Maybay).Include(d => d.TuyenDuong).ToList();
            return View(datVeMayBays);
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