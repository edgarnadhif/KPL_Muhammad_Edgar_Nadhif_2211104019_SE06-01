using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 200)
            throw new ArgumentException("Judul tidak boleh null dan maksimal 200 karakter");

        this.id = new Random().Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 25000000)
            throw new ArgumentException("Play count harus antara 0 hingga 25.000.000");

        try
        {
            checked { playCount += count; }
        }
        catch (OverflowException)
        {
            Console.WriteLine("ERROR: Play count melebihi batas maksimum integer!");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}, Judul: {title}, Play Count: {playCount}");
    }

    public int GetPlayCount() => playCount;
    public string GetTitle() => title;
}
