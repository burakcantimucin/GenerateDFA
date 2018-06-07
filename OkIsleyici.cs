using System;
using System.Drawing;
using System.Xml.Serialization;

namespace DfaSimulator
{
    [Serializable, XmlRoot("Ok", Namespace = "", IsNullable = false)]
    public class OkIsleyici
    {
        #region Ozellikler

        private float genislik = 15;

        public float Genislik
        {
            get { return genislik; }
            set { genislik = value; }
        }

        private float teta = 0.5f;

        public float Teta
        {
            get { return teta; }
            set { teta = value; }
        }

        public void TetayiDereceCinsindenAyarla(float dereceler)
        {
            if (dereceler <= 0) dereceler = 1;
            if (dereceler >= 180) dereceler = 179;
            teta = (float)Math.PI / 180 * dereceler;
        }

        private bool okIciniDoldur = true;

        public bool OkIciniDoldur
        {
            get { return okIciniDoldur; }
            set { okIciniDoldur = value; }
        }

        private int bezierEgriDugumlerininSayisi = 100;

        public int BezierEgriDugumlerininSayisi
        {
            get { return bezierEgriDugumlerininSayisi; }
            set
            {
                if (value > 4) bezierEgriDugumlerininSayisi = value;
            }
        }

        #endregion

        #region Yapicilar

        public OkIsleyici() { }

        public OkIsleyici(float genislik)
        {
            this.genislik = genislik;
        }

        public OkIsleyici(float genislik, float teta)
        {
            this.genislik = genislik;
            this.teta = teta;
        }

        public OkIsleyici(float genislik, float teta, bool okIciniDoldur)
        {
            this.genislik = genislik;
            this.teta = teta;
            this.okIciniDoldur = okIciniDoldur;
        }

        public OkIsleyici(float genislik, float teta, bool okIciniDoldur, int bezierEgriDugumlerininSayisi)
        {
            this.genislik = genislik;
            this.teta = teta;
            this.okIciniDoldur = okIciniDoldur;
            this.bezierEgriDugumlerininSayisi = bezierEgriDugumlerininSayisi;
        }

        #endregion

        #region OkCiz

        public void OkCiz(Graphics g, Pen pen, Brush brush, float x1, float y1, float x2, float y2)
        {
            OkCiz(g, pen, brush, new PointF(x1, y1), new PointF(x2, y2));
        }

        public void OkCiz(Graphics cizge, Pen kalem, Brush firca, PointF nokta1, PointF nokta2)
        {
            PointF[] okIciDizisi = new PointF[3];
   
            okIciDizisi[0] = nokta2;

            Vektor vektorKose = new Vektor(nokta2.X - nokta1.X, nokta2.Y - nokta1.Y);
            Vektor vektorSol = new Vektor(-vektorKose[1], vektorKose[0]);
            
            float cizgiUzunlugu = vektorKose.Uzunluk;
            float th = Genislik / (2.0f * cizgiUzunlugu);
            float ta = Genislik / (2.0f * ((float)Math.Tan(Teta / 2.0f)) * cizgiUzunlugu);
            
            PointF noktaTabani = new PointF(okIciDizisi[0].X + -ta * vektorKose[0], okIciDizisi[0].Y + -ta * vektorKose[1]); //base of the arrow
            
            okIciDizisi[1] = new PointF(noktaTabani.X + th * vektorSol[0], noktaTabani.Y + th * vektorSol[1]);
            okIciDizisi[2] = new PointF(noktaTabani.X + -th * vektorSol[0], noktaTabani.Y + -th * vektorSol[1]);

            cizge.DrawLine(kalem, nokta1, noktaTabani);

            if (OkIciniDoldur) cizge.FillPolygon(firca, okIciDizisi);

            cizge.DrawPolygon(kalem, okIciDizisi);
        }

        #endregion

        #region EgriUzerindeOkCiz

        public void EgriUzerindeOkCiz(Graphics cizge, Pen kalem, Brush firca, float[] kontrolNoktalari)
        {
            if (kontrolNoktalari.Length != 8)
                throw new ArgumentException("controlPoints has to be valid float array 8 elements in length");
            EgriUzerindeOkCiz(cizge, kalem, firca, kontrolNoktalari[0], kontrolNoktalari[1], kontrolNoktalari[2], kontrolNoktalari[3],
                                            kontrolNoktalari[4], kontrolNoktalari[5], kontrolNoktalari[6], kontrolNoktalari[7]);
        }
        
        public void EgriUzerindeOkCiz(Graphics cizge, Pen kalem, Brush firca, PointF nokta1, PointF nokta2, PointF nokta1egri, PointF nokta2egri)
        {
            EgriUzerindeOkCiz(cizge, kalem, firca, nokta1.X, nokta1.Y, nokta2.X, nokta2.Y, nokta1egri.X, nokta1egri.Y, nokta2egri.X, nokta2egri.Y);
        }

        public void EgriUzerindeOkCiz(Graphics cizge, Pen kalem, Brush firca, float nokta1X, float nokta1Y, float nokta2X, float nokta2Y, float nokta1egriX, float nokta1egriY, float nokta2egriX, float nokta2egriY)
        {
            if (bezierEgriDugumlerininSayisi < 4) bezierEgriDugumlerininSayisi = 4;
            PointF[] bezierCizgisi = BezierEgriDugumleriniAlin(nokta1X, nokta1Y, nokta2X, nokta2Y, nokta1egriX, nokta1egriY, nokta2egriX, nokta2egriY, bezierEgriDugumlerininSayisi);

            float okIciAgirligi = genislik / (2.0f * ((float)Math.Tan(teta / 2.0f)));
            float deltaUzunlugu = okIciAgirligi;
            int terminalDugumCizgisi = bezierCizgisi.Length - 2;
            for (int i = bezierCizgisi.Length - 2; i >= 1; i--)
            {
                float anlikMesafe = UzakligiAl(bezierCizgisi[i].X, bezierCizgisi[i].Y, nokta2X, nokta2Y);
                float geciciDelta = Math.Abs(okIciAgirligi - anlikMesafe);

                if (geciciDelta > deltaUzunlugu) break;
                deltaUzunlugu = geciciDelta;
                terminalDugumCizgisi = i;
            }

            PointF noktaTabani = bezierCizgisi[terminalDugumCizgisi];
            okIciAgirligi = UzakligiAl(noktaTabani.X, noktaTabani.Y, nokta2X, nokta2Y);

            PointF[] okIciListesi = new PointF[3];
            okIciListesi[0] = new PointF(nokta2X, nokta2Y);

            float th = genislik / (2.0f * okIciAgirligi);

            okIciListesi[1] = new PointF(noktaTabani.X + th * (noktaTabani.Y - nokta2Y), noktaTabani.Y + th * (nokta2X - noktaTabani.X));
            okIciListesi[2] = new PointF(noktaTabani.X + th * (nokta2Y - noktaTabani.Y), noktaTabani.Y + th * (noktaTabani.X - nokta2X));

            cizge.DrawCurve(kalem, bezierCizgisi, 0, terminalDugumCizgisi);
            if (OkIciniDoldur) cizge.FillPolygon(firca, okIciListesi);
            cizge.DrawPolygon(kalem, okIciListesi);
        }

        private PointF[] BezierEgriDugumleriniAlin(PointF p1, PointF p2, PointF p1c, PointF p2c, int numberOfNodes)
        {
            return BezierEgriDugumleriniAlin(p1.X, p1.Y, p2.X, p2.Y, p1c.X, p1c.Y, p2c.X, p2c.Y, numberOfNodes);
        }

        protected PointF[] BezierEgriDugumleriniAlin(float nokta1X, float nokta1Y, float nokta2X, float nokta2Y, float nokta1egriX, float nokta1egriY, float nokta2egriX, float nokta2egriY, int dugumlerinSayisi)
        {
            PointF[] dizi = new PointF[dugumlerinSayisi];

            float dt = 1f / (dizi.Length - 1);
            float t = -dt;
            for (int i = 0; i < dizi.Length; i++)
            {
                t += dt;
                float tt = t * t;
                float ttt = tt * t;
                float tt1 = (1 - t) * (1 - t);
                float ttt1 = tt1 * (1 - t);

                float x = ttt1 * nokta1X +
                          3 * t * tt1 * nokta1egriX +
                          3 * tt * (1 - t) * nokta2egriX +
                          ttt * nokta2X;

                float y = ttt1 * nokta1Y +
                          3 * t * tt1 * nokta1egriY +
                          3 * tt * (1 - t) * nokta2egriY +
                          ttt * nokta2Y;

                dizi[i] = new PointF(x, y);
            }
            return dizi;
        }

        protected float UzakligiAl(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        #endregion

        #region OklariCiz

        public void OklariCiz(Graphics cizge, Pen kalem, Brush firca, PointF[] apf)
        {
            OklariCiz(cizge, kalem, firca, apf, 0, 0);
        }

        public void OklariCiz(Graphics cizge, Pen kalem, Brush firca, PointF[] apf, float uzaklikBaslangici, float uzaklikBitisi)
        {
            if (apf.Length < 2) throw new ArgumentException("PointF[] apf en az 2 uzunluğuna sahip olmak zorunda");
            PointF[] yeniApf = new PointF[apf.Length + 1];
            Array.Copy(apf, yeniApf, apf.Length);
            yeniApf[yeniApf.Length - 1] = yeniApf[0];

            PointF noktadan = yeniApf[0], toP;
            for (int i = 0; i < yeniApf.Length - 1; i++)
            {
                toP = yeniApf[i + 1];
                Vektor vektorUzunlugu = new Vektor(toP.X - noktadan.X, toP.Y - noktadan.Y);
                Vektor vektorBaslangici = vektorUzunlugu - (vektorUzunlugu.Uzunluk - uzaklikBaslangici);
                PointF nFromP = new PointF(noktadan.X + vektorBaslangici.X, noktadan.Y + vektorBaslangici.Y);
                Vektor vektorSonu = vektorUzunlugu - uzaklikBitisi;
                PointF nToP = new PointF(noktadan.X + vektorSonu.X, noktadan.Y + vektorSonu.Y);
                OkCiz(cizge, kalem, firca, nFromP, nToP);
                noktadan = toP;
            }
        }
        
        public void OklariCiz(Graphics cizge, Pen kalem, Brush firca, PointF[] apf, float[] uzaklikBaslangici, float[] uzaklikBitisi)
        {
            if (apf.Length < 2) throw new ArgumentException("PointF[] apf en az 2 uzunluğuna sahip olmak zorunda");
            if (apf.Length != uzaklikBaslangici.Length || apf.Length != uzaklikBitisi.Length ||
                uzaklikBitisi.Length != uzaklikBaslangici.Length)
                throw new ArgumentException("apf, uzaklikBaslangici ve uzaklikBitisi eşit uzunlukta dizilere sahip olmak zorunda");

            PointF[] yeniApf = new PointF[apf.Length + 1];
            Array.Copy(apf, yeniApf, apf.Length);
            yeniApf[yeniApf.Length - 1] = yeniApf[0];

            PointF Pden = yeniApf[0], toP;
            for (int i = 0; i < yeniApf.Length - 1; i++)
            {
                toP = yeniApf[i + 1];
                Vektor vektorUzunlugu = new Vektor(toP.X - Pden.X, toP.Y - Pden.Y);
                Vektor vektorBaslangici = vektorUzunlugu - (vektorUzunlugu.Uzunluk - uzaklikBaslangici[i]);
                PointF nFromP = new PointF(Pden.X + vektorBaslangici.X, Pden.Y + vektorBaslangici.Y);
                Vektor vektorBitisi = vektorUzunlugu - uzaklikBitisi[i];
                PointF nToP = new PointF(Pden.X + vektorBitisi.X, Pden.Y + vektorBitisi.Y);
                OkCiz(cizge, kalem, firca, nFromP, nToP);
                Pden = toP;
            }
        }

        #endregion
    }
}