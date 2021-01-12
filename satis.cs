using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finalProje.Entity;

namespace finalProje
{
    public partial class satis : Form
    {
        public satis()
        {
            InitializeComponent();
        }
        Context db = new Context();
        Stok Stok = new Stok();
        Satist Satist = new Satist();
        Musteri Musteri = new Musteri();
        SatisListesi SatisListesi = new SatisListesi();
        gecici gecici = new gecici();

        public string kadi { get; set; }
        public string kid { get; set; }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            int kazanc = int.Parse(label3.Text);

            string mAd = maskedTextBox1.Text;
            var musteriID = db.Musteris.FirstOrDefault(m => m.musteriAdi == mAd);
            int ID = musteriID.musteriID;

            DateTime dt =DateTime.Today;

            Satist.kazanc = kazanc;
            Satist.tarih = dt;
            Satist.kID = int.Parse(label11.Text);
            Satist.musteriID = ID;
            
            db.Satists.Add(Satist);
            db.SaveChanges();

            label3.Text = "0";
            doldurListe();

            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
        }
        private void btnEKLE_Click(object sender, EventArgs e)
        {
            int adet = int.Parse(maskedTextBox2.Text);
            string barkod = textBox1.Text;

            var urunBilgileriStok = db.Stoks.FirstOrDefault(x => x.barkodNo == barkod);
            int urunKoduStok = urunBilgileriStok.urunKodu;
            int stokID = urunBilgileriStok.stokID;
            int stokMiktar = urunBilgileriStok.urunMiktar;

            var urunBilgileriUrun = db.Uruns.FirstOrDefault(x => x.urunKodu == urunKoduStok);
            string uAdı = urunBilgileriUrun.urunAdı;
            int uFiyat = urunBilgileriUrun.satisFiyati;

            var musteriBilgi = db.Musteris.FirstOrDefault(x => x.musteriAdi == maskedTextBox1.Text);
            int mID = musteriBilgi.musteriID;

            DateTime tarih = DateTime.Now;

            if (stokMiktar < adet)
            {
                MessageBox.Show("ÜRÜN MİKTARINI AZALTIN", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                SatisListesi.barkodNo = int.Parse(barkod);
                SatisListesi.urunAdı = uAdı;
                SatisListesi.satisFiyati = uFiyat;
                SatisListesi.musteriID = mID;
                SatisListesi.urunAdet = adet;
                SatisListesi.stokID = stokID;
                SatisListesi.satisTarihi = tarih.ToString("M.dd.yyyy");

                db.SatisListesis.Add(SatisListesi);
                db.SaveChanges();

                gecici.barkodNo = int.Parse(barkod);
                gecici.urunAdı = uAdı;
                gecici.satisFiyati = uFiyat;
                gecici.urunAdet = adet;

                db.gecicis.Add(gecici);
                db.SaveChanges();

                doldurListe();

                int tutar = int.Parse(label3.Text);

                tutar += adet * uFiyat;
                label3.Text = Convert.ToString(tutar);
            }
        }
        private void btnSİL_Click_1(object sender, EventArgs e)
        {
            int kod = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //int miktarListe = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            var silListe = db.SatisListesis.FirstOrDefault(x => x.barkodNo == kod);
            
            db.SatisListesis.Remove(silListe);
            db.SaveChanges();

            var silGecici = db.gecicis.FirstOrDefault(x => x.barkodNo == kod);
            db.gecicis.Remove(silGecici);
            db.SaveChanges();

            doldurListe();

            int urunFiyat = silListe.satisFiyati;
            int urunAdet = silListe.urunAdet;
            int tutar = int.Parse(label3.Text);

            tutar -= urunFiyat * urunAdet;
            label3.Text = Convert.ToString(tutar);
        }

        /*
        private void doldurUrunler()
        {
            var degerler = from x in db.Uruns
                           join y in db.Stoks
                           on x.stokID equals y.stokID
                           select new
                           {
                               BARKODNO = y.barkodNo,
                               SATISFİYATI = x.satisFiyati,
                               URUNADI = x.urunAdı,
                               MİKTAR = y.urunMiktar,
                               STOKID = y.stokID
                           };
            dataGridView2.DataSource = degerler.ToList();
        }
        */
        private void doldurListe()
        {
            var degerler = from x in db.gecicis
                           orderby x.satisID descending
                           select new
                           {
                               x.barkodNo,
                               x.urunAdı,
                               x.satisFiyati,
                               x.urunAdet
                           };

            dataGridView1.DataSource = degerler.ToList();

            
            //var max = db.SatisListesis.OrderByDescending(x => x.satisID).FirstOrDefault();
            //int a = int.Parse(max.ToString());
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            var ara = (from x in db.Uruns
                           join y in db.Stoks
                           on x.stokID equals y.stokID
                           select new
                           {
                                y.barkodNo,
                                SATISFİYATI=x.satisFiyati,
                                URUNADI=x.urunAdı,
                                MIKTAR = y.urunMiktar, 
                                STOKID = y.stokID
                           }).Where(y => y.barkodNo.Contains(textBox1.Text)).ToList();

            
            //var ara = from x in db.Uruns select x;
            if (textBox1.Text != null)
            {
                dataGridView2.DataSource = ara;
            }
            */
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("VERESİYE");
            comboBox1.Items.Add("PESİN");
            
            label13.Text = kadi;
            label11.Text = kid;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           this.Hide();
            musteriEkle frm = new musteriEkle();
            frm.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "VERESİYE")
            {
                var musteriBilgi = db.Musteris.FirstOrDefault(x => x.musteriAdi == maskedTextBox1.Text);
                int mBorc = musteriBilgi.musteriBorc;
                int tutar = int.Parse(label3.Text);

                int toplamBorc = mBorc + tutar;

                musteriBilgi.musteriBorc = toplamBorc;
                comboBox1.SelectedIndex=0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            odeme frm = new odeme();
            frm.Show();
        }
    }
}

