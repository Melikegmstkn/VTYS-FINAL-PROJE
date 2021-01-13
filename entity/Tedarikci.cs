using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    class Tedarikci
    {
        [Key]
        public int tedID { get; set; }
        public int tedNo { get; set; }
        public string tedFirma { get; set; }
        public string dosyaAdi { get; set; }
        public int tedBorc { get; set; }
        public ICollection<Urun> Uruns { get; set; }
        public ICollection<tedOdeme> tedOdemes { get; set; }

    }
}
