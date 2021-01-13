using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    class Satist
    {
       [Key]
        public int satisID { get; set; }
        public int kazanc { get; set; }
        public DateTime tarih { get; set; }
        public int kID { get; set; }
        public int musteriID { get; set; }
       
        
        private Kullanıcı Kullanıcı { get; set; }
        private Musteri Musteri { get; set; }
    }
}
