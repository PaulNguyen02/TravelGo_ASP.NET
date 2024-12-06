namespace dulich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                "dbo.ContributedLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CtvName = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        LocationTitle = c.String(),
                        Description = c.String(),
                        LocationPosition = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChuyenDuLiches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenChuyen = c.String(nullable: false),
                        NgayKhoiHanh = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(nullable: false),
                        DiaDiemDuLichId = c.Int(nullable: false),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiaDiemDuLiches", t => t.DiaDiemDuLichId, cascadeDelete: true)
                .Index(t => t.DiaDiemDuLichId);
            
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
                "dbo.DatVeMayBays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayDat = c.DateTime(nullable: false),
                        Ten = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        SoNguoi = c.Int(nullable: false),
                        MaybayId = c.Int(nullable: false),
                        TuyenDuongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maybays", t => t.MaybayId, cascadeDelete: true)
                .ForeignKey("dbo.TuyenDuongs", t => t.TuyenDuongId, cascadeDelete: true)
                .Index(t => t.MaybayId)
                .Index(t => t.TuyenDuongId);
            
            CreateTable(
                "dbo.Maybays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tenhang = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DatVes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayDat = c.DateTime(nullable: false),
                        Ten = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        SoNguoi = c.Int(nullable: false),
                        NgayVe = c.DateTime(),
                        TuyenDuongId = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TuyenDuongs", t => t.TuyenDuongId, cascadeDelete: true)
                .Index(t => t.TuyenDuongId);
            
            CreateTable(
                "dbo.DatVeTaus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayDat = c.DateTime(nullable: false),
                        Ten = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        SoNguoi = c.Int(nullable: false),
                        TauId = c.Int(nullable: false),
                        TuyenDuongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Taus", t => t.TauId, cascadeDelete: true)
                .ForeignKey("dbo.TuyenDuongs", t => t.TuyenDuongId, cascadeDelete: true)
                .Index(t => t.TauId)
                .Index(t => t.TuyenDuongId);
            
            CreateTable(
                "dbo.Taus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tenhang = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DatVeXes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayDat = c.DateTime(nullable: false),
                        Ten = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        SoNguoi = c.Int(nullable: false),
                        NhaxeId = c.Int(nullable: false),
                        TuyenDuongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nhaxes", t => t.NhaxeId, cascadeDelete: true)
                .ForeignKey("dbo.TuyenDuongs", t => t.TuyenDuongId, cascadeDelete: true)
                .Index(t => t.NhaxeId)
                .Index(t => t.TuyenDuongId);
            
            CreateTable(
                "dbo.Nhaxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenNhaXe = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
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
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DichVuDuLiches", "DiaDiemDuLich_Id", "dbo.DiaDiemDuLiches");
            DropForeignKey("dbo.DatVeXes", "TuyenDuongId", "dbo.TuyenDuongs");
            DropForeignKey("dbo.DatVeXes", "NhaxeId", "dbo.Nhaxes");
            DropForeignKey("dbo.DatVeTaus", "TuyenDuongId", "dbo.TuyenDuongs");
            DropForeignKey("dbo.DatVeTaus", "TauId", "dbo.Taus");
            DropForeignKey("dbo.DatVes", "TuyenDuongId", "dbo.TuyenDuongs");
            DropForeignKey("dbo.DatVeMayBays", "TuyenDuongId", "dbo.TuyenDuongs");
            DropForeignKey("dbo.DatVeMayBays", "MaybayId", "dbo.Maybays");
            DropForeignKey("dbo.ChuyenDuLiches", "DiaDiemDuLichId", "dbo.DiaDiemDuLiches");
            DropIndex("dbo.DichVuDuLiches", new[] { "DiaDiemDuLich_Id" });
            DropIndex("dbo.DatVeXes", new[] { "TuyenDuongId" });
            DropIndex("dbo.DatVeXes", new[] { "NhaxeId" });
            DropIndex("dbo.DatVeTaus", new[] { "TuyenDuongId" });
            DropIndex("dbo.DatVeTaus", new[] { "TauId" });
            DropIndex("dbo.DatVes", new[] { "TuyenDuongId" });
            DropIndex("dbo.DatVeMayBays", new[] { "TuyenDuongId" });
            DropIndex("dbo.DatVeMayBays", new[] { "MaybayId" });
            DropIndex("dbo.ChuyenDuLiches", new[] { "DiaDiemDuLichId" });
            DropTable("dbo.NguoiDungs");
            DropTable("dbo.DichVuDuLiches");
            DropTable("dbo.Nhaxes");
            DropTable("dbo.DatVeXes");
            DropTable("dbo.Taus");
            DropTable("dbo.DatVeTaus");
            DropTable("dbo.DatVes");
            DropTable("dbo.TuyenDuongs");
            DropTable("dbo.Maybays");
            DropTable("dbo.DatVeMayBays");
            DropTable("dbo.DiaDiemDuLiches");
            DropTable("dbo.ChuyenDuLiches");
            DropTable("dbo.ContributedLocations");
            DropTable("dbo.Admins");
        }
    }
}
