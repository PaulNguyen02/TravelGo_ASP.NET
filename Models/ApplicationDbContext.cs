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
        public DbSet<Nhaxe> Nhaxes { get; set; }
        public DbSet<ContributedLocation> CTVs { get; set; }
        public DbSet<Maybay> Maybays { get; set; }
        public DbSet<Tau> Taus { get; set; }
        public DbSet<TuyenDuong> TuyenDuongs { get; set; }
        public DbSet<DatVe> DatVes { get; set; }
        public DbSet<DatVeXe> DatVeXes { get; set; }
        public DbSet<DatVeTau> DatVeTaus { get; set; }
        public DbSet<DatVeMayBay> DatVeMayBays { get; set; }

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

    // Thêm thuộc tính Role
    public string Role { get; set; } // Admin, CTV, User, v.v.
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

    public class Nhaxe
    {
        public int Id { get; set; }
        public string TenNhaXe { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }

    public class Maybay
    {
        public int Id { get; set; }
        public string Tenhang { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }

    public class Tau
    {
        public int Id { get; set; }
        public string Tenhang { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }

    public class TuyenDuong
    {
        public int Id { get; set; }
        public string Loai { get; set; }
        public int CongTyId { get; set; }
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
        public DateTime? NgayVe { get; set; } // Ngày về (nếu có)
        public int TuyenDuongId { get; set; }
        public virtual TuyenDuong TuyenDuong { get; set; }
        public decimal TotalPrice { get; set; } // Tổng tiền
    }

    public class DatVeXe
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; } = DateTime.Now;
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoNguoi { get; set; }
        public int NhaxeId { get; set; }
        public virtual Nhaxe Nhaxe { get; set; }
        public int TuyenDuongId { get; set; }
        public virtual TuyenDuong TuyenDuong { get; set; }
    }

    public class DatVeTau
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; } = DateTime.Now;
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoNguoi { get; set; }
        public int TauId { get; set; }
        public virtual Tau Tau { get; set; }
        public int TuyenDuongId { get; set; }
        public virtual TuyenDuong TuyenDuong { get; set; }
    }

    public class DatVeMayBay
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; } = DateTime.Now;
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoNguoi { get; set; }
        public int MaybayId { get; set; }
        public virtual Maybay Maybay { get; set; }
        public int TuyenDuongId { get; set; }
        public virtual TuyenDuong TuyenDuong { get; set; }
    }
    public class ContributedLocation
    {
        public int Id { get; set; }
        public string CtvName { get; set; }
        public DateTime DatePosted { get; set; }
        public string LocationTitle { get; set; }
        public string Description { get; set; }
        public string LocationPosition { get; set; }
        public string ImagePath { get; set; }
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
        public decimal Gia { get; set; }

        public string HinhAnh { get; set; }
    }
}