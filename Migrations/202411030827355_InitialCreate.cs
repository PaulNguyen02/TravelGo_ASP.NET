namespace dulich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(),
                        MatKhau = c.String(),
                        NgayTao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CongTyDuLiches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        ThongTinLienHe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CongTyVanTais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        ThongTinLienHe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DatVes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        ThongTinLienHe = c.String(),
                        TuyenDuongId = c.Int(nullable: false),
                        NgayDat = c.DateTime(nullable: false),
                        NguoiDungId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDungs", t => t.NguoiDungId, cascadeDelete: true)
                .ForeignKey("dbo.TuyenDuongs", t => t.TuyenDuongId, cascadeDelete: true)
                .Index(t => t.TuyenDuongId)
                .Index(t => t.NguoiDungId);
            
            CreateTable(
                "dbo.NguoiDungs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(),
                        MatKhau = c.String(),
                        Email = c.String(),
                        HoTen = c.String(),
                        SoDienThoai = c.String(),
                        NgayTao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TuyenDuongs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Loai = c.String(),
                        CongTyId = c.Int(nullable: false),
                        DiemBatDau = c.String(),
                        DiemKetThuc = c.String(),
                        ThoiGianKhoiHanh = c.DateTime(nullable: false),
                        ThoiGianDen = c.DateTime(nullable: false),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CongTyVanTai_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CongTyVanTais", t => t.CongTyVanTai_Id)
                .Index(t => t.CongTyVanTai_Id);
            
            CreateTable(
                "dbo.DiaDiemDuLiches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        MoTa = c.String(),
                        ViTri = c.String(),
                        UrlHinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DichVuDuLiches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        MoTa = c.String(),
                        DiaDiemId = c.Int(nullable: false),
                        DiaDiemDuLich_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiaDiemDuLiches", t => t.DiaDiemDuLich_Id)
                .Index(t => t.DiaDiemDuLich_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DichVuDuLiches", "DiaDiemDuLich_Id", "dbo.DiaDiemDuLiches");
            DropForeignKey("dbo.DatVes", "TuyenDuongId", "dbo.TuyenDuongs");
            DropForeignKey("dbo.TuyenDuongs", "CongTyVanTai_Id", "dbo.CongTyVanTais");
            DropForeignKey("dbo.DatVes", "NguoiDungId", "dbo.NguoiDungs");
            DropIndex("dbo.DichVuDuLiches", new[] { "DiaDiemDuLich_Id" });
            DropIndex("dbo.TuyenDuongs", new[] { "CongTyVanTai_Id" });
            DropIndex("dbo.DatVes", new[] { "NguoiDungId" });
            DropIndex("dbo.DatVes", new[] { "TuyenDuongId" });
            DropTable("dbo.DichVuDuLiches");
            DropTable("dbo.DiaDiemDuLiches");
            DropTable("dbo.TuyenDuongs");
            DropTable("dbo.NguoiDungs");
            DropTable("dbo.DatVes");
            DropTable("dbo.CongTyVanTais");
            DropTable("dbo.CongTyDuLiches");
            DropTable("dbo.Admins");
        }
    }
}
