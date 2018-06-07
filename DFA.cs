using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama
{
    public static class DFA
    {
        public static List<int> Durumlar = new List<int>();
        public static List<int> KabulDurumlari = new List<int>();
        public static List<String> OlasiGirdiler = new List<String>();
        public static List<GirdiBilgisi> GirdiBilgileri = new List<GirdiBilgisi>();
        public static int BaslangicDurumu { get; set; }
        public static int AnlikDurum { get; set; }
        public static string Girdi { get; set; }
        public static string Cikti { get; set; }

        public static void Temizle()
        {
            Durumlar.Clear();
            KabulDurumlari.Clear();
            OlasiGirdiler.Clear();
            GirdiBilgileri.Clear();
            Cikti = "";
        }

        public static bool DFA_Kontrolu()
        {
            for (int i = 0; i < Durumlar.Count; i++)
            {
                for (int k = 0; k < Girdi.Length; k++)
                {
                    if (GirdiBilgiKontrolu(i, Girdi[k].ToString()) == -1) return false;
                }
            }
            return true;
        }

        public static int GirdiBilgiKontrolu(int cur, String inp)
        {
            int Sonuc = -1;
            for (int i = 0; i <= GirdiBilgileri.Count - 1; i++)
            {
                if (GirdiBilgileri[i].BirSonrakiYer(cur, inp) != -1)
                {
                    Sonuc = GirdiBilgileri[i].BirSonrakiYer(cur, inp);
                }
            }
            return Sonuc;
        }

        public static bool Calistir()
        {
            AnlikDurum = BaslangicDurumu;
            Cikti = "";
            for (int i = 0; i <= Girdi.Length - 1; i++)
            {
                if (GirdiBilgiKontrolu(AnlikDurum, Girdi[i].ToString()) != -1)
                {
                    Cikti += Yazdir(AnlikDurum, GirdiBilgiKontrolu(AnlikDurum, Girdi[i].ToString()), Girdi[i].ToString());
                    AnlikDurum = GirdiBilgiKontrolu(AnlikDurum, Girdi[i].ToString());
                }
            }
            if (KabulDurumlari.Contains(AnlikDurum)) return true;
            else return false;
        }

        public static string Yazdir(int AnlikDurum, int GidilecekYer, String Girdi)
        {
            return Girdi + " girdisiyle q" + AnlikDurum + " durumundan q" + GidilecekYer + " durumuna geçilir.\n";
        }
    }
}
