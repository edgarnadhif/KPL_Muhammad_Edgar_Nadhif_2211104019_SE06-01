using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();
        config.LoadConfig();  

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuNormal = (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                          (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5);

        bool hariDemamNormal = hariDemam < config.BatasHariDemam;

        if (suhuNormal && hariDemamNormal)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }

        Console.Write("Apakah ingin mengubah satuan suhu? (y/n): ");
        string ubah = Console.ReadLine().ToLower();
        if (ubah == "y")
        {
            config.UbahSatuan();
            config.SaveConfig();
            Console.WriteLine($"Satuan suhu sekarang: {config.SatuanSuhu}");
        }
    }
}