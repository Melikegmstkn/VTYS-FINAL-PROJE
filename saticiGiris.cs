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
    public partial class saticiGiris : Form
    {
        public saticiGiris()
        {
            InitializeComponent();
        }
        
        Context db = new Context();
        Kullanıcı kullanici = new Kullanıcı();
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true )
            {
                if (textBox1.Text == dataGridView1.CurrentRow.Cells[1].Value.ToString() && textBox2.Text == dataGridView1.CurrentRow.Cells[2].Value.ToString())
                {
                    this.Hide();
                    satis frm3 = new satis();
                    frm3.kadi = textBox1.Text;
                    frm3.kid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    frm3.Show();

                    MessageBox.Show("Satış İşlemi !!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                else
                {
                    MessageBox.Show("Degerleri Gozden Geciriniz!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            if (radioButton2.Checked == true)
            {
                if (textBox1.Text == dataGridView1.CurrentRow.Cells[1].Value.ToString() && textBox2.Text == dataGridView1.CurrentRow.Cells[2].Value.ToString())
                {
                    this.Hide();
                    odeme frm = new odeme();
                    frm.Show();

                    MessageBox.Show("Silme İşlemi !!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Degerleri Gozden Geciriniz!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false )
            {
                if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox1.Text)) 
                {
                    MessageBox.Show("Bos kısım bırakmayınız ve bir Giris turu seciniz!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    MessageBox.Show("Bir Giris turu seciniz!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void doldur()
        {
            var degerler = db.Kullanıcıs.Select(x =>
            new
            {
                KULLANICIID = x.kID,
                KULLANICIADI = x.kADI,
                SIFRE = x.kSIFRE
            });
            dataGridView1.DataSource = degerler.ToList();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            doldur();

            int kullanıcıID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            /*
            var ara = from x in db.Kullanıcıs 
                      Where (x => x.urunAdı.Contains(textBox1.Text)).ToList()
                      select x.kID
            */

            //var max = db.SatisListesis.OrderByDescending(x => x.satisID).FirstOrDefault();
            //int a = int.Parse(max.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var ara = from x in db.Kullanıcıs select x;
            if (textBox1.Text != null)
            {
                dataGridView1.DataSource = ara.Where(x => x.kADI.Contains(textBox1.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }
    }
}
