using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama
{
    public class GirdiBilgisi
    {
        public int Anlik { get; set; }
        public string Girdi { get; set; }
        public int Yon { get; set; }

        public GirdiBilgisi(int Anlik, string Girdi, int Yon)
        {
            this.Anlik = Anlik;
            this.Girdi = Girdi;
            this.Yon = Yon;
        }

        public int BirSonrakiYer(int Anlik, string Girdi)
        {
            if (this.Anlik == Anlik && this.Girdi == Girdi) return Yon;
            else return -1;
        }
    }
}
