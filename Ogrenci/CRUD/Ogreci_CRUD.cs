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
        public Ogrenci GetOgrenci(int ID)
        {
            Ogrenci ogrenci = new Ogrenci();

            using (SqlConnection con = Baglanti.GetConnection())
            {
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Ogrenci WHERE ID="+ ID.ToString()+"", con);
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ogrenci WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ogrenci.Id = Convert.ToInt32(dr["ID"]);
                    ogrenci.Ad = dr["Ad"].ToString();
                    ogrenci.Soyad = dr["Soyad"].ToString();
                    ogrenci.Numara = Convert.ToInt32(dr["Numara"]);                      
                }
            }

            return ogrenci;
        }
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
        public void OgrenciGuncelle(Ogrenci ogrenci)
        {
            using (SqlConnection con = Baglanti.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Ogrenci SET Numara = @Numara, Soyad = @Soyad, Ad = @Ad  WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@Ad", ogrenci.Ad);
                cmd.Parameters.AddWithValue("@Soyad", ogrenci.Soyad);
                cmd.Parameters.AddWithValue("@Numara", ogrenci.Numara);
                cmd.Parameters.AddWithValue("@ID", ogrenci.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Öğrenci Sil
        public void OgrenciSil(int ID)
        {
            using (SqlConnection con = Baglanti.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE Ogrenci WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
