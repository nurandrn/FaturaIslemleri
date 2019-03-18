using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturaIslemleri
{
    public partial class FormYeniFatura : Form
    {
        public FormYeniFatura()
        {
            InitializeComponent();
        }
        FaturaContext db = new FaturaContext();
        int secilenID;
        List<UrunSecilen> urunListesi = new List<UrunSecilen>();

        private void FormYeniFatura_Load(object sender, EventArgs e)
        {
            MusteriSehirDoldur();
            UrunDoldur();
        }
        private void MusteriSehirDoldur()
        {
            var list = db.Iller.ToList();
            cmbMusterisehri.DisplayMember = "Aciklama";
            cmbMusterisehri.ValueMember = "IlID";
            cmbMusterisehri.DataSource = list;
        }
        private void IlceDoldur()
        {
            var list = db.Ilceler.Where(x => x.IlID == (int)cmbMusterisehri.SelectedValue).ToList();
            cmbMusterilcesi.DisplayMember = "Aciklama";
            cmbMusterilcesi.ValueMember = "IlceID";
            cmbMusterilcesi.DataSource = list;
        }
            private void MusteriDoldur()
        {
            var mlist = db.Musteriler.Select(x => new
            {
                x.IlceID,
                x.MusteriID,
                x.MusteriUnvani
            }).Where(x => x.IlceID == (int)cmbMusterilcesi.SelectedValue).OrderBy(x => x.MusteriUnvani).ToList();
            if (mlist.Count != 0)
            {
                cmbMusteri.DisplayMember = "MusteriUnvani";
                cmbMusteri.ValueMember = "MusteriID";
                cmbMusteri.DataSource = mlist;
            }
            else
            {
                cmbMusteri.DataSource = null;
            }

        }
        private void UrunDoldur()
        {
            var ulist = db.Urunler.Select(x => new
            {
                x.UrunId,
                x.UrunAdi
            }).OrderBy(x => x.UrunAdi).ToList();
            cmbUrunAdi.DisplayMember = "UrunAdi";
            cmbUrunAdi.ValueMember = "UrunID";
            cmbUrunAdi.DataSource = ulist;
        }
        private void Listele()
        {
            dataGridView1.DataSource = urunListesi.Select(x => new
            {
                x.UrunId,
                x.UrunAdi,
                x.UrunFiyat,
                x.Miktar,
                x.KDV,
                x.ToplamTutar,
                GenelToplam = x.ToplamTutar + x.ToplamTutar * x.KDV
            }).ToList();
            dataGridView1.Columns[0].Visible = false;
            Temizle();
            FaturaToplam();
        }
        private void Temizle()
        {
            nudUrunMiktari.Value = 0;
        }
        private void FaturaToplam()
        {
            decimal toplam = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                toplam += Convert.ToDecimal(dataGridView1[6, i].Value);
            }
            lblFaturaToplam.Text = Convert.ToString(String.Format("{0:0.00}", toplam + "TL"));
            toplam = Math.Round(toplam, 2);

        }

        private void cmbMusterisehri_SelectedIndexChanged(object sender, EventArgs e)
        {
            IlceDoldur();
        }

        private void cmbMusterilcesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            MusteriDoldur();
        }

        private void cmbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            decimal fiyat = db.Urunler.Find((int)cmbUrunAdi.SelectedValue).BirimFiyat;
            txtUrunFiyati.Text = fiyat.ToString();
            string birim = db.Urunler.Find((int)cmbUrunAdi.SelectedValue).birim.BirimAdi;
            txtUrunFiyati.Text = birim;
            txtUrunKDV.Text = "0,18";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var urun = urunListesi.Where(x => x.UrunId == secilenID).FirstOrDefault();
            cmbUrunAdi.SelectedValue = secilenID;
            nudUrunMiktari.Value = urun.Miktar;

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            urunListesi.Add(new UrunSecilen
            {
                UrunId = (int)cmbUrunAdi.SelectedValue,
                UrunAdi = cmbUrunAdi.Text,
                UrunFiyat = Convert.ToDecimal(txtUrunFiyati.Text),
                KDV = Convert.ToDecimal(txtUrunKDV.Text),
                Miktar = (decimal)nudUrunMiktari.Value,
                ToplamTutar = Convert.ToDecimal(txtUrunFiyati.Text) * (decimal)nudUrunMiktari.Value
            });
            Listele();
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var urun = urunListesi.Where(x => x.UrunId == secilenID).FirstOrDefault();
                if (secilenID == (int)cmbUrunAdi.SelectedValue)
                {
                    urun.Miktar = (decimal)nudUrunMiktari.Value;
                    urun.ToplamTutar = Convert.ToDecimal(txtUrunFiyati.Text) * (decimal)nudUrunMiktari.Value;
                }
                else
                {
                    urun.UrunId = (int)cmbUrunAdi.SelectedValue;
                    urun.UrunAdi = cmbUrunAdi.Text;
                    urun.UrunFiyat = Convert.ToDecimal(txtUrunFiyati.Text);
                    urun.Miktar = (decimal)nudUrunMiktari.Value;
                    urun.ToplamTutar = Convert.ToDecimal(txtUrunFiyati.Text) * (decimal)nudUrunMiktari.Value;
                }
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen listeden ürün seçiniz..");
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            try
            {
                var urun = urunListesi.Where(x => x.UrunId == secilenID).FirstOrDefault();
                urunListesi.Remove(urun);
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen listeden ürün seçiniz..");
            }
        }

        private void btnFaturaKaydet_Click(object sender, EventArgs e)
        {
            DbContextTransaction tran = db.Database.BeginTransaction();//yapıldığında kontrol bizdedir.
         
                FaturaKaydet();
                FaturaDetayKaydet();
                tran.Commit(); // ten sonra rollback yapılmaz.
          
                tran.Rollback();
                MessageBox.Show("Beklenmeyen bir hata oluştu..");
            
        }
            private void FaturaKaydet()
            {

                FaturaMaster fm = new FaturaMaster();
                fm.IrsaliyeNo = Convert.ToInt32(txtIrsaliye.Text);
                fm.OdemeTarihi = dtpOdemeTarihi.Value;
                fm.MusteriID = (int)cmbMusteri.SelectedValue;
                db.FaturaMasters.Add(fm);
                db.SaveChanges();
                lblFaturaID.Text = fm.FaturaID.ToString();
            }
        private void FaturaDetayKaydet()
        {
            foreach (UrunSecilen item in urunListesi)
            {
                FaturaDetay fd = new FaturaDetay();
                fd.FaturaID = Convert.ToInt32(lblFaturaID.Text);
                fd.UrunID = item.UrunId;
                fd.Miktar = item.Miktar;
                fd.KDV = item.KDV;
                fd.ToplamFiyat = item.Miktar * item.UrunFiyat;
                fd.KDVliFiyat = fd.ToplamFiyat + fd.ToplamFiyat * fd.KDV;
                fd.FaturaToplam = Convert.ToDecimal(lblFaturaToplam.Text.Substring(0, lblFaturaToplam.Text.Length - 2));
                db.FaturaDetays.Add(fd);
            }
            db.SaveChanges();
            MessageBox.Show("Ürünler başarılı bir şekilde faturaya eklendi.\nFatura kayıt edildi");
        }

        private void btnListeTemzile_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            urunListesi.Clear();
        }
    }
}
