using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace dulich.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DiaDiemDuLich> DiaDiemDuLiches { get; set; }
        public DbSet<DichVuDuLich> DichVuDuLiches { get; set; }
        public DbSet<CongTyVanTai> CongTyVanTais { get; set; }
        public DbSet<CongTyDuLich> CongTyDuLiches { get; set; }
        public DbSet<TuyenDuong> TuyenDuongs { get; set; }
        public DbSet<DatVe> DatVes { get; set; }
        public DbSet<ChuyenDuLich> ChuyenDuLiches { get; set; }
    }

    public class Admin
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }

    public class NguoiDung
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }

    public class DiaDiemDuLich
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string ViTri { get; set; }
        public string UrlHinhAnh { get; set; }
    }

    public class DichVuDuLich
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int DiaDiemId { get; set; }
        public DiaDiemDuLich DiaDiemDuLich { get; set; }
    }

    public class CongTyVanTai
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string ThongTinLienHe { get; set; }
    }

    public class CongTyDuLich
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string ThongTinLienHe { get; set; }
    }

    public class TuyenDuong
    {
        public int Id { get; set; }
        public string Loai { get; set; }
        public int CongTyId { get; set; }
        public CongTyVanTai CongTyVanTai { get; set; }
        public string DiemBatDau { get; set; }
        public string DiemKetThuc { get; set; }
        public DateTime ThoiGianKhoiHanh { get; set; }
        public DateTime ThoiGianDen { get; set; }
        public decimal Gia { get; set; }
    }

    public class DatVe
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; } = DateTime.Now;
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoNguoi { get; set; }
    }

    public class ChuyenDuLich
    {
        public int Id { get; set; }

        [Required]
        public string TenChuyen { get; set; }

        [Required]
        public DateTime NgayKhoiHanh { get; set; }

        [Required]
        public DateTime NgayKetThuc { get; set; }

        [Required]
        public int DiaDiemDuLichId { get; set; }

        public virtual DiaDiemDuLich DiaDiemDuLich { get; set; }

        [Required]
        public int CongTyDuLichId { get; set; }

        public virtual CongTyDuLich CongTyDuLich { get; set; }

        [Required]
        public decimal Gia { get; set; }

        public string HinhAnh { get; set; }
    }
}