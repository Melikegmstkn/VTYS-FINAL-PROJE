using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    class Stok
    {
        [Key]
        
        public int stokID { get; set; }
        public int urunKodu { get; set; }
        public string barkodNo { get; set; }
        public int irsaliyeNo { get; set; }
        public int birimFiyat { get; set; }
        public int urunMiktar { get; set; }


        public ICollection<Urun> Uruns { get; set; }
        public ICollection<SatisListesi> satisListesis { get; set; }
    }
}
