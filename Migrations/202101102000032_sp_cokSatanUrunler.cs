namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp_cokSatanUrunler : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure
           (
               "dbo.sp_cokSatanUrunler",
               t => new
               {
               },
               body:
               @"
                select sum(urunAdet) AS Adet,urunAdı
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
