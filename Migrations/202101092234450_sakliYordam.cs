namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sakliYordam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Satists", "tarih", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Satists", "tarih", c => c.String());
        }
    }
}
