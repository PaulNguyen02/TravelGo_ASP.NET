namespace dulich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToDatVe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DatVes", "NguoiDungId", "dbo.NguoiDungs");
            DropForeignKey("dbo.DatVes", "TuyenDuongId", "dbo.TuyenDuongs");
            DropIndex("dbo.DatVes", new[] { "TuyenDuongId" });
            DropIndex("dbo.DatVes", new[] { "NguoiDungId" });
            AddColumn("dbo.DatVes", "SoDienThoai", c => c.String());
            AddColumn("dbo.DatVes", "Email", c => c.String());
            AddColumn("dbo.DatVes", "SoNguoi", c => c.Int(nullable: false));
            DropColumn("dbo.DatVes", "ThongTinLienHe");
            DropColumn("dbo.DatVes", "TuyenDuongId");
            DropColumn("dbo.DatVes", "NguoiDungId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DatVes", "NguoiDungId", c => c.Int(nullable: false));
            AddColumn("dbo.DatVes", "TuyenDuongId", c => c.Int(nullable: false));
            AddColumn("dbo.DatVes", "ThongTinLienHe", c => c.String());
            DropColumn("dbo.DatVes", "SoNguoi");
            DropColumn("dbo.DatVes", "Email");
            DropColumn("dbo.DatVes", "SoDienThoai");
            CreateIndex("dbo.DatVes", "NguoiDungId");
            CreateIndex("dbo.DatVes", "TuyenDuongId");
            AddForeignKey("dbo.DatVes", "TuyenDuongId", "dbo.TuyenDuongs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DatVes", "NguoiDungId", "dbo.NguoiDungs", "Id", cascadeDelete: true);
        }
    }
}
