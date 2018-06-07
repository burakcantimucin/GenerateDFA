using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace DfaSimulator
{
    [Serializable, DebuggerDisplay("{ToString()}, Len = {Length}")]
    [XmlRoot("Vektor", Namespace = "", IsNullable = false)]
    public class Vektor : ICloneable
    {
        #region Ozel Uyeler ve Ozellikleri

        private float m_X;
        
        public float X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private float m_Y;
        
        public float Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        private float m_Z;
        
        public float Z
        {
            get { return m_Z; }
            set { m_Z = value; }
        }
        
        public float Uzunluk
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        public float Alfa
        {
            get { return (float)Math.Atan2(Y, X); }
        }

        #endregion

        #region Yapicilar
        
        public Vektor()
        {
        }
        
        public Vektor(float inX, float inY)
        {
            m_X = inX;
            m_Y = inY;
            m_Z = 0;
        }

        public Vektor(float inX, float inY, float inZ)
        {
            m_X = inX;
            m_Y = inY;
            m_Z = inZ;
        }
        
        public Vektor(float[] koordinasyon)
        {
            m_X = koordinasyon[0];
            m_Y = koordinasyon[1];
            m_Z = koordinasyon[2];
        }

        public Vektor(Vektor vektor)
        {
            m_X = vektor.X;
            m_Y = vektor.Y;
            m_Z = vektor.Z;
        }

        #endregion

        #region Metotlar
        
        public static Vektor Ekle(Vektor vektor1, Vektor vektor2)
        {
            if (((Object)vektor1 == null) || ((Object)vektor2 == null))
                return null;
            return new Vektor(vektor1.X + vektor2.X, vektor1.Y + vektor2.Y, vektor1.Z + vektor2.Z);
        }
        
        public static Vektor Cikar(Vektor vektor1, Vektor vektor2)
        {
            if (((Object)vektor1 == null) || ((Object)vektor2 == null))
                return null;
            return new Vektor(vektor1.X - vektor2.X, vektor1.Y - vektor2.Y, vektor1.Z - vektor2.Z);
        }

        public static Vektor IptalEt(Vektor vektor)
        {
            if ((Object)vektor == null) return null;
            return new Vektor(-vektor.X, -vektor.Y, -vektor.Z);
        }

        public static Vektor Cogalt(Vektor vektor, float deger)
        {
            if ((Object)vektor == null)
                return null;
            return new Vektor(vektor.X * deger, vektor.Y * deger, vektor.Z * deger);
        }
        
        public static float SkalerCarpim(params Vektor[] vektorler)
        {
            if (vektorler.Length < 2)
                throw new ArgumentException("Skaler çarpım en az 2 vektörle hesaplanabilir");
            float dx = vektorler[0].X, dy = vektorler[0].Y, dz = vektorler[0].Z;

            for (int i = 1; i < vektorler.Length; i++)
            {
                dx *= vektorler[0].X;
                dy *= vektorler[0].Y;
                dz *= vektorler[0].Z;
            }

            return (dx + dy + dz);
        }

        public static Vektor Daralt(Vektor vektor, float dUzunlugu)
        {
            float uzunluk = vektor.Uzunluk;
            if (uzunluk == 0) throw new ArgumentException("Vektör uzunluğu sıfıra eşit. Daraltılma ve genişletilme imkanı yok.");
            return new Vektor(vektor.X - (vektor.X * dUzunlugu / uzunluk),
                              vektor.Y - (vektor.Y * dUzunlugu / uzunluk),
                              vektor.Z - (vektor.Z * dUzunlugu / uzunluk));
        }

        public static Vektor Genislet(Vektor vektor, float dUzunlugu)
        {
            return Daralt(vektor, -1 * dUzunlugu);
        }

        public void Cevir(float dx, float dy, float dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

        #endregion

        #region Operatorler
        
        public static bool operator ==(Vektor vektor1, Vektor vektor2)
        {
            if (((Object)vektor1 == null) || ((Object)vektor2 == null)) return false;
            return ((vektor1.X.Equals(vektor2.X))
                    && (vektor1.Y.Equals(vektor2.Y))
                    && (vektor1.Z.Equals(vektor2.Z)));
        }

        public static bool operator !=(Vektor vektor1, Vektor vektor2)
        {
            if (((Object)vektor1 == null) || ((Object)vektor2 == null)) return false;
            return (!(vektor1 == vektor2));
        }

        public static Vektor operator +(Vektor vektor1, Vektor vektor2)
        {
            if (((Object)vektor1 == null) || ((Object)vektor2 == null)) return null;
            return Ekle(vektor1, vektor2);
        }

        public static Vektor operator -(Vektor vektor1, Vektor vektor2)
        {
            if (((Object)vektor1 == null) || ((Object)vektor2 == null))
                return null;
            return Cikar(vektor1, vektor2);
        }

        public static Vektor operator -(Vektor vektor1, float dUzunlugu)
        {
            if ((Object)vektor1 == null) return null;
            return Daralt(vektor1, dUzunlugu);
        }

        public static Vektor operator +(Vektor vektor1, float dUzunlugu)
        {
            if ((Object)vektor1 == null) return null;
            return Genislet(vektor1, dUzunlugu);
        }
        
        public static Vektor operator -(Vektor vektor)
        {
            if ((Object)vektor == null) return null;
            return IptalEt(vektor);
        }

        public static Vektor operator *(Vektor vektor, float deger)
        {
            if ((Object)vektor == null) return null;
            return Cogalt(vektor, deger);
        }

        public static Vektor operator *(float deger, Vektor vektor)
        {
            if ((Object)vektor == null) return null;
            return Cogalt(vektor, deger);
        }

        public float this[byte indis]
        {
            get
            {
                if (indis < 0 || indis > 2) throw new ArgumentException("İndis [0, 2] arası bir integer olmalı");
                switch (indis)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        return 0;
                }
            }
            set
            {
                if (indis < 0 || indis > 2) throw new ArgumentException("İndis [0, 2] arası bir integer olmalı");
                switch (indis)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Sabit Degerler
        
        public static Vektor Sifir
        {
            get { return new Vektor(0.0f, 0.0f, 0.0f); }
        }
        
        public static Vektor xEkseni
        {
            get { return new Vektor(1.0f, 0.0f, 0.0f); }
        }

        public static Vektor yEkseni
        {
            get { return new Vektor(0.0f, 1.0f, 0.0f); }
        }
        
        public static Vektor zEkseni
        {
            get { return new Vektor(0.0f, 0.0f, 1.0f); }
        }

        #endregion

        #region Ezilenler

        public override bool Equals(object obj)
        {
            return (obj is Vektor && (Vektor)obj == this);
        }
        
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", m_X, m_Y, m_Z);
        }
        
        public override int GetHashCode()
        {
            return m_X.GetHashCode() ^ m_Y.GetHashCode() ^ m_Z.GetHashCode();
        }

        #endregion

        #region ICloneable Arayuzu Uyeleri

        public object Clone()
        {
            return new Vektor(this);
        }

        #endregion
    }
}