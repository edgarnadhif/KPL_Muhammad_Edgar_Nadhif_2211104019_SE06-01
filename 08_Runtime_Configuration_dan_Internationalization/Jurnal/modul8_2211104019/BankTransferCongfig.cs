using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class BankTransferConfig
{
    public string Lang { get; set; }
    public Transfer Transfer { get; set; }
    public List<string> Methods { get; set; }
    public Confirmation Confirmation { get; set; }

    private const string ConfigPath = "bank_transfer_config.json";

    public static BankTransferConfig LoadConfig()
    {
        if (File.Exists(ConfigPath))
        {
            try
            {
                string json = File.ReadAllText(ConfigPath);
                return JsonSerializer.Deserialize<BankTransferConfig>(json);
            }
            catch
            {
                Console.WriteLine("Failed to read config, using default.");
                return DefaultConfig();
            }
        }
        else
        {
            var defaultConfig = DefaultConfig();
            string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, json);
            return defaultConfig;
        }
    }

    private static BankTransferConfig DefaultConfig()
    {
        return new BankTransferConfig
        {
            Lang = "en",
            Transfer = new Transfer
            {
                Threshold = 25000000,
                LowFee = 6500,
                HighFee = 15000
            },
            Methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
            Confirmation = new Confirmation
            {
                En = "yes",
                Id = "ya"
            }
        };
    }
}

public class Transfer
{
    public int Threshold { get; set; }
    public int LowFee { get; set; }
    public int HighFee { get; set; }
}

public class Confirmation
{
    public string En { get; set; }
    public string Id { get; set; }
}
