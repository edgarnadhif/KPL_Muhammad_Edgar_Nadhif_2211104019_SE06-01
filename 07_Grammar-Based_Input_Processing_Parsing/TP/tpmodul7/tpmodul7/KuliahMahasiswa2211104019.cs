using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class KuliahMahasiswa2211104019
{
    public class MataKuliah
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class KuliahData
    {
        public List<MataKuliah> courses { get; set; }
    }

    public static void ReadJSON()
    {
        string filePath = "tp7_2_2211104019.json";  // Pastikan sesuai dengan nama file JSON
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            KuliahData kuliah = JsonConvert.DeserializeObject<KuliahData>(jsonData);

            Console.WriteLine("Daftar mata kuliah yang diambil:");
            int count = 1;
            foreach (var mk in kuliah.courses)
            {
                Console.WriteLine($"MK {count} {mk.code} - {mk.name}");
                count++;
            }
        }
        else
        {
            Console.WriteLine("File JSON tidak ditemukan!");
        }
    }
}
