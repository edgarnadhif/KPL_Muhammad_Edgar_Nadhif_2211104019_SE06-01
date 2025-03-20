using System;
using System.IO;
using Newtonsoft.Json;

public class DataMahasiswa2211104019
{
    public Nama nama { get; set; }
    public string nim { get; set; }
    public string fakultas { get; set; }
    public class Nama
    {
        public string depan { get; set; }
        public string belakang { get; set; }
    }
    public static void ReadJSON()
    {
        string filePath = "tp7_1_2211104019.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            DataMahasiswa2211104019 mahasiswa = JsonConvert.DeserializeObject<DataMahasiswa2211104019>(jsonData);
            Console.WriteLine($"Nama {mahasiswa.nama.depan} {mahasiswa.nama.belakang} dengan nim {mahasiswa.nim} dari fakultas {mahasiswa.fakultas}");
        }
        else
        {
            Console.WriteLine("File JSON tidak ditemukan.");
        }
    }
}

//class Program
//{
//    static void Main()
//    {
//        DataMahasiswa2211104019.ReadJSON();
//    }
//}
