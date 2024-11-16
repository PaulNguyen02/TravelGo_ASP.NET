namespace dulich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCongTyDuLichToChuyenDuLich : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChuyenDuLiches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenChuyen = c.String(nullable: false),
                        NgayKhoiHanh = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(nullable: false),
                        DiaDiemDuLichId = c.Int(nullable: false),
                        CongTyDuLichId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CongTyDuLiches", t => t.CongTyDuLichId, cascadeDelete: true)
                .ForeignKey("dbo.DiaDiemDuLiches", t => t.DiaDiemDuLichId, cascadeDelete: true)
                .Index(t => t.DiaDiemDuLichId)
                .Index(t => t.CongTyDuLichId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenDuLiches", "DiaDiemDuLichId", "dbo.DiaDiemDuLiches");
            DropForeignKey("dbo.ChuyenDuLiches", "CongTyDuLichId", "dbo.CongTyDuLiches");
            DropIndex("dbo.ChuyenDuLiches", new[] { "CongTyDuLichId" });
            DropIndex("dbo.ChuyenDuLiches", new[] { "DiaDiemDuLichId" });
            DropTable("dbo.ChuyenDuLiches");
        }
    }
}
