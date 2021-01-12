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
    public partial class urunStok : Form
    {
        public urunStok()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Tedarikci Tedarikci = new Tedarikci();
        Stok Stok = new Stok();
        Urun Urun = new Urun();
        Satist Satist = new Satist();

        int tedBorc = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "txt dosyası |*.txt";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Txt Uzantılı Dosya Seçiniz...";
            file.ShowDialog();

            string dosyayolu = file.FileName;
            string dosyaadi = file.SafeFileName;
            label2.Text = dosyaadi;
            
            var tedarikci = db.Tedarikcis.FirstOrDefault(t => t.tedFirma == textBox6.Text);
            tedarikci.dosyaAdi = dosyaadi;
            

            string dosya_yolu = dosyayolu;
            string[] satirlar = System.IO.File.ReadAllLines(dosya_yolu);

            int i, borc = 0;
            for (i = 0; i < satirlar.Length; i = i + 5)
            {
                //Stok.urunKodu = int.Parse(satirlar[i]);
                Stok.urunKodu = int.Parse(satirlar[i]);
                Stok.barkodNo = satirlar[i + 1];
                Stok.irsaliyeNo = int.Parse(satirlar[i + 2]);
                Stok.birimFiyat = int.Parse(satirlar[i + 3]);
                Stok.urunMiktar = int.Parse(satirlar[i + 4]);
                

                db.Stoks.Add(Stok);
                db.SaveChanges();

                int miktar = int.Parse(satirlar[i + 4]);
                int fiyat = int.Parse(satirlar[i + 3]);
                borc += miktar * fiyat;
            }

            tedBorc = borc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = tedBorc.ToString();
            doldur();
            doldur1();

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("TEDARİKCİ FIRMAYI YAZINIZ", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                var tedarikci = db.Tedarikcis.FirstOrDefault(t => t.tedFirma == textBox6.Text);
                tedarikci.tedBorc += tedBorc;
                db.SaveChanges();
            }
        }
        private void doldur()
        {
            var degerler = db.Stoks.Select(x =>
            new
            {
                STOKID = x.stokID,
                URUNKOD = x.urunKodu,
                BARKODNO = x.barkodNo,
                İRSALİYENO = x.irsaliyeNo,
                BİRİMFİYAT = x.birimFiyat,
                URUNMİKTAR = x.urunMiktar
            }) ;
            dataGridView1.DataSource = degerler.ToList();
        }
        private void doldur1()
        {
            var degerler = from x in db.Uruns
                           select new
                           {
                               URUNID = x.urunID,
                               URUNKODU = x.urunKodu,
                               SATISFİYATI = x.satisFiyati,
                               KAYITTARİHİ = x.kayitTarihi,
                               TEDARIKCIID = x.tedID,
                               STOKID = x.stokID,
                               URUNADI = x.urunAdı,
                               URUNKAZANC=x.urunKazanc
                           };
            dataGridView2.DataSource = degerler.ToList();
        }
        private void combodoldur()
        {
            Context db = new Context();
            var item = db.Tedarikcis.ToList();
            comboBox1.Items.Add("Seciniz");
            foreach (var x in item)
            {
                comboBox1.Items.Add(x.tedID);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int q = int.Parse(maskedTextBox1.Text);
            var Uru = db.Uruns.FirstOrDefault(u => u.stokID == q);
            if (dataGridView2.Rows.Count == 0 ||  Uru == null )
            {
                int x = int.Parse(maskedTextBox1.Text);
                int y = int.Parse(textBox3.Text);
                int z = int.Parse(textBox1.Text);
                int t = int.Parse(comboBox1.Text);
                int v = int.Parse(textBox5.Text);
                Urun.stokID = x;
                Urun.urunKodu = y;
                Urun.satisFiyati = z;
                Urun.tedID = t;
                Urun.kayitTarihi = dateTimePicker1.Text;
                Urun.urunAdı = textBox2.Text;
                Urun.urunKazanc = z - v;
                db.Uruns.Add(Urun);

                db.SaveChanges();
                doldur1();
            }
            else
            {
                if (Uru != null)
                {
                    int x = int.Parse(maskedTextBox1.Text);
                    int y = int.Parse(textBox3.Text);
                    int z = int.Parse(textBox1.Text);
                    int t = int.Parse(comboBox1.Text);
                    int v = int.Parse(textBox5.Text);
                    var Urun = db.Uruns.FirstOrDefault(u => u.stokID == x);
                    Urun.stokID = x;
                    Urun.urunKodu = y;
                    Urun.satisFiyati = z;
                    Urun.tedID = t;
                    Urun.kayitTarihi = dateTimePicker1.Text;
                    Urun.urunAdı = textBox2.Text;
                    Urun.urunKazanc = z - v;

                    db.SaveChanges();
                    doldur1();

                }

                /*
                else
                {
                    if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text))
                    {
                        MessageBox.Show("EKLEME İÇİN BOŞ BİLGİ BIRAKMAYIN...", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        int x = int.Parse(maskedTextBox1.Text);
                        int y = int.Parse(textBox3.Text);
                        int z = int.Parse(textBox1.Text);
                        int t = int.Parse(comboBox1.Text);
                        int v = int.Parse(textBox5.Text);
                        Urun.stokID = x;
                        Urun.urunKodu = y;
                        Urun.satisFiyati = z;
                        Urun.tedID = t;
                        Urun.kayitTarihi = dateTimePicker1.Text;
                        Urun.urunAdı = textBox2.Text;
                        Urun.urunKazanc = z - v;
                        db.Uruns.Add(Urun);

                        db.SaveChanges();
                        doldur1();
                    }
                }
                */
            }
            


            /*
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("BOŞ BİLGİ BIRAKMAYIN...", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (dataGridView2.Rows.Count == 0)
                {
                    //if (maskedTextBox1.Text != dataGridView2.CurrentRow.Cells[5].Value.ToString())
                    //string.IsNullOrEmpty(dataGridView2.ToString())
                    int x = int.Parse(maskedTextBox1.Text);
                    int y = int.Parse(textBox3.Text);
                    int z = int.Parse(textBox1.Text);
                    int t = int.Parse(comboBox1.Text);
                    Urun.stokID = x;
                    Urun.urunKodu = y;
                    Urun.satisFiyati = z;
                    Urun.tedID = t;
                    Urun.kayitTarihi = dateTimePicker1.Text;
                    Urun.urunAdı = textBox2.Text;
                    db.Uruns.Add(Urun);
                    db.SaveChanges();
                    doldur1();
                }

                if (maskedTextBox1.Text != dataGridView2.CurrentRow.Cells[5].Value.ToString() && textBox3.Text != dataGridView2.CurrentRow.Cells[1].Value.ToString())
                {
                    int x = int.Parse(maskedTextBox1.Text);
                    int y = int.Parse(textBox3.Text);
                    int z = int.Parse(textBox1.Text);
                    int t = int.Parse(comboBox1.Text);
                    Urun.stokID = x;
                    Urun.urunKodu = y;
                    Urun.satisFiyati = z;
                    Urun.tedID = t;
                    Urun.kayitTarihi = dateTimePicker1.Text;
                    Urun.urunAdı = textBox2.Text;

                    db.Uruns.Add(Urun);
                    db.SaveChanges();
                    doldur1();
                }

                if (textBox3.Text == dataGridView2.CurrentRow.Cells[1].Value.ToString() || maskedTextBox1.Text == dataGridView2.CurrentRow.Cells[5].Value.ToString())
                {
                    MessageBox.Show("aynı id", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            tedEkle frm8 = new tedEkle();
            frm8.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Items.Clear();
            combodoldur();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var ara = from x in db.Uruns select x;
            if (textBox4.Text != null)
            {
                dataGridView2.DataSource = ara.Where(x => x.urunAdı.Contains(textBox4.Text)).ToList();
                //doldur1(); 
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }
    }
}
