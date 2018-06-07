using DfaSimulator;
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
    public partial class FrmDFA_SekilCizme : Form
    {
        public FrmDFA_SekilCizme()
        {
            InitializeComponent();
        }

        int GirdiIndisi = 0;
        int AnlikDurum;
        Font DurumYazisi, GirdiYazisi;
        Brush OkIciRengi, GirdiRengi, DurumRengi;
        Pen YuvarlakKalemi, AnlikDurumYuvarlakKalinligi;

        private void FrmDFA_SekilCizme_Load(object sender, EventArgs e)
        {
            lblGirdi.Text = "Girdi: " + DFA.Girdi;
        }

        private void BtnDFA_Ciz_Click(object sender, EventArgs e)
        {
            BtnDFA_Ciz.Enabled = false;
            BtnAdimAdim.Enabled = true;
            BtnDurdur.Enabled = true;
            BtnOynat.Enabled = true;

            GirdiIndisi = 0;
            AnlikDurum = DFA.BaslangicDurumu;

            DurumYazisi = new System.Drawing.Font("Segoe UI", 18, FontStyle.Regular);
            GirdiYazisi = new System.Drawing.Font("Segoe UI", 12, FontStyle.Regular);

            OkIciRengi = new SolidBrush(System.Drawing.Color.DarkSlateGray);
            GirdiRengi = new SolidBrush(System.Drawing.Color.DarkGreen);
            DurumRengi = new SolidBrush(System.Drawing.Color.Goldenrod);
            
            Pen CizgiKalemi = new Pen(System.Drawing.Color.Black, 1);
            YuvarlakKalemi = new Pen(System.Drawing.Color.Black, 3);
            AnlikDurumYuvarlakKalinligi = new Pen(System.Drawing.Color.GreenYellow, 3);

            System.Drawing.Graphics Cizge = this.CreateGraphics();

            //Durumlar çizilirken bulundukları yerleri saklamak için

            List<Point> Koordinatlar = new List<Point>();

            int Dikey, Yatay = 20;
            for (int i = 0; i < DFA.Durumlar.Count; i++)
            {
                if (i == 0) Dikey = 150;
                else if (i % 2 == 0) Dikey = 250;
                else { Dikey = 50; Yatay += 150; }
                if (DFA.KabulDurumlari.Contains(i))
                {
                    Rectangle Dikdortgen = new Rectangle(Yatay - 5, Dikey - 5, 60, 60);
                    Cizge.DrawEllipse(YuvarlakKalemi, Dikdortgen);
                }
                if (DFA.BaslangicDurumu == i) Cizge.DrawString("Başla", GirdiYazisi, GirdiRengi, Yatay - 5, Dikey - 25);

                Rectangle Dikdortgen2 = new Rectangle(Yatay, Dikey, 50, 50);
                Cizge.DrawEllipse(YuvarlakKalemi, Dikdortgen2);
                Cizge.DrawString("q" + i, DurumYazisi, DurumRengi, Yatay, Dikey);

                Point Nokta = new Point(Yatay + 26, Dikey + 26);
                Koordinatlar.Add(Nokta);
            }
            OkIsleyici Ok = new OkIsleyici();
            for (int i = 0; i < DFA.Durumlar.Count; i++)
            {
                for (int j = 0; j < DFA.OlasiGirdiler.Count; j++)
                {
                    Ok.Genislik = 20;

                    Point pp1 = Koordinatlar[i];
                    Point pp2 = Koordinatlar[DFA.GirdiBilgiKontrolu(i, DFA.OlasiGirdiler[j])];

                    if (pp1.X == pp2.X && pp1.Y == pp2.Y)
                    {
                        if (i == 0)
                        {
                            int y = pp1.Y;
                            int x = pp1.X + 25;
                            Point pp3 = new Point(x, y);

                            int y2 = pp1.Y;
                            int x2 = pp1.X - 25;
                            Point pp4 = new Point(x2, y2);

                            int y3 = pp1.Y - 80;
                            int x3 = pp1.X + 40;
                            Point pp5 = new Point(x3, y3);

                            int y4 = pp1.Y - 80;
                            int x4 = pp1.X - 40;
                            Point pp6 = new Point(x4, y4);
                            
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp5.X - 40, pp5.Y);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp3, pp4, pp5, pp6);
                        }
                        else if ((i % 2) == 0)
                        {
                            int y = pp1.Y;
                            int x = pp1.X + 25;
                            Point pp3 = new Point(x, y);

                            int y2 = pp1.Y;
                            int x2 = pp1.X - 25;
                            Point pp4 = new Point(x2, y2);

                            int y3 = pp1.Y + 80;
                            int x3 = pp1.X + 40;
                            Point pp5 = new Point(x3, y3);

                            int y4 = pp1.Y + 80;
                            int x4 = pp1.X - 40;
                            Point pp6 = new Point(x4, y4);


                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp5.X - 43, pp5.Y - 20);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp3, pp4, pp5, pp6);
                        }
                        else
                        {
                            int y = pp1.Y;
                            int x = pp1.X + 25;
                            Point pp3 = new Point(x, y);

                            int y2 = pp1.Y;
                            int x2 = pp1.X - 25;
                            Point pp4 = new Point(x2, y2);

                            int y3 = pp1.Y - 80;
                            int x3 = pp1.X + 40;
                            Point pp5 = new Point(x3, y3);

                            int y4 = pp1.Y - 80;
                            int x4 = pp1.X - 40;
                            Point pp6 = new Point(x4, y4);


                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp5.X - 40, pp5.Y);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp3, pp4, pp5, pp6);
                        }

                    }
                    else if (pp1.X == pp2.X)
                    {
                        if (pp1.Y > pp2.Y)
                        {
                            int y = pp1.Y - (Math.Abs(pp1.Y - pp2.Y) / 2);
                            int x = pp2.X + 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.Y < pp2.Y)
                        {
                            int y = pp2.Y - (Math.Abs(pp2.Y - pp1.Y) / 2);
                            int x = pp2.X - 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                    }
                    else if (pp1.Y == pp2.Y)
                    {
                        if (pp1.X > pp2.X)
                        {
                            int x = pp1.X - (Math.Abs(pp1.X - pp2.X) / 2);
                            int y = pp2.Y - 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X < pp2.X)
                        {
                            int x = pp2.X - (Math.Abs(pp2.X - pp1.X) / 2);
                            int y = pp2.Y + 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                    }
                    else
                    {
                        if (pp1.X < pp2.X && pp1.Y > pp2.Y)
                        {
                            int x = pp2.X - 30;
                            int y = pp1.Y - 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X > pp2.X && pp1.Y < pp2.Y)
                        {
                            int x = pp2.X + 30;
                            int y = pp1.Y + 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X < pp2.X && pp1.Y < pp2.Y)
                        {
                            int x = pp1.X + 30;
                            int y = pp2.Y - 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                        else if (pp1.X > pp2.X && pp1.Y > pp2.Y)
                        {
                            int x = pp1.X - 30;
                            int y = pp2.Y + 30;
                            Point pp3 = new Point(x, y);
                            Cizge.DrawString(DFA.OlasiGirdiler[j], GirdiYazisi, GirdiRengi, pp3.X - 15, pp3.Y - 15);
                            Ok.EgriUzerindeOkCiz(Cizge, CizgiKalemi, OkIciRengi, pp1, pp2, pp3, pp3);
                        }
                    }
                }
            }
            Yatay = 20;
            for (int i = 0; i < DFA.Durumlar.Count; i++)
            {
                if (i == 0) Dikey = 150; //İlk durum çizilir
                else if (i % 2 == 0) Dikey = 250; //Durum çift sayı içeriyorsa
                else { Dikey = 50; Yatay += 150; } //Durum tek sayı içeriyorsa
                if (DFA.KabulDurumlari.Contains(i))
                {
                    Rectangle Dikdortgen = new Rectangle(Yatay - 5, Dikey - 5, 60, 60);
                    Cizge.DrawEllipse(YuvarlakKalemi, Dikdortgen);
                }
                if (i != DFA.BaslangicDurumu)
                {
                    Rectangle Dikdortgen = new Rectangle(Yatay, Dikey, 50, 50);
                    Cizge.DrawEllipse(YuvarlakKalemi, Dikdortgen);
                }
                else
                {
                    Rectangle Dikdortgen = new Rectangle(Yatay, Dikey, 50, 50);
                    Cizge.DrawEllipse(AnlikDurumYuvarlakKalinligi, Dikdortgen);
                }
                Cizge.DrawString("q" + i, DurumYazisi, DurumRengi, Yatay, Dikey);
            }
        }

        private void BtnOynat_Click(object sender, EventArgs e)
        {
            Zamanlayici.Interval = 2000;
            Zamanlayici.Start();
        }

        private void BtnDurdur_Click(object sender, EventArgs e)
        {
            Zamanlayici.Stop();
        }

        private void BtnAdimAdim_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            Play();
        }

        public void Play()
        {
            string Girdi = "";
            if (GirdiIndisi < DFA.Girdi.Length)
            {
                Girdi = DFA.Girdi[GirdiIndisi].ToString();
                GirdiIndisi++; lblOkunan.Text += Girdi;
            }
            else
            {
                Zamanlayici.Stop();
                if (DFA.KabulDurumlari.Contains(AnlikDurum))
                    MessageBox.Show("Son durum ile birlikte kabul durumuna ulaşılmıştır.", 
                                    "DFA Çizme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnAdimAdim.Enabled = false; BtnDurdur.Enabled = false; BtnOynat.Enabled = false;
            }

            Pen CizgiKalemi = new Pen(System.Drawing.Color.Black, 3);

            System.Drawing.Graphics Cizge = this.CreateGraphics();

            //Tüm durumların rengi değişir

            int Yatay = 20, Dikey;
            for (int i = 0; i < DFA.Durumlar.Count; i++)
            {
                if (i == 0) Dikey = 150; //İlk durum çizilir
                else if (i % 2 == 0) Dikey = 250; //Durum çift sayı içeriyorsa
                else { Dikey = 50; Yatay += 150; } //Durum tek sayı içeriyorsa
                if (DFA.KabulDurumlari.Contains(i))
                {
                    Rectangle Dikdortgen2 = new Rectangle(Yatay - 5, Dikey - 5, 60, 60);
                    Cizge.DrawEllipse(CizgiKalemi, Dikdortgen2);
                }
                Rectangle Dikdortgen = new Rectangle(Yatay, Dikey, 50, 50);
                Cizge.DrawEllipse(CizgiKalemi, Dikdortgen);
            }

            //Sıradaki durumun rengi değişir

            Yatay = 20;
            for (int i = 0; i < DFA.Durumlar.Count; i++)
            {
                if (i == 0) Dikey = 150; //İlk durum çizilir
                else if (i % 2 == 0) Dikey = 250; //Durum çift sayı içeriyorsa
                else { Dikey = 50; Yatay += 150; } //Durum tek sayı içeriyorsa
                if (DFA.GirdiBilgiKontrolu(AnlikDurum, Girdi) == i)
                {
                    if (DFA.KabulDurumlari.Contains(i))
                    {
                        Rectangle Dikdortgen = new Rectangle(Yatay - 5, Dikey - 5, 60, 60);
                        Cizge.DrawEllipse(AnlikDurumYuvarlakKalinligi, Dikdortgen);
                    }
                    Rectangle myRectangle = new Rectangle(Yatay, Dikey, 50, 50);
                    Cizge.DrawEllipse(AnlikDurumYuvarlakKalinligi, myRectangle);
                }
            }
            AnlikDurum = DFA.GirdiBilgiKontrolu(AnlikDurum, Girdi);
        }
    }
}
