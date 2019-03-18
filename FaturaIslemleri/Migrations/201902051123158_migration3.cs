namespace FaturaIslemleri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musteri",
                c => new
                    {
                        MusteriID = c.Int(nullable: false, identity: true),
                        MusteriUnvani = c.String(),
                        IlceID = c.Int(nullable: false),
                        MusteriAdersi = c.String(),
                    })
                .PrimaryKey(t => t.MusteriID)
                .ForeignKey("dbo.Ilce", t => t.IlceID, cascadeDelete: true)
                .Index(t => t.IlceID);
            
            CreateTable(
                "dbo.Urun",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(),
                        UrunKodu = c.Int(nullable: false),
                        BirimID = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Birim", t => t.BirimID, cascadeDelete: true)
                .Index(t => t.BirimID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urun", "BirimID", "dbo.Birim");
            DropForeignKey("dbo.Musteri", "IlceID", "dbo.Ilce");
            DropIndex("dbo.Urun", new[] { "BirimID" });
            DropIndex("dbo.Musteri", new[] { "IlceID" });
            DropTable("dbo.Urun");
            DropTable("dbo.Musteri");
        }
    }
}
