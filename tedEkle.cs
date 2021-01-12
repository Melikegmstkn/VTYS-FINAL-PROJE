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
    public partial class tedEkle : Form
    {
        public tedEkle()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Tedarikci Tedarikci = new Tedarikci();

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(maskedTextBox1.Text);
            Tedarikci.tedNo = x;
            Tedarikci.tedFirma = textBox3.Text;
            Tedarikci.tedBorc = 0;


            db.Tedarikcis.Add(Tedarikci);
            db.SaveChanges();
            this.Hide();
            urunStok frm = new urunStok();
            frm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            urunStok frm = new urunStok();
            frm.Show();
        }
    }
}
