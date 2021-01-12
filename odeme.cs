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
    public partial class odeme : Form
    {
        public odeme()
        {
            
            InitializeComponent();
        }

        Context db = new Context();
        MusteriBorc MusteriBorc = new MusteriBorc();
        Musteri Musteri = new Musteri();
        Tedarikci Tedarikci = new Tedarikci();
        Stok Stok = new Stok();
        Urun Urun = new Urun();
        Satist Satist = new Satist();
        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void doldurSatis()
        {
            var musteriBilgisi = db.Musteris.FirstOrDefault(x => x.musteriAdi == textBox1.Text);
            int mID = musteriBilgisi.musteriID;

            var degerler = from x in db.Satists
                           join y in db.Musteris
                           on x.musteriID equals y.musteriID
                           where x.musteriID == mID
                           select new
                           {
                               BORCMİKTARI = x.kazanc,
                               AD = y.musteriAdi,
                               SOYAD = y.musteriSoyadi,
                               TARİH = x.tarih,
                               SATISNO = x.satisID
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void doldurSatisDetay()
        {
            var musteriBilgisi = db.Musteris.FirstOrDefault(x => x.musteriAdi == textBox1.Text);
            int mID = musteriBilgisi.musteriID;

            var degerler = from x in db.SatisListesis
                           join y in db.Musteris
                           on x.musteriID equals y.musteriID
                           where x.musteriID == mID
                           select new
                           {
                               MUSTERIADI = y.musteriAdi,
                               URUN = x.urunAdı,
                               ADET = x.urunAdet,
                               TARIH = x.satisTarihi
                           };
            dataGridView2.DataSource = degerler.ToList();
        }
        private void doldurOdeme()
        {
            var musteriBilgisi = db.Musteris.FirstOrDefault(x => x.musteriAdi == textBox1.Text);
            int mID = musteriBilgisi.musteriID;

            var degerler = from x in db.MusteriBorcs
                           join y in db.Musteris
                           on x.musteriID equals y.musteriID
                           where x.musteriID == mID
                           select new
                           {
                               MUSTERIADI = y.musteriAdi,
                               TUTAR = x.odemeTutar,
                               TARIH = x.tarih
                           };
            dataGridView2.DataSource = degerler.ToList();
        }
        private void btnODEME_Click(object sender, EventArgs e)
        {
            var musteriBilgisi = db.Musteris.FirstOrDefault(x => x.musteriAdi == textBox1.Text);
            int mID = musteriBilgisi.musteriID;
            int mBORC = musteriBilgisi.musteriBorc;
            DateTime tarih = DateTime.Now;

            if(mBORC > 0 && int.Parse(textBox2.Text) <= mBORC)
            {
                MusteriBorc.odemeTutar = int.Parse(textBox2.Text);
                MusteriBorc.tarih = tarih.ToString();
                MusteriBorc.musteriID = mID;

                db.MusteriBorcs.Add(MusteriBorc);
                db.SaveChanges();

                doldurOdeme();
            }

            else
            {
                MessageBox.Show("SADAKA KUTUSU KASANIN YANINDADIR...", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnSİL_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["MUSTERIID"].Value.ToString()
            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[“id”].Value);
            
            int satisID = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());

            var silSatis = db.Satists.FirstOrDefault(x => x.satisID == satisID);

            db.Satists.Remove(silSatis);
            db.SaveChanges();
            
            doldurSatis();
            MessageBox.Show("KAYIT SİLİNDİ", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            var ara = from x in db.Musteris select x;
            if (textBox1.Text != null)
            {
                dataGridView1.DataSource = ara.Where(x => x.musteriAdi.Contains(textBox1.Text)).ToList();
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doldurSatis();
            var musteri = db.Musteris.FirstOrDefault(x => x.musteriAdi == textBox1.Text);
            int toplamBorc = musteri.musteriBorc;

            lblTopBorc.Text = toplamBorc.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doldurOdeme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doldurSatisDetay();
        }

        private void dataGridView1_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            lblSeciliBorc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }
    }
}
