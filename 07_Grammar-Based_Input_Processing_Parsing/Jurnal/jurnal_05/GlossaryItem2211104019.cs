using System;
using System.IO;
using Newtonsoft.Json;


public class GlossaryItem2211104019
{
    private const string FilePath = "jurnal7_3_2211104019.json"; 

    public static void ReadJSON()
    {
        try
        {
            string jsonData = File.ReadAllText(FilePath);
            Glossary glossary = JsonConvert.DeserializeObject<Glossary>(jsonData);

            var glossEntry = glossary.GlossaryData.GlossDiv.GlossList.GlossEntry;
            Console.WriteLine("Glossary Entry:");
            Console.WriteLine($"ID: {glossEntry.ID}");
            Console.WriteLine($"Term: {glossEntry.GlossTerm}");
            Console.WriteLine($"Acronym: {glossEntry.Acronym}");
            Console.WriteLine($"Abbreviation: {glossEntry.Abbrev}");
            Console.WriteLine($"Definition: {glossEntry.GlossDef.Para}");
            Console.WriteLine("See Also: " + string.Join(", ", glossEntry.GlossDef.GlossSeeAlso));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
        }
    }
}

public class Glossary
{
    [JsonProperty("glossary")]
    public GlossaryData GlossaryData { get; set; }
}

public class GlossaryData
{
    public string Title { get; set; }
    public GlossDiv GlossDiv { get; set; }
}

public class GlossDiv
{
    public string Title { get; set; }
    public GlossList GlossList { get; set; }
}

public class GlossList
{
    public GlossEntry GlossEntry { get; set; }
}

public class GlossEntry
{
    public string ID { get; set; }
    public string SortAs { get; set; }
    public string GlossTerm { get; set; }
    public string Acronym { get; set; }
    public string Abbrev { get; set; }
    public GlossDef GlossDef { get; set; }
    public string GlossSee { get; set; }
}

public class GlossDef
{
    public string Para { get; set; }
    public string[] GlossSeeAlso { get; set; }
}
