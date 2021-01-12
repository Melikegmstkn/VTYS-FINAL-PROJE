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
    public partial class KullanıcıEkle : Form
    {
        public KullanıcıEkle()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Kullanıcı Kullanıcı = new Kullanıcı();
        private void button1_Click(object sender, EventArgs e)
        {

            Kullanıcı.kADI = textBox3.Text;
            Kullanıcı.kSIFRE = textBox4.Text;

            db.Kullanıcıs.Add(Kullanıcı);
            db.SaveChanges();

            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }

        private void KullanıcıEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }
    }
}
