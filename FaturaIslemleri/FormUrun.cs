using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FaturaIslemleri.FaturaContext;

namespace FaturaIslemleri
{
    public partial class FormUrun : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenID;

        public FormUrun()
        {
            InitializeComponent();
        }

        private void FormUrun_Load(object sender, EventArgs e)
        {
            BirimListele();
            Listele();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
           // Birim birim = new Birim();
            urun.UrunAdi = txtUrunAdi.Text;
            urun.UrunKodu = Convert.ToInt32(txtUrunKodu.Text);
            urun.BirimID = Convert.ToInt32(comboBirimAdi.SelectedValue);
            //urun.birim.BirimAdi = comboBirimAdi.Text;
            urun.BirimFiyat = Convert.ToDecimal(txtBirimFiyatı.Text);
            db.Urunler.Add(urun);
            db.SaveChanges();
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Urun urun = db.Urunler.Find(secilenID);
            urun.UrunAdi = txtUrunAdi.Text;
            urun.UrunKodu =Convert.ToInt32(txtUrunKodu.Text);
            urun.BirimFiyat = Convert.ToDecimal(txtBirimFiyatı.Text);
            urun.BirimID = Convert.ToInt32(comboBirimAdi.SelectedValue);
            comboBirimAdi.Text = urun.birim.BirimAdi;
            db.SaveChanges();
            Listele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Urun Urunsil = db.Urunler.Find(secilenID);
            db.Urunler.Remove(Urunsil);
            db.SaveChanges();
            Listele();

        }

        private void Listele()
        {
            var list = db.Urunler.Select(x => new
            {
                x.UrunId,
                x.UrunKodu,
                x.UrunAdi,
                BirimAdi = x.birim.BirimAdi,
                x.BirimFiyat
            }).ToList();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;

        }

        private void BirimListele()
        {
            var blist = db.Birimler.Select(x => new
            {
                x.BirimID,
                x.BirimAdi,
            }).OrderBy(x => x.BirimAdi).ToList();
            comboBirimAdi.DisplayMember = "BirimAdi";
            comboBirimAdi.ValueMember = "BirimID";
            comboBirimAdi.DataSource = blist;

            txtUrunAdi.Clear();
            txtUrunAdi.Focus();
            txtUrunKodu.Clear();
            txtBirimFiyatı.Clear();

        }

        private void comboBirimAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            BirimListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            secilenID =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Urun urun = db.Urunler.Find(secilenID);
            txtUrunAdi.Text = urun.UrunAdi;
            txtUrunKodu.Text =urun.UrunKodu.ToString();
            comboBirimAdi.SelectedValue = urun.BirimID;
            txtBirimFiyatı.Text=urun.BirimFiyat.ToString();

        }
    }
}
