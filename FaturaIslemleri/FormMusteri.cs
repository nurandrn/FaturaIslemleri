using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturaIslemleri
{
    public partial class FormMusteri : Form
    {
        public FormMusteri()
        {
            InitializeComponent();
        }
        FaturaContext db = new FaturaContext();
        int secilenID;
        private void FormMusteri_Load(object sender, EventArgs e)
        {
            ilDoldur();
            Listele();
        }
        private void ilDoldur()
        {
            var list = db.Iller.Select(x => new
            {
                x.IlID,
                x.Aciklama

            }).OrderBy(x => x.Aciklama).ToList();
            comboMusteriSehri.DisplayMember = "Aciklama";
            comboMusteriSehri.ValueMember = "IlID";
            comboMusteriSehri.DataSource = list;
        }

        private void ilceDoldur()
        {
            var list = db.Ilceler.Select(x => new
            {
                x.IlID,
                x.IlceId,
                x.Aciklama

            }).OrderBy(x => x.Aciklama).Where(x => x.IlID == (int)comboMusteriSehri.SelectedValue).ToList();
            comboMusteriSehri.DisplayMember = "Aciklama";
            comboMusteriİlcesi.ValueMember = "IlceID";
            comboMusteriİlcesi.DataSource = list;
        }

        private void Listele()
        {
            var mlist = db.Musteriler.Select(x => new
            {
                MusteriKodu = x.MusteriID,
                x.MusteriUnvani,
                SehirAdi = x.ilce.il.Aciklama,
                IlceAdi = x.ilce.Aciklama,
                x.MusteriAdresi

            }).ToList();
            dataGridView1.DataSource = mlist;

            //txtMusteriAdresi.Clear();
            txtMusteriUnvani.Clear();
            txtMusteriUnvani.Focus();
        }

        private void comboMusteriSehri_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilceDoldur();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.MusteriUnvani = txtMusteriUnvani.Text;
            musteri.MusteriAdresi = txtMusteriAdresi.Text;
            musteri.IlceID = (int)comboMusteriİlcesi.SelectedValue;
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri musteri = db.Musteriler.Find(secilenID);
                musteri.MusteriUnvani = txtMusteriUnvani.Text;
                musteri.MusteriAdresi = txtMusteriAdresi.Text;
                musteri.IlceID = (int)comboMusteriİlcesi.SelectedValue;
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri musteri = db.Musteriler.Find(secilenID);
                db.Musteriler.Remove(musteri);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                Musteri musteri = db.Musteriler.Find(secilenID);
                txtMusteriUnvani.Text = musteri.MusteriUnvani;
                txtMusteriAdresi.Text = musteri.MusteriAdresi;
                comboMusteriSehri.SelectedValue = musteri.ilce.IlID;
                comboMusteriİlcesi.SelectedValue = musteri.IlceID;
            }
            catch
            {

            }
        }

        private void comboMusteriİlcesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilDoldur();
        }
    }
}
