using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 0)
        {
            this.playCount += count;
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID Video: {id}");
        Console.WriteLine($"Judul: {title}");
        Console.WriteLine($"Jumlah Play: {playCount}");
    }

    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }
}
