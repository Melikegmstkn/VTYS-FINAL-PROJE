using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    class Urun
    {
        [Key]
        
        public int urunID { get; set; }
        public int urunKodu { get; set; }
        public int satisFiyati { get; set; }
        public string kayitTarihi { get; set; }
        public int tedID { get; set; }
        public int stokID { get; set; }
        public string urunAdı { get; set; }
        public int urunKazanc { get; set; }

        public Tedarikci Tedarikci { get; set; }
        public Stok Stok { get; set; }
    }
}
