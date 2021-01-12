namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spUrnler : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure
           (
               "dbo.cokSatanlar",
               t => new
               {
               },
               body:
               @"
                select sum(urunAdet),urunAdı
                from SatisListesis
                group by urunAdı
                "
            );
        }
        
        public override void Down()
        {
        }
    }
}
