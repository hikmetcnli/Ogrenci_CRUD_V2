using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ogrenci.CRUD
{
    public class Ogreci_CRUD
    {

        //Öğrecileri Listele
        public List<Ogrenci> GetOgrenciListe()
        {
            List<Ogrenci> ogrencis = new List<Ogrenci>();

            using (SqlConnection con = Baglanti.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ogrenci", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    ogrencis.Add(
                        new Ogrenci
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            Ad = dr["Ad"].ToString(),
                            Soyad = dr["Soyad"].ToString(),
                            Numara = Convert.ToInt32(dr["Numara"])
                        }
                        ); 
                }

            }

            return ogrencis;
        }


        //Tek Öğreci Liste

        //Öğrenci Ekle
        public void OgrenciEkle(Ogrenci ogrenci)
        {
            using (SqlConnection con = Baglanti.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Ogrenci(Ad,Soyad,Numara) VALUES(@ad,@soyad,@numara)", con);
                cmd.Parameters.AddWithValue("@ad", ogrenci.Ad);
                cmd.Parameters.AddWithValue("@soyad", ogrenci.Soyad);
                cmd.Parameters.AddWithValue("@numara", ogrenci.Numara);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Öğrenci güncelle

        //Öğrenci Sil
    }
}
