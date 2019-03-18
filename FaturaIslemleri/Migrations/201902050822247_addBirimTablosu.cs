namespace FaturaIslemleri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirimTablosu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Birim",
                c => new
                    {
                        BirimID = c.Int(nullable: false, identity: true),
                        BirimAdi = c.String(),
                        birim_BirimID = c.Int(),
                    })
                .PrimaryKey(t => t.BirimID)
                .ForeignKey("dbo.Birim", t => t.birim_BirimID)
                .Index(t => t.birim_BirimID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Birim", "birim_BirimID", "dbo.Birim");
            DropIndex("dbo.Birim", new[] { "birim_BirimID" });
            DropTable("dbo.Birim");
        }
    }
}
