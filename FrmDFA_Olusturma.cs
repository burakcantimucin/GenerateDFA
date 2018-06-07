using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama
{
    public partial class FrmDFA_Olusturma : Form
    {
        public FrmDFA_Olusturma()
        {
            InitializeComponent();
        }

        bool SistemHatasiVarMi = false;
        string[] OlasiGirdiler;
        int DurumSayisi;
        string[] KabulDurumlari;

        private void FrmDFA_Olusturma_Load(object sender, EventArgs e)
        {
            txtDFA_Tanimlama.Text = "q0, 0, q2 | q0, 1, q1 | q1, 0, q2 | q1, 1, q0 | q2, 0, q4 | q2, 1, q1 | q4, 0, q3 | q4, 1, q2 | q3, 0, q1 | q3, 1, q3";
        }

        private void BtnDFA_Yapisi_Click(object sender, EventArgs e)
        {
            DFA.Temizle();
            DurumSayisi = Convert.ToInt32(nudDurumSayisi.Value);
            char[] BaslangicDurumu = txtBaslangicDurumu.Text.Replace(" ", "").ToCharArray();
            KabulDurumlari = txtKabulDurumu.Text.Replace(" ", "").Split(',');
            OlasiGirdiler = txtGirdiler.Text.Replace(" ", "").Split(',');
            SistemHatasiVarMi = false;
            bool KabulDurumHatasiVarMi = false;
            foreach (string Deger in KabulDurumlari)
            {
                if (Deger.Length != 2 || Deger[0] != 'q' || !(Char.IsDigit(Deger[1])) || (int)Char.GetNumericValue(Deger[1]) > DurumSayisi - 1)
                {
                    KabulDurumHatasiVarMi = true; break;
                }
            }
            if (!KabulDurumHatasiVarMi)
            {
                foreach (string Deger in KabulDurumlari) DFA.KabulDurumlari.Add(Convert.ToInt32(Deger[1].ToString()));
            }
            foreach (string Deger in OlasiGirdiler) DFA.OlasiGirdiler.Add(Deger);
            if (DurumSayisi == 0)
            {
                MessageBox.Show("Durum sayısını 0 girdiğiniz için DFA oluşturulamayacaktır.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SistemHatasiVarMi = true;
            }
            else if (BaslangicDurumu.Length != 2 || BaslangicDurumu[0] != 'q' || !(Char.IsDigit(BaslangicDurumu[1])))
            {
                MessageBox.Show("Başlangıç durumunu doğru tanıtmadığınız için DFA oluşturulamayacaktır.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SistemHatasiVarMi = true;
            }
            else if (KabulDurumHatasiVarMi)
            {
                KabulDurumHatasiVarMi = false;
                DFA.KabulDurumlari.Clear();
                MessageBox.Show("Kabul durumlarını doğru tanıtmadığınız için DFA oluşturulamayacaktır.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SistemHatasiVarMi = true;
            }
            else if (OlasiGirdiler.Length != 2)
            {
                MessageBox.Show("Olası girdileri doğru tanıtmadığınız için DFA oluşturulamayacaktır.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SistemHatasiVarMi = true;
            }
            else if (!SistemHatasiVarMi)
            {
                BtnDFA_Yapisi.Enabled = false;
                BtnDFA_Yapisi.Text = "Yapı Oluşturuldu";
                BtnDFA_Tanimlama.Enabled = true;
                txtDFA_Tanimlama.Enabled = true;
                if (txtBaslangicDurumu.Text != "") DFA.BaslangicDurumu = (int)Char.GetNumericValue(BaslangicDurumu[1]);
                for (int i = 0; i < DurumSayisi; i++) DFA.Durumlar.Add(i);
            }
        }

        private void BtnDFA_Tanimlama_Click(object sender, EventArgs e)
        {
            string DFA_Tanimlama = txtDFA_Tanimlama.Text.Replace(" ", "").Replace("\n", "");
            String[] DFA_Tanimlama_Dizisi = DFA_Tanimlama.Split('|');
            if (DFA_Tanimlama == "" || !(DFA_Tanimlama.Contains('|')))
            {
                MessageBox.Show("Statelerin hangi inputlar için hangi statelere geçeceğini tanımlamayı unuttunuz.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); SistemHatasiVarMi = true;
            }
            else
            {
                try
                {
                    for (int i = 0; i < DFA_Tanimlama_Dizisi.Length; i++)
                    {
                        if (DFA_Tanimlama_Dizisi.Length != DurumSayisi * 2)
                        {
                            MessageBox.Show("DFA tanımlanmasında sorun çıktı.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); SistemHatasiVarMi = true; break;
                        }
                        else if (DFA_Tanimlama_Dizisi[i] != "")
                        {
                            String[] DFA_Tanimlama_Dizisi_Ayirma = DFA_Tanimlama_Dizisi[i].Split(',');
                            if (!OlasiGirdiler.Contains(DFA_Tanimlama_Dizisi_Ayirma[1]))
                            {
                                MessageBox.Show("DFA tanımlanmasında sorun çıktı.",
                                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); SistemHatasiVarMi = true; break;
                            }
                            else
                            {
                                if (DurumMu(DFA_Tanimlama_Dizisi_Ayirma[0]) && DFA_Tanimlama_Dizisi_Ayirma[1] != "" && DurumMu(DFA_Tanimlama_Dizisi_Ayirma[2]))
                                {
                                    GirdiBilgisi GirdiBilgisi = new GirdiBilgisi(Convert.ToInt32(DFA_Tanimlama_Dizisi_Ayirma[0][1].ToString()), 
                                    DFA_Tanimlama_Dizisi_Ayirma[1], Convert.ToInt32(DFA_Tanimlama_Dizisi_Ayirma[2][1].ToString()));
                                    DFA.GirdiBilgileri.Add(GirdiBilgisi); SistemHatasiVarMi = false;
                                }
                                else
                                {
                                    MessageBox.Show("DFA tanımlanmasında sorun çıktı.",
                                        "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); SistemHatasiVarMi = true;
                                }
                            }
                        }
                        if (i == DFA_Tanimlama_Dizisi.Length - 1 && !SistemHatasiVarMi)
                        {
                            BtnDFA_Tanimlama.Enabled = false; BtnDFA_Tanimlama.Text = "DFA Tanımlandı";
                            BtnGirdiKabulu.Enabled = true; txtIstenilenGirdi.Enabled = true; txtDFA_Tanimlama.ReadOnly = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("DFA tanımlanmasında sorun çıktı.",
                                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); SistemHatasiVarMi = true;
                }
            }
        }

        private bool DurumMu(String Girdi)
        {
            if (Girdi.Length != 2) return false;
            else if (Girdi[0].ToString() != "q") return false;
            else
            {
                try
                {
                    int Tanimlanan = Convert.ToInt32(Girdi[1].ToString());
                    if (!DFA.Durumlar.Contains(Tanimlanan))
                    {
                        MessageBox.Show("q" + Tanimlanan + " durumu sistemde daha önce tanımlanmadı.", "UYARI",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch { return false; }
                return true;
            }
        }

        private void BtnGirdiKabulu_Click(object sender, EventArgs e)
        {
            string IstenenDurum = txtIstenilenGirdi.Text.Replace(" ", "");
            string Girdiler = txtGirdiler.Text.Replace(" ", "");
            bool Bayrak = true;
            if (IstenenDurum == "")
            {
                MessageBox.Show("Kabul edilmesi istenen girdi alanını boş bıraktınız.",
                                "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SistemHatasiVarMi = true;
            }
            else
            {
                for (int i = 0; i <= IstenenDurum.Length - 1; i++)
                {
                    if (!Girdiler.Contains(IstenenDurum[i])) Bayrak = false;
                }
                if (!Bayrak)
                {
                    MessageBox.Show("Kabul edilmesi istenen girdi hatalıdır.", "UYARI",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SistemHatasiVarMi = true;
                }
                else
                {
                    DFA.Girdi = IstenenDurum; SistemHatasiVarMi = false;
                }
            }
            if (!SistemHatasiVarMi)
            {
                if (DFA.DFA_Kontrolu())
                {
                    if (DFA.Calistir())
                    {
                        BtnGirdiKabulu.Enabled = false;
                        BtnGirdiKabulu.Text = "Girdi Kabul Edildi";
                        BtnDFACizmeEkrani.Enabled = true;
                        txtKabulSonucu.Text = DFA.Cikti + "Böylelikle girdi kabul edilir.";
                        txtKabulSonucu.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        txtKabulSonucu.Text = DFA.Cikti + "Böylelikle girdi kabul edilmez.";
                        txtKabulSonucu.BackColor = Color.Red;
                    }
                }
            }
        }

        private void BtnDFACizmeEkrani_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDFA_SekilCizme SekilCiz = new FrmDFA_SekilCizme();
            SekilCiz.ShowDialog();
            this.Close();
        }
    }
}
