using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    class tedOdeme
    {
        [Key]
        public int odemeID { get; set; }
        public int odemeMiktar { get; set; }
        public string tarih { get; set; }
        public int tedID { get; set; }
        private Tedarikci Tedarikci { get; set; }
    }
}
