namespace FaturaIslemleri
{
    partial class FormUrun
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
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.lblBirimfiyatı = new System.Windows.Forms.Label();
            this.txtBirimFiyatı = new System.Windows.Forms.TextBox();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.lblBirimAdi = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.comboBirimAdi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(26, 28);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(48, 13);
            this.lblUrunAdi.TabIndex = 0;
            this.lblUrunAdi.Text = "Ürün Adi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(418, 214);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(26, 80);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(58, 13);
            this.lblUrunKodu.TabIndex = 0;
            this.lblUrunKodu.Text = "Ürün Kodu";
            // 
            // lblBirimfiyatı
            // 
            this.lblBirimfiyatı.AutoSize = true;
            this.lblBirimfiyatı.Location = new System.Drawing.Point(267, 80);
            this.lblBirimfiyatı.Name = "lblBirimfiyatı";
            this.lblBirimfiyatı.Size = new System.Drawing.Size(56, 13);
            this.lblBirimfiyatı.TabIndex = 0;
            this.lblBirimfiyatı.Text = "Birim Fiyatı";
            // 
            // txtBirimFiyatı
            // 
            this.txtBirimFiyatı.Location = new System.Drawing.Point(326, 77);
            this.txtBirimFiyatı.Name = "txtBirimFiyatı";
            this.txtBirimFiyatı.Size = new System.Drawing.Size(121, 20);
            this.txtBirimFiyatı.TabIndex = 2;
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(89, 28);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(121, 20);
            this.txtUrunAdi.TabIndex = 2;
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(89, 73);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(121, 20);
            this.txtUrunKodu.TabIndex = 2;
            // 
            // lblBirimAdi
            // 
            this.lblBirimAdi.AutoSize = true;
            this.lblBirimAdi.Location = new System.Drawing.Point(267, 28);
            this.lblBirimAdi.Name = "lblBirimAdi";
            this.lblBirimAdi.Size = new System.Drawing.Size(47, 13);
            this.lblBirimAdi.TabIndex = 0;
            this.lblBirimAdi.Text = "Birim Adi";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(29, 144);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(199, 144);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 3;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(372, 144);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // comboBirimAdi
            // 
            this.comboBirimAdi.FormattingEnabled = true;
            this.comboBirimAdi.Location = new System.Drawing.Point(326, 27);
            this.comboBirimAdi.Name = "comboBirimAdi";
            this.comboBirimAdi.Size = new System.Drawing.Size(121, 21);
            this.comboBirimAdi.TabIndex = 4;
            this.comboBirimAdi.SelectedIndexChanged += new System.EventHandler(this.comboBirimAdi_SelectedIndexChanged);
            // 
            // FormUrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.comboBirimAdi);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtUrunKodu);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.txtBirimFiyatı);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblBirimAdi);
            this.Controls.Add(this.lblBirimfiyatı);
            this.Controls.Add(this.lblUrunKodu);
            this.Controls.Add(this.lblUrunAdi);
            this.Name = "FormUrun";
            this.Text = "FormUrun";
            this.Load += new System.EventHandler(this.FormUrun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.Label lblBirimfiyatı;
        private System.Windows.Forms.TextBox txtBirimFiyatı;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label lblBirimAdi;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ComboBox comboBirimAdi;
    }
}