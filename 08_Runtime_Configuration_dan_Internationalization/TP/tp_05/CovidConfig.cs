using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class CovidConfig
{
    private const string FilePath = "covid_config.json";

    public string SatuanSuhu { get; set; }
    public int BatasHariDemam { get; set; }
    public string PesanDitolak { get; set; }
    public string PesanDiterima { get; set; }

    public CovidConfig()
    {
        SatuanSuhu = "celcius";
        BatasHariDemam = 14;
        PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    }

    public void LoadConfig()
    {
        if (File.Exists(FilePath))
        {
            string jsonData = File.ReadAllText(FilePath);
            var config = JsonConvert.DeserializeObject<CovidConfig>(jsonData);
            SatuanSuhu = config.SatuanSuhu;
            BatasHariDemam = config.BatasHariDemam;
            PesanDitolak = config.PesanDitolak;
            PesanDiterima = config.PesanDiterima;
        }
        else
        {
            SaveConfig(); 
        }
    }

    public void SaveConfig()
    {
        string jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(FilePath, jsonData);
    }

    public void UbahSatuan()
    {
        SatuanSuhu = (SatuanSuhu == "celcius") ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}