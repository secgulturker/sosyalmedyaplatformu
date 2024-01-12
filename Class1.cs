using System;
using System.Data;
using System.Data.SqlClient; // MySQL için MySQL.Data kullanılmalı
using MySql.Data.MySqlClient;

namespace VeriUygulamasi
{
    public class VeritabaniIslemleri
    {
        private MySqlConnection connection;
        private string connectionString = "Server=server_adresi;Database=sosyalmedyaplatformu;Uid=kullanici_adı;Pwd=sifre;";

        public VeritabaniIslemleri()
        {
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bağlantı Hatası: {ex.Message}");
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kapatma Hatası: {ex.Message}");
                return false;
            }
        }

        // Kullanıcı Ekleme Metodu
        public void KullaniciEkle(string id, string ad, string soyad, string tel, string mail)
        {
            try
            {
                OpenConnection();

                string query = "CALL KullaniciEkle(@id, @ad, @soyad, @tel, @mail)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@tel", tel);
                cmd.Parameters.AddWithValue("@mail", mail);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Kullanıcı başarıyla eklendi.");

                CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }

        // Paylaşım Ekleme Metodu
        public void PaylasimEkle(string id, string icerik, string paylasimtarihisaati)
        {
            try
            {
                OpenConnection();

                string query = "CALL PaylasimEkle(@id, @icerik, @paylasimtarihisaati)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@icerik", icerik);
                cmd.Parameters.AddWithValue("@paylasimtarihisaati", paylasimtarihisaati);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Paylaşım başarıyla eklendi.");

                CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
