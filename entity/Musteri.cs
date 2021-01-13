using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    class Musteri
    {
        [Key]
        public int musteriID { get; set; }
        public int musteriNo { get; set; }
        public string musteriAdi { get; set; }
        public string musteriSoyadi { get; set; }
        public int musteriBorc { get; set; }
        public ICollection<SatisListesi> satisListesis { get; set; }
        public ICollection<Satist> Satists { get; set; }
        public ICollection<MusteriBorc> musteriBorcs { get; set; }
    }
}
