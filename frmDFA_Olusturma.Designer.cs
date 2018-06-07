namespace Uygulama
{
    partial class FrmDFA_Olusturma
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDurumSayisi = new System.Windows.Forms.Label();
            this.lblBaslangicDurumu = new System.Windows.Forms.Label();
            this.lblKabulDurumu = new System.Windows.Forms.Label();
            this.nudDurumSayisi = new System.Windows.Forms.NumericUpDown();
            this.txtKabulDurumu = new System.Windows.Forms.TextBox();
            this.txtBaslangicDurumu = new System.Windows.Forms.TextBox();
            this.lblGirdiler = new System.Windows.Forms.Label();
            this.txtGirdiler = new System.Windows.Forms.TextBox();
            this.BtnDFA_Yapisi = new System.Windows.Forms.Button();
            this.txtDFA_Tanimlama = new System.Windows.Forms.RichTextBox();
            this.BtnDFA_Tanimlama = new System.Windows.Forms.Button();
            this.txtIstenilenGirdi = new System.Windows.Forms.TextBox();
            this.BtnGirdiKabulu = new System.Windows.Forms.Button();
            this.txtKabulSonucu = new System.Windows.Forms.RichTextBox();
            this.BtnDFACizmeEkrani = new System.Windows.Forms.Button();
            this.lblIstenenGirdi = new System.Windows.Forms.Label();
            this.lblDFA_Baslik = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCizgi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurumSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDurumSayisi
            // 
            this.lblDurumSayisi.AutoSize = true;
            this.lblDurumSayisi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurumSayisi.Location = new System.Drawing.Point(43, 76);
            this.lblDurumSayisi.Name = "lblDurumSayisi";
            this.lblDurumSayisi.Size = new System.Drawing.Size(87, 17);
            this.lblDurumSayisi.TabIndex = 0;
            this.lblDurumSayisi.Text = "Durum Sayısı";
            // 
            // lblBaslangicDurumu
            // 
            this.lblBaslangicDurumu.AutoSize = true;
            this.lblBaslangicDurumu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslangicDurumu.Location = new System.Drawing.Point(43, 112);
            this.lblBaslangicDurumu.Name = "lblBaslangicDurumu";
            this.lblBaslangicDurumu.Size = new System.Drawing.Size(118, 17);
            this.lblBaslangicDurumu.TabIndex = 0;
            this.lblBaslangicDurumu.Text = "Başlangıç Durumu";
            // 
            // lblKabulDurumu
            // 
            this.lblKabulDurumu.AutoSize = true;
            this.lblKabulDurumu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKabulDurumu.Location = new System.Drawing.Point(43, 149);
            this.lblKabulDurumu.Name = "lblKabulDurumu";
            this.lblKabulDurumu.Size = new System.Drawing.Size(96, 17);
            this.lblKabulDurumu.TabIndex = 0;
            this.lblKabulDurumu.Text = "Kabul Durumu";
            // 
            // nudDurumSayisi
            // 
            this.nudDurumSayisi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.nudDurumSayisi.Location = new System.Drawing.Point(165, 72);
            this.nudDurumSayisi.Name = "nudDurumSayisi";
            this.nudDurumSayisi.Size = new System.Drawing.Size(67, 25);
            this.nudDurumSayisi.TabIndex = 2;
            this.nudDurumSayisi.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtKabulDurumu
            // 
            this.txtKabulDurumu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtKabulDurumu.Location = new System.Drawing.Point(165, 145);
            this.txtKabulDurumu.Name = "txtKabulDurumu";
            this.txtKabulDurumu.Size = new System.Drawing.Size(67, 25);
            this.txtKabulDurumu.TabIndex = 15;
            this.txtKabulDurumu.Text = "q4";
            // 
            // txtBaslangicDurumu
            // 
            this.txtBaslangicDurumu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtBaslangicDurumu.Location = new System.Drawing.Point(165, 108);
            this.txtBaslangicDurumu.Name = "txtBaslangicDurumu";
            this.txtBaslangicDurumu.Size = new System.Drawing.Size(67, 25);
            this.txtBaslangicDurumu.TabIndex = 14;
            this.txtBaslangicDurumu.Text = "q0";
            // 
            // lblGirdiler
            // 
            this.lblGirdiler.AutoSize = true;
            this.lblGirdiler.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGirdiler.Location = new System.Drawing.Point(43, 185);
            this.lblGirdiler.Name = "lblGirdiler";
            this.lblGirdiler.Size = new System.Drawing.Size(51, 17);
            this.lblGirdiler.TabIndex = 0;
            this.lblGirdiler.Text = "Girdiler";
            // 
            // txtGirdiler
            // 
            this.txtGirdiler.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtGirdiler.Location = new System.Drawing.Point(165, 181);
            this.txtGirdiler.Name = "txtGirdiler";
            this.txtGirdiler.Size = new System.Drawing.Size(67, 25);
            this.txtGirdiler.TabIndex = 15;
            this.txtGirdiler.Text = "0, 1";
            // 
            // BtnDFA_Yapisi
            // 
            this.BtnDFA_Yapisi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDFA_Yapisi.Location = new System.Drawing.Point(46, 225);
            this.BtnDFA_Yapisi.Name = "BtnDFA_Yapisi";
            this.BtnDFA_Yapisi.Size = new System.Drawing.Size(186, 31);
            this.BtnDFA_Yapisi.TabIndex = 16;
            this.BtnDFA_Yapisi.Text = "Yapıyı Oluştur";
            this.BtnDFA_Yapisi.UseVisualStyleBackColor = true;
            this.BtnDFA_Yapisi.Click += new System.EventHandler(this.BtnDFA_Yapisi_Click);
            // 
            // txtDFA_Tanimlama
            // 
            this.txtDFA_Tanimlama.Enabled = false;
            this.txtDFA_Tanimlama.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtDFA_Tanimlama.Location = new System.Drawing.Point(289, 68);
            this.txtDFA_Tanimlama.Name = "txtDFA_Tanimlama";
            this.txtDFA_Tanimlama.Size = new System.Drawing.Size(450, 143);
            this.txtDFA_Tanimlama.TabIndex = 17;
            this.txtDFA_Tanimlama.Text = "";
            // 
            // BtnDFA_Tanimlama
            // 
            this.BtnDFA_Tanimlama.Enabled = false;
            this.BtnDFA_Tanimlama.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDFA_Tanimlama.Location = new System.Drawing.Point(391, 225);
            this.BtnDFA_Tanimlama.Name = "BtnDFA_Tanimlama";
            this.BtnDFA_Tanimlama.Size = new System.Drawing.Size(250, 31);
            this.BtnDFA_Tanimlama.TabIndex = 16;
            this.BtnDFA_Tanimlama.Text = "Oluşturulan Yapıyı Tanımla";
            this.BtnDFA_Tanimlama.UseVisualStyleBackColor = true;
            this.BtnDFA_Tanimlama.Click += new System.EventHandler(this.BtnDFA_Tanimlama_Click);
            // 
            // txtIstenilenGirdi
            // 
            this.txtIstenilenGirdi.Enabled = false;
            this.txtIstenilenGirdi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtIstenilenGirdi.Location = new System.Drawing.Point(148, 305);
            this.txtIstenilenGirdi.Name = "txtIstenilenGirdi";
            this.txtIstenilenGirdi.Size = new System.Drawing.Size(117, 25);
            this.txtIstenilenGirdi.TabIndex = 15;
            this.txtIstenilenGirdi.Text = "10100";
            // 
            // BtnGirdiKabulu
            // 
            this.BtnGirdiKabulu.Enabled = false;
            this.BtnGirdiKabulu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnGirdiKabulu.Location = new System.Drawing.Point(289, 302);
            this.BtnGirdiKabulu.Name = "BtnGirdiKabulu";
            this.BtnGirdiKabulu.Size = new System.Drawing.Size(450, 31);
            this.BtnGirdiKabulu.TabIndex = 16;
            this.BtnGirdiKabulu.Text = "İstenen Girdinin Kabul Edilip Edilmeyeceğini Öğrenin";
            this.BtnGirdiKabulu.UseVisualStyleBackColor = true;
            this.BtnGirdiKabulu.Click += new System.EventHandler(this.BtnGirdiKabulu_Click);
            // 
            // txtKabulSonucu
            // 
            this.txtKabulSonucu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtKabulSonucu.Location = new System.Drawing.Point(46, 357);
            this.txtKabulSonucu.Name = "txtKabulSonucu";
            this.txtKabulSonucu.ReadOnly = true;
            this.txtKabulSonucu.Size = new System.Drawing.Size(693, 251);
            this.txtKabulSonucu.TabIndex = 17;
            this.txtKabulSonucu.Text = "";
            // 
            // BtnDFACizmeEkrani
            // 
            this.BtnDFACizmeEkrani.Enabled = false;
            this.BtnDFACizmeEkrani.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDFACizmeEkrani.Location = new System.Drawing.Point(191, 627);
            this.BtnDFACizmeEkrani.Name = "BtnDFACizmeEkrani";
            this.BtnDFACizmeEkrani.Size = new System.Drawing.Size(404, 31);
            this.BtnDFACizmeEkrani.TabIndex = 16;
            this.BtnDFACizmeEkrani.Text = "İstenilen Girdi Kabul Edildiğine Göre, DFA\'yı Çizin";
            this.BtnDFACizmeEkrani.UseVisualStyleBackColor = true;
            this.BtnDFACizmeEkrani.Click += new System.EventHandler(this.BtnDFACizmeEkrani_Click);
            // 
            // lblIstenenGirdi
            // 
            this.lblIstenenGirdi.AutoSize = true;
            this.lblIstenenGirdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIstenenGirdi.Location = new System.Drawing.Point(43, 309);
            this.lblIstenenGirdi.Name = "lblIstenenGirdi";
            this.lblIstenenGirdi.Size = new System.Drawing.Size(85, 17);
            this.lblIstenenGirdi.TabIndex = 0;
            this.lblIstenenGirdi.Text = "İstenen Girdi";
            // 
            // lblDFA_Baslik
            // 
            this.lblDFA_Baslik.AutoSize = true;
            this.lblDFA_Baslik.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDFA_Baslik.Location = new System.Drawing.Point(289, 19);
            this.lblDFA_Baslik.Name = "lblDFA_Baslik";
            this.lblDFA_Baslik.Size = new System.Drawing.Size(0, 0);
            this.lblDFA_Baslik.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "DFA Tanımlama ve Oluşturma";
            // 
            // lblCizgi
            // 
            this.lblCizgi.AutoSize = true;
            this.lblCizgi.Location = new System.Drawing.Point(-9, 267);
            this.lblCizgi.Name = "lblCizgi";
            this.lblCizgi.Size = new System.Drawing.Size(827, 13);
            this.lblCizgi.TabIndex = 18;
            this.lblCizgi.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "___";
            // 
            // FrmDFA_Olusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 672);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDFA_Baslik);
            this.Controls.Add(this.lblCizgi);
            this.Controls.Add(this.txtKabulSonucu);
            this.Controls.Add(this.txtDFA_Tanimlama);
            this.Controls.Add(this.BtnDFACizmeEkrani);
            this.Controls.Add(this.BtnGirdiKabulu);
            this.Controls.Add(this.BtnDFA_Tanimlama);
            this.Controls.Add(this.BtnDFA_Yapisi);
            this.Controls.Add(this.txtIstenilenGirdi);
            this.Controls.Add(this.txtGirdiler);
            this.Controls.Add(this.txtKabulDurumu);
            this.Controls.Add(this.txtBaslangicDurumu);
            this.Controls.Add(this.lblIstenenGirdi);
            this.Controls.Add(this.lblGirdiler);
            this.Controls.Add(this.nudDurumSayisi);
            this.Controls.Add(this.lblKabulDurumu);
            this.Controls.Add(this.lblBaslangicDurumu);
            this.Controls.Add(this.lblDurumSayisi);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmDFA_Olusturma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biçimsel Diller ve Otomata Teorisi | DFA Oluşturma";
            this.Load += new System.EventHandler(this.FrmDFA_Olusturma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDurumSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDurumSayisi;
        private System.Windows.Forms.Label lblBaslangicDurumu;
        private System.Windows.Forms.Label lblKabulDurumu;
        private System.Windows.Forms.NumericUpDown nudDurumSayisi;
        private System.Windows.Forms.TextBox txtKabulDurumu;
        private System.Windows.Forms.TextBox txtBaslangicDurumu;
        private System.Windows.Forms.Label lblGirdiler;
        private System.Windows.Forms.TextBox txtGirdiler;
        private System.Windows.Forms.Button BtnDFA_Yapisi;
        private System.Windows.Forms.RichTextBox txtDFA_Tanimlama;
        private System.Windows.Forms.Button BtnDFA_Tanimlama;
        private System.Windows.Forms.TextBox txtIstenilenGirdi;
        private System.Windows.Forms.Button BtnGirdiKabulu;
        private System.Windows.Forms.RichTextBox txtKabulSonucu;
        private System.Windows.Forms.Button BtnDFACizmeEkrani;
        private System.Windows.Forms.Label lblIstenenGirdi;
        private MetroFramework.Controls.MetroLabel lblDFA_Baslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCizgi;
    }
}

