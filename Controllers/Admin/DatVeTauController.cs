using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using dulich.Models;

namespace dulich.Controllers
{
    public class DatVeTauController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatVeTau
        public ActionResult Index()
        {
            var datVeTaus = db.DatVeTaus.Include(d => d.Tau).Include(d => d.TuyenDuong).ToList();
            return View(datVeTaus);
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