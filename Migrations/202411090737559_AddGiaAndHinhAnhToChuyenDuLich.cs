namespace dulich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGiaAndHinhAnhToChuyenDuLich : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChuyenDuLiches", "Gia", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ChuyenDuLiches", "HinhAnh", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChuyenDuLiches", "HinhAnh");
            DropColumn("dbo.ChuyenDuLiches", "Gia");
        }
    }
}
