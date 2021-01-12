using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.OleDb;
namespace finalProje.Entity
{
    class Context: DbContext
    {
        public DbSet<Kullanıcı> Kullanıcıs { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Satist> Satists { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Tedarikci> Tedarikcis { get; set; }
        public DbSet<SatisListesi> SatisListesis { get; set; }
        public DbSet<gecici> gecicis { get; set; }
        public DbSet<MusteriBorc> MusteriBorcs { get; set; }
        public DbSet<tedOdeme> tedOdemes { get; set; }
    }
}
