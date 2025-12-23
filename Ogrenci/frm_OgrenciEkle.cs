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
    public partial class frm_OgrenciEkle : Form
    {
        public frm_OgrenciEkle()
        {
            InitializeComponent();
        }

        private void frm_OgrenciEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Numara = Convert.ToInt32( txt_Numara.Text);
            ogrenci.Ad = txt_Ad.Text;
            ogrenci.Soyad = txt_Soyad.Text;

            Ogreci_CRUD _CRUD = new Ogreci_CRUD();
            _CRUD.OgrenciEkle(ogrenci);

            this.Close();
        }
    }
}
