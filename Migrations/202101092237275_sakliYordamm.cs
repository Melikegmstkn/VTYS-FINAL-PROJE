namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sakliYordamm : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure
           (
               "dbo.OrnekSP4",
               t => new
               {
                   tarih1 = t.DateTime(),
                   tarih2 = t.DateTime(),
               },
               body:
               @"
                Select * from Satists where tarih between @tarih1 and @tarih2
                "
            );
        }
        
        public override void Down()
        {
        }
    }
}
