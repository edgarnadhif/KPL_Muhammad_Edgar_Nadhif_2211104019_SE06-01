using System;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace praktikum_parsing_json
{
    class Program
    {
        static void Main(string[] args)
        {
            // Membuat objek WebClient untuk mengambil data dari internet
            using (WebClient c = new WebClient())
            {
                try
                {
                    // Mengambil data JSON dari API Blockchain.info
                    string url = "https://blockchain.info/ticker";
                    string data = c.DownloadString(url);

                    // Parsing JSON menggunakan JObject dari Newtonsoft.Json
                    JObject currencies = JObject.Parse(data);

                    // Mengambil nilai tukar USD dari JSON
                    var currency = currencies.SelectToken("USD.last");

                    // Menampilkan hasil ke console
                    Console.WriteLine("Nilai Tukar Bitcoin ke USD: " + currency);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                }
            }

            // Mencegah console langsung tertutup
            Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
            Console.ReadKey();
        }
    }
}
