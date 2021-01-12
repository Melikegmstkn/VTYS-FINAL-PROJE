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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Context c = new Context();
            //c.Database.Create();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            odeme frm = new odeme();
            frm.Show();
            /*
            this.Hide();
            Form6 frm6 = new Form6();
            frm6.Show();
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            saticiGiris frm = new saticiGiris();
            frm.Show();

            /*
            this.Hide();
            satis frm = new satis();
            frm.Show();
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            rapor frm4 = new rapor();
            frm4.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            urunStok frm7 = new urunStok();
            frm7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            KullanıcıEkle frm = new KullanıcıEkle();
            frm.Show();
        }
    }
}
