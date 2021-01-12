using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace finalProje.Entity
{
    class gecici
    {
        [Key]
        public int satisID { get; set; }
        public int barkodNo { get; set; }
        public string urunAdı { get; set; }
        public int satisFiyati { get; set; }
        public int urunAdet { get; set; }
    }
}
