using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProje.Entity
{
    public class Kullanıcı
    {
        [Key]
        
        public int kID { get; set; }

        public string kADI { get; set; }
        public string kSIFRE { get; set; }

        private ICollection<Satist> Satists { get; set; }
    }
}
