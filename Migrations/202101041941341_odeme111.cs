namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odeme111 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tedOdemes",
                c => new
                    {
                        odemeID = c.Int(nullable: false, identity: true),
                        odemeMiktar = c.Int(nullable: false),
                        tarih = c.Int(nullable: false),
                        tedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.odemeID)
                .ForeignKey("dbo.Tedarikcis", t => t.tedID, cascadeDelete: true)
                .Index(t => t.tedID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tedOdemes", "tedID", "dbo.Tedarikcis");
            DropIndex("dbo.tedOdemes", new[] { "tedID" });
            DropTable("dbo.tedOdemes");
        }
    }
}
