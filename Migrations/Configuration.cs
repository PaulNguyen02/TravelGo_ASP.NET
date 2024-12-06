namespace dulich.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using dulich.Models;
  
    internal sealed class Configuration : DbMigrationsConfiguration<dulich.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(dulich.Models.ApplicationDbContext context)
        {
            if (!context.TuyenDuongs.Any())
            {
                context.TuyenDuongs.AddRange(new List<TuyenDuong> {
                    new TuyenDuong { Loai = "A", CongTyId=1, DiemBatDau="TPHCM", DiemKetThuc="HaNoi", ThoiGianKhoiHanh=DateTime.Now, ThoiGianDen = DateTime.Parse("2024-12-5"), Gia = 1800000 },                   
                });

                context.SaveChanges();
            }
            if (!context.Maybays.Any())
            {
                context.Maybays.AddRange(new List<Maybay> {
                    new Maybay { Tenhang = "VietNamAirLine", SoDienThoai= "1900 1800", Email= "onlinesupport@vietnamairlines.com" },
                    new Maybay { Tenhang = "VietJetAir", SoDienThoai = "1900 1886", Email = "19001886@vietjetair.com" },
                    new Maybay { Tenhang = "JetStar Pacific", SoDienThoai = "19001550", Email = "Jetstarairlines.online@gmail.com" },
                    new Maybay { Tenhang = "Bamboo Airway", SoDienThoai = "008419001166", Email = "19001166@bambooairways.com" }
                });

                context.SaveChanges();
            }
            if (!context.Taus.Any())
            {
                context.Taus.AddRange(new List<Tau> {
                    new Tau { Tenhang = "Đường sắt Việt Nam", SoDienThoai= "19006469", Email= "dsvn@vr.com.vn" },                    
                });

                context.SaveChanges();
            }
            if (!context.Nhaxes.Any())
            {
                context.Nhaxes.AddRange(new List<Nhaxe> {
                    new Nhaxe { TenNhaXe = "Thành Bưởi", SoDienThoai= "1900 1733", Email= "tb@thanhbuoi.com" },
                    new Nhaxe { TenNhaXe = "Phương Trang", SoDienThoai = "1950 1556", Email = "pt@phuongtrang.com" },
                    new Nhaxe { TenNhaXe = "Thiên Phú", SoDienThoai = "190075681", Email = "tp@thienphu.com" },
                   
                });

                context.SaveChanges();
            }
            if (!context.NguoiDungs.Any())
            {
                
                context.NguoiDungs.AddRange(new List<NguoiDung> {
                    new NguoiDung { TenDangNhap = "Phuc", MatKhau = EncryptPass.HashPassword("12345"), Email= "phucray@gmail.com", HoTen="Nguyen Thien Phuc", SoDienThoai="092833652", NgayTao=DateTime.Now ,Role="CTV"},
                    new NguoiDung { TenDangNhap = "Khai", MatKhau = EncryptPass.HashPassword("12345"), Email = "bkhaimess@gmail.com", HoTen="Le Ba Khai", SoDienThoai="092833612", NgayTao=DateTime.Now, Role="User"}                 
                });

                context.SaveChanges();
            }
            if (!context.Admins.Any())
            {

                context.Admins.AddRange(new List<Admin> {
                    new Admin { TenDangNhap = "Phuc", MatKhau = EncryptPass.HashPassword("12345"), NgayTao=DateTime.Now},
                   
                });

                context.SaveChanges();
            }
            if (!context.DiaDiemDuLiches.Any())
            {

                context.DiaDiemDuLiches.AddRange(new List<DiaDiemDuLich> {
                    new DiaDiemDuLich {Ten="Tràng An", MoTa="Được ví như Vịnh Hạ Long trên Cạn", ViTri="Ninh Bình", UrlHinhAnh="https://ik.imagekit.io/tvlk/blog/2024/07/du-lich-trang-an-1.jpg?tr=dpr-2,w-675"},
                    new DiaDiemDuLich {Ten="Vịnh Hạ Long", MoTa="Một trong 7 kỳ quan thiên nhiên thế giới", ViTri="Quảng Ninh", UrlHinhAnh="https://i2.ex-cdn.com/crystalbay.com/files/content/2024/10/15/vinh-ha-long-ve-dep-cua-ky-quan-da-3-lan-duoc-vinh-danh-la-di-san-the-gioi-1114.jpg"},
                    new DiaDiemDuLich {Ten="Động Phong Nha", MoTa="Kỳ Quan Thiên Nhiên đá vôi", ViTri="Quảng Bình", UrlHinhAnh="https://www.vietnambooking.com/wp-content/uploads/2022/10/dong-phong-nha-o-quang-binh-11.jpg"},
                    new DiaDiemDuLich {Ten="Cố đô Huế", MoTa="Thành của các vị vua Triều Nguyễn", ViTri="Huế", UrlHinhAnh="https://lh7-us.googleusercontent.com/uuZXIssTAzsFr7Oz0uicYufgIVS7kkOQ9RWGrOW4D9rRzJtYqIpcw0eAffxpFK6aYgbBi-td3oznZH6L_qi07j_VsP_NQgb_ZrBARitaJBhITslpxMI5JemZ1UJcV2vTUE5NZDoNY6w-fp6aUM7vc8A"},
                    new DiaDiemDuLich {Ten="Phố Cổ Hội An", MoTa="Phố cổ Hội An", ViTri="Hội An", UrlHinhAnh="https://www.homepaylater.vn/static/d4f2c13637c198d9e593a3590e1b111b/22553/1_thanh_pho_hoi_an_duoc_unesco_cong_nhan_la_di_san_van_hoa_the_gioi_noi_tieng_voi_nhung_ngoi_nha_co_kinh_62c7183de4.jpg"},
                });

                context.SaveChanges();
            }
            if (!context.ChuyenDuLiches.Any())
            {

                context.ChuyenDuLiches.AddRange(new List<ChuyenDuLich> {
                    new ChuyenDuLich {TenChuyen="Thăng Long", NgayKhoiHanh=DateTime.Parse("2024-12-11"), NgayKetThuc=DateTime.Parse("2024-12-18"), DiaDiemDuLichId=1 ,Gia=5000000, HinhAnh="https://ik.imagekit.io/tvlk/blog/2024/07/du-lich-trang-an-1.jpg?tr=dpr-2,w-675"},
                    new ChuyenDuLich {TenChuyen="Hạ Long", NgayKhoiHanh=DateTime.Parse("2024-12-11"), NgayKetThuc=DateTime.Parse("2024-12-18"), DiaDiemDuLichId=2 ,Gia=8000000, HinhAnh="https://i2.ex-cdn.com/crystalbay.com/files/content/2024/10/15/vinh-ha-long-ve-dep-cua-ky-quan-da-3-lan-duoc-vinh-danh-la-di-san-the-gioi-1114.jpg"},
                    new ChuyenDuLich {TenChuyen="Đá Kỳ Diệu", NgayKhoiHanh=DateTime.Parse("2024-12-11"), NgayKetThuc=DateTime.Parse("2024-12-18"), DiaDiemDuLichId=3 ,Gia=5000000, HinhAnh="https://www.vietnambooking.com/wp-content/uploads/2022/10/dong-phong-nha-o-quang-binh-11.jpg"},
                    new ChuyenDuLich {TenChuyen="Huyền Bí", NgayKhoiHanh=DateTime.Parse("2024-12-11"), NgayKetThuc=DateTime.Parse("2024-12-18"), DiaDiemDuLichId=4 ,Gia=3000000, HinhAnh="https://lh7-us.googleusercontent.com/uuZXIssTAzsFr7Oz0uicYufgIVS7kkOQ9RWGrOW4D9rRzJtYqIpcw0eAffxpFK6aYgbBi-td3oznZH6L_qi07j_VsP_NQgb_ZrBARitaJBhITslpxMI5JemZ1UJcV2vTUE5NZDoNY6w-fp6aUM7vc8A"},
                    new ChuyenDuLich {TenChuyen="Cổ Kính", NgayKhoiHanh=DateTime.Parse("2024-12-11"), NgayKetThuc=DateTime.Parse("2024-12-18"), DiaDiemDuLichId=5 ,Gia=25000000, HinhAnh="https://www.homepaylater.vn/static/d4f2c13637c198d9e593a3590e1b111b/22553/1_thanh_pho_hoi_an_duoc_unesco_cong_nhan_la_di_san_van_hoa_the_gioi_noi_tieng_voi_nhung_ngoi_nha_co_kinh_62c7183de4.jpg"},
                });

                context.SaveChanges();
            }

        }
    }
}
