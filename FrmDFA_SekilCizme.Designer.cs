namespace Uygulama
{
    partial class FrmDFA_SekilCizme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnDFA_Ciz = new System.Windows.Forms.Button();
            this.BtnOynat = new System.Windows.Forms.Button();
            this.BtnDurdur = new System.Windows.Forms.Button();
            this.BtnAdimAdim = new System.Windows.Forms.Button();
            this.lblGirdi = new System.Windows.Forms.Label();
            this.lblOkunan = new System.Windows.Forms.Label();
            this.Zamanlayici = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BtnDFA_Ciz
            // 
            this.BtnDFA_Ciz.BackColor = System.Drawing.Color.Yellow;
            this.BtnDFA_Ciz.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.BtnDFA_Ciz.Location = new System.Drawing.Point(-1, 459);
            this.BtnDFA_Ciz.Name = "BtnDFA_Ciz";
            this.BtnDFA_Ciz.Size = new System.Drawing.Size(802, 48);
            this.BtnDFA_Ciz.TabIndex = 17;
            this.BtnDFA_Ciz.Text = "Kabul Edilen Girdiden Sonra DFA Şeklini Çiz";
            this.BtnDFA_Ciz.UseVisualStyleBackColor = false;
            this.BtnDFA_Ciz.Click += new System.EventHandler(this.BtnDFA_Ciz_Click);
            // 
            // BtnOynat
            // 
            this.BtnOynat.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOynat.Enabled = false;
            this.BtnOynat.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.BtnOynat.Location = new System.Drawing.Point(537, 414);
            this.BtnOynat.Name = "BtnOynat";
            this.BtnOynat.Size = new System.Drawing.Size(264, 49);
            this.BtnOynat.TabIndex = 17;
            this.BtnOynat.Text = "OYNAT";
            this.BtnOynat.UseVisualStyleBackColor = false;
            this.BtnOynat.Click += new System.EventHandler(this.BtnOynat_Click);
            // 
            // BtnDurdur
            // 
            this.BtnDurdur.BackColor = System.Drawing.Color.Red;
            this.BtnDurdur.Enabled = false;
            this.BtnDurdur.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.BtnDurdur.Location = new System.Drawing.Point(262, 414);
            this.BtnDurdur.Name = "BtnDurdur";
            this.BtnDurdur.Size = new System.Drawing.Size(277, 49);
            this.BtnDurdur.TabIndex = 17;
            this.BtnDurdur.Text = "DURDUR";
            this.BtnDurdur.UseVisualStyleBackColor = false;
            this.BtnDurdur.Click += new System.EventHandler(this.BtnDurdur_Click);
            // 
            // BtnAdimAdim
            // 
            this.BtnAdimAdim.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAdimAdim.Enabled = false;
            this.BtnAdimAdim.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.BtnAdimAdim.Location = new System.Drawing.Point(-1, 414);
            this.BtnAdimAdim.Name = "BtnAdimAdim";
            this.BtnAdimAdim.Size = new System.Drawing.Size(265, 49);
            this.BtnAdimAdim.TabIndex = 17;
            this.BtnAdimAdim.Text = "ADIM ADIM";
            this.BtnAdimAdim.UseVisualStyleBackColor = false;
            this.BtnAdimAdim.Click += new System.EventHandler(this.BtnAdimAdim_Click);
            // 
            // lblGirdi
            // 
            this.lblGirdi.AutoSize = true;
            this.lblGirdi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGirdi.Location = new System.Drawing.Point(12, 331);
            this.lblGirdi.Name = "lblGirdi";
            this.lblGirdi.Size = new System.Drawing.Size(64, 30);
            this.lblGirdi.TabIndex = 23;
            this.lblGirdi.Text = "Girdi:";
            // 
            // lblOkunan
            // 
            this.lblOkunan.AutoSize = true;
            this.lblOkunan.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkunan.Location = new System.Drawing.Point(12, 372);
            this.lblOkunan.Name = "lblOkunan";
            this.lblOkunan.Size = new System.Drawing.Size(98, 30);
            this.lblOkunan.TabIndex = 23;
            this.lblOkunan.Text = "Okunan: ";
            // 
            // Zamanlayici
            // 
            this.Zamanlayici.Tick += new System.EventHandler(this.Zamanlayici_Tick);
            // 
            // FrmDFA_SekilCizme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.lblOkunan);
            this.Controls.Add(this.lblGirdi);
            this.Controls.Add(this.BtnAdimAdim);
            this.Controls.Add(this.BtnDurdur);
            this.Controls.Add(this.BtnOynat);
            this.Controls.Add(this.BtnDFA_Ciz);
            this.Name = "FrmDFA_SekilCizme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biçimsel Diller ve Otomata Teorisi | DFA Çizme";
            this.Load += new System.EventHandler(this.FrmDFA_SekilCizme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDFA_Ciz;
        private System.Windows.Forms.Button BtnOynat;
        private System.Windows.Forms.Button BtnDurdur;
        private System.Windows.Forms.Button BtnAdimAdim;
        private System.Windows.Forms.Label lblGirdi;
        private System.Windows.Forms.Label lblOkunan;
        private System.Windows.Forms.Timer Zamanlayici;
    }
}