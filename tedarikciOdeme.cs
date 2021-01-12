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
    public partial class tedarikciOdeme : Form
    {
        public tedarikciOdeme()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Tedarikci Tedarikci = new Tedarikci();
        tedOdeme TedOdeme = new tedOdeme();

        //tarih
        //tedId
        //odemeMiktar
        private void tedOdeme_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int guncelBorc;
            string tedAdi = textBox1.Text;
            int miktar = int.Parse(maskedTextBox1.Text);

            var tedBilgi = db.Tedarikcis.FirstOrDefault(x => x.tedFirma == tedAdi);
            int tedId = tedBilgi.tedID;
            int borc = tedBilgi.tedBorc;

            guncelBorc = borc - miktar;
            tedBilgi.tedBorc = guncelBorc;

            DateTime tarih = DateTime.Today;

            TedOdeme.tedID = tedId;
            TedOdeme.tarih = tarih.ToString("M.dd.yyyy");
            TedOdeme.odemeMiktar = miktar;

            db.tedOdemes.Add(TedOdeme);
            db.SaveChanges();

            this.Hide();
            rapor frm = new rapor();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            rapor frm = new rapor();
            frm.Show();
        }
    }
}
