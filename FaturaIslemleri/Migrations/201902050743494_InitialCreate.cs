namespace FaturaIslemleri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ilce",
                c => new
                    {
                        IlceId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                        IlID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IlceId)
                .ForeignKey("dbo.Il", t => t.IlID, cascadeDelete: true)
                .Index(t => t.IlID);
            
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.IlID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ilce", "IlID", "dbo.Il");
            DropIndex("dbo.Ilce", new[] { "IlID" });
            DropTable("dbo.Il");
            DropTable("dbo.Ilce");
        }
    }
}
