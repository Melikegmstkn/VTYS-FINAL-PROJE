namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwrerfe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tedOdemes", "tarih", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tedOdemes", "tarih", c => c.Int(nullable: false));
        }
    }
}
