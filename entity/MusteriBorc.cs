using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace finalProje.Entity
{
    class MusteriBorc
    {
        [Key]
        public int odemeID { get; set; }
        public int odemeTutar { get; set; }
        public string tarih { get; set; }
        public int musteriID { get; set; }
        private Musteri Musteri { get; set; }
    }
}
