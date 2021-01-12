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
    public partial class musteriEkle : Form
    {
        public musteriEkle()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Musteri Musteri = new Musteri();
        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(maskedTextBox1.Text);

            Musteri.musteriNo = x;
            Musteri.musteriAdi = maskedTextBox2.Text;
            Musteri.musteriSoyadi = maskedTextBox3.Text;
            Musteri.musteriBorc = 0;


            db.Musteris.Add(Musteri);
            db.SaveChanges();
            this.Close();
            satis frm = new satis();
            frm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            satis frm = new satis();
            frm.Show();
        }
    }
}
