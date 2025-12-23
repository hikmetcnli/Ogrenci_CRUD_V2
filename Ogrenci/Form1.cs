using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ogrenci.CRUD;

namespace Ogrenci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetListe();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            GetListe();
        }
        public void GetListe()
        {
            grid_Liste.Rows.Clear();
            Ogreci_CRUD cRUD = new Ogreci_CRUD();
            List<Ogrenci> ogrencis = cRUD.GetOgrenciListe();

            foreach (Ogrenci ogrenci in ogrencis)
            {
                grid_Liste.Rows.Add();
                grid_Liste.Rows[grid_Liste.RowCount - 1].Cells["ID"].Value = ogrenci.Id;
                grid_Liste.Rows[grid_Liste.RowCount - 1].Cells["Ad"].Value = ogrenci.Ad;
                grid_Liste.Rows[grid_Liste.RowCount - 1].Cells["Soyad"].Value = ogrenci.Soyad;
                grid_Liste.Rows[grid_Liste.RowCount - 1].Cells["Numara"].Value = ogrenci.Numara;
            }
        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            frm_OgrenciEkle frm = new frm_OgrenciEkle();
            frm.ShowDialog();
            GetListe();

        }
    }
}
