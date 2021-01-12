using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finalProje.entity;
using finalProje.Entity;
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;

namespace finalProje
{ 
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Urun urun = new Urun();
        Stok Stok = new Stok();
        Satist Satist = new Satist();
        Tedarikci Tedarikci = new Tedarikci();
        SatisListesi SatisListesi = new SatisListesi();
        tedOdeme TedOdeme = new tedOdeme();

        int i = 0;
        private void btnEKLE_Click(object sender, EventArgs e)
        {
            int sayac = i++;
            double kar; 
            int kod = int.Parse(textBox1.Text);

            var stok = db.Stoks.FirstOrDefault(s => s.urunKodu == kod);
            int birimFiyat = stok.birimFiyat;

            var urun = db.Uruns.FirstOrDefault(u => u.urunKodu == kod);
            int satisFiyat = urun.satisFiyati;

            kar = (satisFiyat - birimFiyat) * 100 / satisFiyat;

            /*
            foreach (var series in URUN.Series)
            {
                series.Points.Clear();
            }
            */
            URUN.Series["URUN"].Points.Add(kar);
            URUN.Series["URUN"].Points[sayac].AxisLabel = textBox1.Text;
            //URUN.ChartAreas[sayac].AxisX.LabelStyle.Angle = -70; //eğim
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (var series in URUN.Series)
            {
                series.Points.Clear();
            }
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Context liste = new Context();
            //liste.Database.ExecuteSqlCommand("cokSatanlar");
            var cokSatan = liste.Database.SqlQuery<cokSatanUrunler>("sp_cokSatanUrunler").ToList();
            dataGridView1.DataSource = cokSatan.ToList();

            /*
            var liste = db.SatisListesis.OrderBy(x => x.barkodNo).GroupBy(y => y.barkodNo).
                Select(z => new { barkod = z.Key, toplam = z.Count() });

            dataGridView1.DataSource = liste.ToList();
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string t1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string t2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            DateTime a = Convert.ToDateTime(t1);
            label4.Text = a.ToString();

            Context getir = new Context();
            SqlParameter tarih1 = new SqlParameter("@tarih1", Convert.ToDateTime(t1));
            SqlParameter tarih2 = new SqlParameter("@tarih2", Convert.ToDateTime(t2));
            getir.Database.ExecuteSqlCommand("OrnekSP4 @tarih1, @tarih2", tarih1, tarih2);
            var satislar = getir.Database.SqlQuery<Satist>("OrnekSP4 @tarih1, @tarih2", tarih1, tarih2).ToList();
            dataGridView2.DataSource = satislar.ToList();

            /*
            string tarih1 = dateTimePicker1.Text;
            string tarih2 = dateTimePicker2.Text;

            var satis1 = db.Satists.FirstOrDefault(x => x.tarih == tarih1);
            int s1 = satis1.satisID;

            var satis2 = db.Satists.FirstOrDefault(x => x.tarih == tarih2);
            int s2 = satis2.satisID;
            
            var listele = from x in db.Satists
                           where x.satisID >= s1 && x.satisID <= s2
                           select new
                           {
                               x.kazanc,
                               x.tarih
                           };
            dataGridView2.DataSource = listele.ToList();
            */

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                SATIS.Series["SATIS"].Points.AddXY(dataGridView2.Rows[i].Cells[1].Value.ToString(), dataGridView2.Rows[i].Cells[0].Value.ToString());
            }
            
            /*
            foreach ()
            {
                SATIS.Series["SATIS"].Points.Add(0);
                SATIS.Series["SATIS"].Points[sayac].AxisLabel = "";
            }
            */

            //var satisList = db.Satists.Sql("SQLQuery3", x.ToArray());
            //dataGridView2.DataSource = satisList.ToList();

            /*
            Context Veri = new Context();
            SqlParameter tarih1 = new SqlParameter("@tarih1", tarih11);
            SqlParameter tarih2 = new SqlParameter("@tarih2", tarih22);
            Veri.Database.ExecuteSqlCommand("dbo.rapor3 @tarih1, @tarih2",tarih1,tarih2);

            var satis = Veri.Database.SqlQuery<Satist>("dbo.rapor3 @tarih1 , @tarih2", tarih1,tarih2).ToList();

            dataGridView2.DataSource = satis.ToList();
            */
        }

        private void btnMusteriRaporListele_Click(object sender, EventArgs e)
        {
            string isim = textBox2.Text;
            var musteriBilgi = db.Musteris.FirstOrDefault(x => x.musteriAdi == isim);
            int mID = musteriBilgi.musteriID;

            var liste = from x in db.SatisListesis
                        where x.musteriID == mID
                        group x by x.urunAdı into y
                        let Miktar = y.Sum(a => a.urunAdet)
                        let Tutar = y.Sum(b => b.satisFiyati)
                        orderby Miktar descending
                        select new
                        {
                            URUNADI = y.Key,
                            MIKTAR = Miktar,
                            TUTAR = Tutar
                        };

            dataGridView3.DataSource = liste.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // var musteriBilgi =db.Musteris.FirstOrDefault() 

            var liste = from x in db.Musteris
                        join y in db.MusteriBorcs
                        on x.musteriID equals y.musteriID
                        let ToplamKalan = x.musteriBorc
                        group y by y.musteriID into z
                        let toplamOdeme = z.Sum(a => a.odemeTutar)
                        let toplamSatis = (db.Musteris.Where(d => d.musteriID == z.Key).Select(x => x.musteriBorc).FirstOrDefault())
                        orderby toplamOdeme descending
                        select new
                        {
                            MUSTERIID = z.Key,
                            MUSTERİADI = db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriAdi).FirstOrDefault(),
                            MUSTERİSOYADI = db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriSoyadi).FirstOrDefault(),
                            TOPLAMODEME = toplamOdeme,
                            TOPLAMKALAN = db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriBorc).FirstOrDefault(),
                            TOPLAMSATIS = toplamSatis +toplamOdeme,
                            //(int.Parse(toplamOdeme.ToString()) + int.Parse((db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriBorc).FirstOrDefault()).ToString()).ToString())
                        }; 
            
            dataGridView3.DataSource = liste.ToList();
        }

        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application();
            app.Visible = true;
            Workbook borc = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sayfa = (Worksheet)borc.Sheets[1];
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1]=dataGridView3.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView3.Columns.Count; i++) 
            {
                for (int j = 0; j < dataGridView3.Rows.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                    alan2.Cells[2, 1] = dataGridView3[i, j].Value;
                }
            }
        }

        private void odemeBilgileri_Click(object sender, EventArgs e)
        {
            int toplamOdeme = 0;
            doldurOdeme();

            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                toplamOdeme += int.Parse(dataGridView5.Rows[i].Cells[2].Value.ToString());
            }

            lblToplamOdeme.Text = toplamOdeme.ToString();

            
        }
        
        
        private void borcBilgileri_Click(object sender, EventArgs e)
        {
            int kalanBorc = 0;
            doldurBorc();

            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                kalanBorc += int.Parse(dataGridView5.Rows[i].Cells[2].Value.ToString());
            }

            lblKalanBorc.Text = kalanBorc.ToString();

        }
        private void doldurOdeme()
        {
            var ted = from x in db.Tedarikcis
                      join y in db.tedOdemes on x.tedID equals y.tedID
                      select new
                      {
                          TARIH = y.tarih,
                          FIRMA = x.tedFirma,
                          MIKTAR = y.odemeMiktar,
                      };
            dataGridView5.DataSource = ted.ToList();
        }

        private void doldurBorc()
        {
            var ted = from x in db.Tedarikcis
                      select new
                      {
                          FIRMA = x.tedFirma,
                          FIRMANO = x.tedNo,
                          BORCMIKTARI = x.tedBorc,
                      };
            dataGridView5.DataSource = ted.ToList();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            this.Hide();
            tedarikciOdeme frm = new tedarikciOdeme();
            frm.Show();
        }

        int k = 0;
        private void btnAnlikKar_Click(object sender, EventArgs e)
        {
            int sayac = k++;
            
            foreach (var series in KAR.Series)
            {
                series.Points.Clear();
            }
            
            var satisList = db.SatisListesis.FirstOrDefault(x => x.satisID == 8);
            int sID1 = satisList.satisID;

            //var stok = db.Stoks.FirstOrDefault(x => x.stokID == 1);
            //db.SatisListesis.Where(a => a.satisTarihi == y.Key).Select(x => x.urunAdet).FirstOrDefault()

            /*
            int gider = db.tedOdemes.Select(t => t).Sum(a => a.odemeMiktar);
            if (gider is DBNull )
            {
                gider = 0;
            }
            */

            var listele = from x in db.SatisListesis
                          group x by x.barkodNo into y
                          let urunKazanc = db.SatisListesis.Select(t => t).Sum(a => a.satisFiyati)
                          let satisAdet = y.Sum(a => a.urunAdet)
                          let stokAdet = db.Stoks.Where(a => a.stokID == y.Key).Select(x => x.urunMiktar).FirstOrDefault()
                          let birimFiyat = db.Stoks.Where(a => a.stokID == y.Key).Select(x => x.birimFiyat).FirstOrDefault()
                          let tedBorc = db.Tedarikcis.Select(t => t).Sum(a => a.tedBorc)
                          let tedOdeme = db.tedOdemes.DefaultIfEmpty().Select(t => t).Sum(a =>(decimal?) a.odemeMiktar ?? 0M)
                          select new
                          {
                              TOPLAMGELİR = urunKazanc*500,
                              TOPLAMGIDER = tedBorc + tedOdeme,
                              KAZANC = (urunKazanc*500) - (tedBorc + tedOdeme)
                          };
            
            dataGridView4.DataSource = listele.ToList();

            KAR.Series["KAR"].Points.Add(Convert.ToDouble(dataGridView4.CurrentRow.Cells[0].Value.ToString()));
            KAR.Series["KAR"].Points.Add(Convert.ToDouble(dataGridView4.CurrentRow.Cells[1].Value.ToString()));
            //KAR.Series["KAR"].Points.Add(Convert.ToDouble(dataGridView4.CurrentRow.Cells[2].Value.ToString()));

            KAR.Series["KAR"].Points[0].AxisLabel = "GELİR";
            KAR.Series["KAR"].Points[1].AxisLabel = "GİDER";
            //KAR.Series["KAR"].Points[2].AxisLabel = "KAZANC";

            KAR.ChartAreas[0].AxisX.LabelStyle.Angle = -70;

            KarZarar.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }
    }
}

//MUSTERI LİSTELE BORC
/*
            var liste = from x in db.Musteris
                        group x by x.musteriID into z
                        let kalanBorc = z.Sum(a => a.musteriBorc)
                        let toplamOdeme = db.MusteriBorcs.GroupBy(d => d.musteriID).Select(x => x).Sum(a=> a.)
                        //orderby toplamOdeme descending
                        select new
                        {
                            MUSTERİADI = db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriAdi).FirstOrDefault(),
                            MUSTERİSOYADI = db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriSoyadi).FirstOrDefault(),
                            TOPLAMSATIS = toplamOdeme + kalanBorc,
                            TOPLAMODEME = toplamOdeme,
                            TOPLAMKALAN = kalanBorc,
                            //(int.Parse(toplamOdeme.ToString()) + int.Parse((db.Musteris.Where(a => a.musteriID == z.Key).Select(x => x.musteriBorc).FirstOrDefault()).ToString()).ToString())
                        };

            dataGridView3.DataSource = liste.ToList();
            */

//SATIS KAR ZARAR (TARİH)
/*
var satisList = db.SatisListesis.FirstOrDefault(x => x.satisID == 1);
int sID1 = satisList.satisID;

var stok = db.Stoks.FirstOrDefault(x => x.stokID == 1);

var listele = from x in db.SatisListesis
              group x by x.satisTarihi into y
              let urunKazanc = y.Sum(a => a.satisFiyati)
              let satisAdet = db.SatisListesis.Where(a => a.satisTarihi == y.Key).Select(x => x.urunAdet).FirstOrDefault()
              let stokAdet = db.Stoks.Where(a => a.stokID == SatisListesi.stokID).Select(x => x.urunMiktar).FirstOrDefault()
              let birimFiyat = db.Stoks.Where(a => a.stokID == SatisListesi.stokID).Select(x => x.birimFiyat).FirstOrDefault()
              select new
              {
                  TARIH = y.Key,
                  SATISKAZANC = urunKazanc * satisAdet,

              };

dataGridView4.DataSource = listele.ToList();
*/
//TED SORGU
/*
    var tedBorc = from x in db.Tedarikcis
                  join y in db.tedOdemes on x.tedID equals y.tedID
                  group y by x.tedID into a
                  let toplamOdeme = a.Sum(b => b.odemeMiktar)
                  let toplamBorc = db.Tedarikcis.Where(b => b.tedID == a.Key).Select(a => a.tedBorc).FirstOrDefault()
                  let to = a.Sum(c => c.odemeMiktar + toplamOdeme)
                  select new
                  {
                      FIRMA = db.Tedarikcis.Where(b => b.tedID == a.Key).Select(a => a.tedFirma).FirstOrDefault(),
                      TOPLAMODEME = toplamOdeme,
                      KALANBORC = db.Tedarikcis.Where(b => b.tedID == a.Key).Select(a => a.tedBorc).FirstOrDefault(),
                      TOPLAMBORC = toplamOdeme + toplamBorc
                  };

    dataGridView4.DataSource = tedBorc.ToList();
    */

/* 
                 

var liste = db.SatisListesis.Where(a=> a.musteriID == mID).OrderBy(x => x.barkodNo).GroupBy(y => y.barkodNo).
    Select(t => new { 
        Urun = t.Key, 
        toplam = t.Count() 

    });
*/