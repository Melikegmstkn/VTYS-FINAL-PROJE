namespace finalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ccc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gecicis",
                c => new
                    {
                        satisID = c.Int(nullable: false, identity: true),
                        barkodNo = c.Int(nullable: false),
                        urunAdı = c.String(),
                        satisFiyati = c.Int(nullable: false),
                        urunAdet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.satisID);
            
            CreateTable(
                "dbo.Kullanıcı",
                c => new
                    {
                        kID = c.Int(nullable: false, identity: true),
                        kADI = c.String(),
                        kSIFRE = c.String(),
                    })
                .PrimaryKey(t => t.kID);
            
            CreateTable(
                "dbo.MusteriBorcs",
                c => new
                    {
                        odemeID = c.Int(nullable: false, identity: true),
                        odemeTutar = c.Int(nullable: false),
                        tarih = c.String(),
                        musteriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.odemeID)
                .ForeignKey("dbo.Musteris", t => t.musteriID, cascadeDelete: true)
                .Index(t => t.musteriID);
            
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        musteriID = c.Int(nullable: false, identity: true),
                        musteriNo = c.Int(nullable: false),
                        musteriAdi = c.String(),
                        musteriSoyadi = c.String(),
                        musteriBorc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.musteriID);
            
            CreateTable(
                "dbo.SatisListesis",
                c => new
                    {
                        satisID = c.Int(nullable: false, identity: true),
                        barkodNo = c.Int(nullable: false),
                        urunAdı = c.String(),
                        satisFiyati = c.Int(nullable: false),
                        urunAdet = c.Int(nullable: false),
                        satisTarihi = c.String(),
                        musteriID = c.Int(nullable: false),
                        stokID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.satisID)
                .ForeignKey("dbo.Musteris", t => t.musteriID, cascadeDelete: true)
                .ForeignKey("dbo.Stoks", t => t.stokID, cascadeDelete: true)
                .Index(t => t.musteriID)
                .Index(t => t.stokID);
            
            CreateTable(
                "dbo.Stoks",
                c => new
                    {
                        stokID = c.Int(nullable: false, identity: true),
                        urunKodu = c.Int(nullable: false),
                        barkodNo = c.String(),
                        irsaliyeNo = c.Int(nullable: false),
                        birimFiyat = c.Int(nullable: false),
                        urunMiktar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stokID);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        urunID = c.Int(nullable: false, identity: true),
                        urunKodu = c.Int(nullable: false),
                        satisFiyati = c.Int(nullable: false),
                        kayitTarihi = c.String(),
                        tedID = c.Int(nullable: false),
                        stokID = c.Int(nullable: false),
                        urunAdı = c.String(),
                        urunKazanc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.urunID)
                .ForeignKey("dbo.Stoks", t => t.stokID, cascadeDelete: true)
                .ForeignKey("dbo.Tedarikcis", t => t.tedID, cascadeDelete: true)
                .Index(t => t.tedID)
                .Index(t => t.stokID);
            
            CreateTable(
                "dbo.Tedarikcis",
                c => new
                    {
                        tedID = c.Int(nullable: false, identity: true),
                        tedNo = c.Int(nullable: false),
                        tedFirma = c.String(),
                        dosyaAdi = c.String(),
                        tedBorc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tedID);
            
            CreateTable(
                "dbo.tedOdemes",
                c => new
                    {
                        odemeID = c.Int(nullable: false, identity: true),
                        odemeMiktar = c.Int(nullable: false),
                        tarih = c.String(),
                        tedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.odemeID)
                .ForeignKey("dbo.Tedarikcis", t => t.tedID, cascadeDelete: true)
                .Index(t => t.tedID);
            
            CreateTable(
                "dbo.Satists",
                c => new
                    {
                        satisID = c.Int(nullable: false, identity: true),
                        kazanc = c.Int(nullable: false),
                        tarih = c.DateTime(nullable: false),
                        kID = c.Int(nullable: false),
                        musteriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.satisID)
                .ForeignKey("dbo.Kullanıcı", t => t.kID, cascadeDelete: true)
                .ForeignKey("dbo.Musteris", t => t.musteriID, cascadeDelete: true)
                .Index(t => t.kID)
                .Index(t => t.musteriID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satists", "musteriID", "dbo.Musteris");
            DropForeignKey("dbo.Satists", "kID", "dbo.Kullanıcı");
            DropForeignKey("dbo.Uruns", "tedID", "dbo.Tedarikcis");
            DropForeignKey("dbo.tedOdemes", "tedID", "dbo.Tedarikcis");
            DropForeignKey("dbo.Uruns", "stokID", "dbo.Stoks");
            DropForeignKey("dbo.SatisListesis", "stokID", "dbo.Stoks");
            DropForeignKey("dbo.SatisListesis", "musteriID", "dbo.Musteris");
            DropForeignKey("dbo.MusteriBorcs", "musteriID", "dbo.Musteris");
            DropIndex("dbo.Satists", new[] { "musteriID" });
            DropIndex("dbo.Satists", new[] { "kID" });
            DropIndex("dbo.tedOdemes", new[] { "tedID" });
            DropIndex("dbo.Uruns", new[] { "stokID" });
            DropIndex("dbo.Uruns", new[] { "tedID" });
            DropIndex("dbo.SatisListesis", new[] { "stokID" });
            DropIndex("dbo.SatisListesis", new[] { "musteriID" });
            DropIndex("dbo.MusteriBorcs", new[] { "musteriID" });
            DropTable("dbo.Satists");
            DropTable("dbo.tedOdemes");
            DropTable("dbo.Tedarikcis");
            DropTable("dbo.Uruns");
            DropTable("dbo.Stoks");
            DropTable("dbo.SatisListesis");
            DropTable("dbo.Musteris");
            DropTable("dbo.MusteriBorcs");
            DropTable("dbo.Kullanıcı");
            DropTable("dbo.gecicis");
        }
    }
}
