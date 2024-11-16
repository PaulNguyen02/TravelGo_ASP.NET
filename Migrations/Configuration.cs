using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;
using System.Text;
using dulich.Models;

namespace dulich.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Hash the password
            string HashPassword(string password)
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(password);
                    var hash = sha256.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }
            }

            context.Admins.AddOrUpdate(
               a => a.TenDangNhap,
               new Admin
               {
                   TenDangNhap = "superadmin",
                   MatKhau = HashPassword("superadmin"),
                   NgayTao = DateTime.Now
               }
           );

            // Tạo dữ liệu người dùng
            context.NguoiDungs.AddOrUpdate(
                u => u.TenDangNhap,
                new NguoiDung
                {
                    TenDangNhap = "admin",
                    MatKhau = HashPassword("admin123"), // Lưu ý: Mật khẩu nên được mã hóa
                    Email = "admin@example.com",
                    HoTen = "Admin User",
                    SoDienThoai = "1234567890",
                    NgayTao = DateTime.Now
                },
                new NguoiDung
                {
                    TenDangNhap = "user1",
                    MatKhau = HashPassword("user123"), // Lưu ý: Mật khẩu nên được mã hóa
                    Email = "user1@example.com",
                    HoTen = "User One",
                    SoDienThoai = "0987654321",
                    NgayTao = DateTime.Now
                }
            );

            // Tạo dữ liệu địa điểm du lịch
            context.DiaDiemDuLiches.AddOrUpdate(
                d => d.Ten,
                new DiaDiemDuLich
                {
                    Ten = "Ha Long Bay",
                    MoTa = "A beautiful bay in Vietnam",
                    ViTri = "Quang Ninh",
                    UrlHinhAnh = "https://example.com/halong.jpg"
                },
                new DiaDiemDuLich
                {
                    Ten = "Phong Nha Cave",
                    MoTa = "A famous cave in Vietnam",
                    ViTri = "Quang Binh",
                    UrlHinhAnh = "https://example.com/phongnha.jpg"
                }
            );

            // Tạo dữ liệu công ty du lịch
            context.CongTyDuLiches.AddOrUpdate(
                c => c.Ten,
                new CongTyDuLich
                {
                    Ten = "Saigontourist",
                    ThongTinLienHe = "contact@saigontourist.com"
                },
                new CongTyDuLich
                {
                    Ten = "Vietravel",
                    ThongTinLienHe = "contact@vietravel.com"
                }
            );

            // Lưu thay đổi vào cơ sở dữ liệu
            context.SaveChanges();
        }
    }
}