using dulich.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using dulich.Models;
namespace dulich.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                ChuyenDuLichList = db.ChuyenDuLiches.ToList(),
                NhaxeList = db.Nhaxes.ToList(),
                MaybayList = db.Maybays.ToList(),
                TauList = db.Taus.ToList(),
                TuyenDuongList = db.TuyenDuongs.ToList(),
                chuyenDuLiches = db.ChuyenDuLiches.ToList()
            };

            return View(viewModel);
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
        public ActionResult PostContact(FormCollection fr)
        {
            string name = fr["name"];
            string phone = fr["phonenumber"];
            string email = fr["email"];
            int num = int.Parse(fr["num"]);
            DateTime start_date = DateTime.Parse(fr["start"]);
            DateTime end_date = DateTime.Parse(fr["return"]);
            int route = int.Parse(fr["route"]);
            decimal price = decimal.Parse(fr["price"]);
            var order_tour = new DatVe();
            order_tour.Ten = name;
            order_tour.SoDienThoai = phone;
            order_tour.Email = email;
            order_tour.SoNguoi = num;
            order_tour.NgayDat = start_date;
            order_tour.NgayVe = end_date;
            order_tour.TuyenDuongId = route;
            order_tour.TotalPrice = price;
            
            db.DatVes.Add(order_tour);
            db.SaveChanges();

                // Chuyển hướng đến trang chủ
            return RedirectToAction("Index"); 
        }
        public ActionResult DangNhapNgoaiClient()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhapNgoaiClient(string tenDangNhap, string matKhau)
        {
            var hashedPassword = EncryptPass.HashPassword(matKhau);
            // Kiểm tra thông tin người dùng
            var user = db.NguoiDungs
                .Where(u => u.TenDangNhap == tenDangNhap && u.MatKhau == hashedPassword)
                .FirstOrDefault();
           

            if (user != null)
            {
                // Kiểm tra nếu là cộng tác viên (CTV)
                if (user.Role == "CTV")
                {
                    // Lưu thông tin đăng nhập vào session hoặc cookie
                    Session["UserId"] = user.Id;
                    Session["UserRole"] = user.Role;
                    return RedirectToAction("SubmitLocation", "Home"); // Điều hướng đến trang chính
                }
                else if (user.Role == null || user.Role == "User")
                {
                    Session["UserId"] = user.Id;
                    Session["UserRole"] = user.Role;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Bạn không phải là cộng tác viên.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác.");
                return View();
            }
        }
       
        //public ActionResult PostContributeLocation()
        //{
        //    var model = new ContributedLocationViewModel();
        //    return View(model);
        //}

        // Xử lý khi CTV gửi thông tin đóng góp
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        
        //public ActionResult PostContributeLocation(ContributedLocationViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (Session["UserRole"] == null || Session["UserRole"].ToString() != "CTV")
        //        {
        //            return RedirectToAction("DangNhapNgoaiClient");
        //        }

        //        var contributedLocation = model.Location;
        //        contributedLocation.NgayDang = DateTime.Now;
        //        contributedLocation.TenCTV = Session["UserRole"].ToString();

        //        // Lưu ảnh
        //        if (Request.Files["HinhAnh"] != null && Request.Files["HinhAnh"].ContentLength > 0)
        //        {
        //            var file = Request.Files["HinhAnh"];
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
        //            file.SaveAs(path);
        //            contributedLocation.HinhAnh = fileName; // Lưu tên file trong cơ sở dữ liệu
        //        }

        //        // Lưu vào cơ sở dữ liệu
        //        db.CTVs.Add(contributedLocation);
        //        db.SaveChanges();

        //        return RedirectToAction("PostContributeLocation");
        //    }

        //    return View("Index", model);
        //}
        public ActionResult VeChungToi()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult SubmitLocation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLocation(LocationViewModel model, HttpPostedFileBase LocationImage)
        {
            if (ModelState.IsValid)
            {
                // Tạo đối tượng lưu thông tin địa điểm du lịch
                var location = new ContributedLocation
                {
                    CtvName = Session["UserRole"].ToString(),  // Tên CTV
                    DatePosted = DateTime.Now,     // Ngày đăng
                    LocationTitle = model.LocationTitle,
                    Description = model.Description,
                    LocationPosition = model.LocationPosition
                };

                // Xử lý hình ảnh (nếu có)
                if (LocationImage != null && LocationImage.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(LocationImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/assets/img/"), fileName);
                    LocationImage.SaveAs(path);
                    location.ImagePath = "/Content/assets/img/" + fileName;
                }

                // Lưu vào cơ sở dữ liệu (sử dụng Entity Framework hoặc ORM khác)
                db.CTVs.Add(location);
                db.SaveChanges();

                // Quay lại trang tin tức sau khi đăng bài
                return RedirectToAction("Tintuc");
            }

            // Trả về lỗi nếu form không hợp lệ
            return View(model);
        }

        public ActionResult Tintuc()
        {
            var locations = db.CTVs.OrderByDescending(l => l.DatePosted).ToList();
            return View(locations);
           
        }
        public ActionResult DetailsTinTuc(int id)
        {
            var location = db.CTVs.Find(id);
            if (location == null)
            {
                return HttpNotFound();  // Nếu không tìm thấy bài đăng, trả về lỗi 404
            }
            return View(location);  // Truyền đối tượng bài viết cho view
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatVe(ChuyenDuLichDatVeViewModel model)
        {
            if (model.DatVe == null)
            {
                return Json(new { success = false, message = "Dữ liệu đặt vé không hợp lệ." });
            }

            if (ModelState.IsValid)
            {
                var datVe = model.DatVe;

                // Kiểm tra các trường thông tin bắt buộc
                if (datVe.NgayDat == null || datVe.Ten == null || datVe.SoDienThoai == null || datVe.SoNguoi <= 0)
                {
                    return Json(new { success = false, message = "Vui lòng nhập đầy đủ thông tin." });
                }

                // Kiểm tra Ngày Đi (NgayDat)
                DateTime departureDate;
                DateTime? returnDate = null;

                if (!DateTime.TryParse(datVe.NgayDat.ToString(), out departureDate))
                {
                    return Json(new { success = false, message = "Ngày đi không hợp lệ." });
                }

                // Kiểm tra Ngày Về (NgayVe) nếu có
                if (datVe.NgayVe != null)
                {
                    DateTime validReturnDate;
                    if (!DateTime.TryParse(datVe.NgayVe.ToString(), out validReturnDate))
                    {
                        return Json(new { success = false, message = "Ngày về không hợp lệ." });
                    }
                    else
                    {
                        returnDate = validReturnDate;  // Gán giá trị hợp lệ cho returnDate
                    }
                }

                // Tính tổng giá tiền từ số ngày
                int totalPrice = 0;
                if (returnDate.HasValue)
                {
                    var days = (returnDate.Value - departureDate).Days;
                    totalPrice = days * 200000; // Giá mỗi ngày là 200.000 VND
                }
                else
                {
                    totalPrice = 200000; // Nếu chỉ có một chiều, tổng giá là 200.000 VND
                }

                // Lưu thông tin đặt vé vào cơ sở dữ liệu
                var newBooking = new DatVe()
                {
                    Ten = datVe.Ten,
                    SoDienThoai = datVe.SoDienThoai,
                    Email = datVe.Email,
                    SoNguoi = datVe.SoNguoi,
                    NgayDat = datVe.NgayDat,
                    NgayVe = datVe.NgayVe,
                    TuyenDuongId = datVe.TuyenDuongId,
                    TotalPrice = totalPrice // Lưu tổng tiền
                };

                db.DatVes.Add(newBooking);
                db.SaveChanges();

                // Trả về kết quả cho frontend
                return Json(new { success = true, message = "Đặt vé thành công!", TotalPrice = totalPrice });
            }

            // Nếu model không hợp lệ, trả về thông báo lỗi
            return Json(new { success = false, message = "Thông tin không hợp lệ." });
        }




        public ActionResult DatVeThanhCong(int bookingId)
        {
            var booking = db.DatVes.Find(bookingId);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking); // Hiển thị thông tin đặt vé thành công
        }
        public ActionResult Lienhe()
        {
            return View();
        }

        public ActionResult Tourtrongnuoc()
        {
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

        [HttpPost]
        public ActionResult Order()
        {
            string jsonString = new StreamReader(Request.InputStream).ReadToEnd();           
            OrderVehicle model = JsonConvert.DeserializeObject<OrderVehicle>(jsonString);                    
            var tuyenDuong = db.TuyenDuongs.FirstOrDefault(t => t.Id == model.TuyenDuongDi);
            if (tuyenDuong == null)
            {
                // Nếu không tìm thấy tuyến đường, trả về lỗi hoặc thông báo cho người dùng
                return Json(new { success = false, message = "Tuyến đường không hợp lệ." });
            }
            else
            {
                if (model.Loai == "Xe") {
                    DatVeXe datxe = new DatVeXe
                    {
                        NgayDat = model.NgayDat,
                        Ten = model.Ten,
                        SoDienThoai = model.SoDienThoai,
                        Email = model.Email,
                        SoNguoi = model.SoNguoi,
                        NhaxeId = model.BrandID,
                        TuyenDuongId = model.TuyenDuongDi
                    };
                    db.DatVeXes.Add(datxe);
                    db.SaveChanges();
                }
                if (model.Loai == "Máy bay")
                {
                    DatVeMayBay datmaybay = new DatVeMayBay
                    {
                        NgayDat = model.NgayDat,
                        Ten = model.Ten,
                        SoDienThoai = model.SoDienThoai,
                        Email = model.Email,
                        SoNguoi = model.SoNguoi,
                        MaybayId = model.BrandID,
                        TuyenDuongId = model.TuyenDuongDi
                    };
                    db.DatVeMayBays.Add(datmaybay);
                    db.SaveChanges();
                }
                if (model.Loai == "Tàu")
                {
                    DatVeTau tau = new DatVeTau
                    {
                        NgayDat = model.NgayDat,
                        Ten = model.Ten,
                        SoDienThoai = model.SoDienThoai,
                        Email = model.Email,
                        SoNguoi = model.SoNguoi,
                        TauId = model.BrandID,
                        TuyenDuongId = model.TuyenDuongDi
                    };
                    db.DatVeTaus.Add(tau);
                    db.SaveChanges();
                }                             
                return Json(new { success = true, message = "Đặt vé thành công." });
            }            
        }

        public ActionResult Search() {
            string location = Request.QueryString["query"];
            var trip = db.DiaDiemDuLiches
            .Where(d => d.Ten == location).ToList();
            return View(trip);
        }
    }
}