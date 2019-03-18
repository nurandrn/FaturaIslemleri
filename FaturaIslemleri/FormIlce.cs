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
    public partial class FormIlce : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenid;
        public FormIlce()
        {
            InitializeComponent();
        }


        private void FormIlce_Load(object sender, EventArgs e)
        {
            ComboListele();
            Listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                Ilce ilce = db.Ilceler.Find(secilenid);
                textBox2.Text = ilce.Aciklama;
                comboBox1.SelectedValue = ilce.il.IlID;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = new Ilce();
                ilce.Aciklama = textBox2.Text;
                ilce.IlID = Convert.ToInt32(comboBox1.SelectedValue);
                db.Ilceler.Add(ilce);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = db.Ilceler.Find(secilenid);
                ilce.Aciklama = textBox2.Text;
                ilce.IlID= Convert.ToInt32(comboBox1.SelectedValue);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("lütfen bir ilçe seçiniz");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = db.Ilceler.Find(secilenid);
                db.Ilceler.Remove(ilce);
                db.SaveChanges();
                Listele();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Listele()
        {
            try
            {
                var list = db.Ilceler.Select(x => new
                {
                    x.IlID,
                    SehirAdi = x.il.Aciklama,
                    x.IlceId,
                    İlceAdi = x.Aciklama
                }).Where(x => x.IlID == (int)comboBox1.SelectedValue).OrderBy(x => x.SehirAdi).ToList();
                dataGridView1.DataSource = list;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                textBox2.Clear();
                //cursor ilcenin textboxına gidiyor.
                textBox2.Focus();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ComboListele()
        {
            var list = db.Iller.Select(x => new
            {
                x.IlID,
                x.Aciklama
            }).OrderBy(x => x.Aciklama).ToList();

            comboBox1.DisplayMember = "Aciklama";
            comboBox1.ValueMember = "IlID";
            comboBox1.DataSource = list;
        }

    }
}
