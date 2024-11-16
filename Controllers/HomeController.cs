using dulich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dulich.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var chuyenDuLichList = db.ChuyenDuLiches.ToList();
            return View(chuyenDuLichList);
        }

        public ActionResult Chuyendulich(int id)
        {
            // Giả sử bạn đã lấy dữ liệu từ database và tạo đối tượng ChuyenDuLich
            var chuyenDuLich = db.ChuyenDuLiches.Find(id);

            // Tạo ViewModel và gán giá trị từ đối tượng ChuyenDuLich
            var viewModel = new ChuyenDuLichDatVeViewModel
            {
                ChuyenDuLich = chuyenDuLich,
                DatVe = new DatVe() // hoặc gán giá trị từ database nếu có
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostContact(ChuyenDuLichDatVeViewModel model)
        {
            // Log thông tin của ChuyenDuLich
            System.Diagnostics.Debug.WriteLine("TenChuyen: " + model.ChuyenDuLich.TenChuyen);

            // Log thông tin của DatVe
            System.Diagnostics.Debug.WriteLine("HoTen: " + model.DatVe.Ten);
            System.Diagnostics.Debug.WriteLine("SoDienThoai: " + model.DatVe.SoDienThoai);
            System.Diagnostics.Debug.WriteLine("Email: " + model.DatVe.Email);
            System.Diagnostics.Debug.WriteLine("SoNguoi: " + model.DatVe.SoNguoi);
            System.Diagnostics.Debug.WriteLine("NgayDat: " + model.DatVe.NgayDat);

            if (ModelState.IsValid)
            {
                // Lưu thông tin đặt vé vào database
                db.DatVes.Add(model.DatVe);
                db.SaveChanges();

                // Chuyển hướng đến trang chủ
                return RedirectToAction("Index");
            }
            else
            {
                // Log các lỗi trong ModelState
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        System.Diagnostics.Debug.WriteLine("ModelState Error: " + error.ErrorMessage);
                        if (error.Exception != null)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception: " + error.Exception.Message);
                        }
                    }
                }
            }

            // Nếu model không hợp lệ, trả lại view với model hiện tại
            return View("Chuyendulich", model);
        }
    }
}