using System;
using System.Collections.Generic;

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username { get; private set; }

    public SayaTubeUser(string username)
    {
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;
        foreach (var video in uploadedVideos)
        {
            totalPlayCount += video.GetPlayCount();
        }
        return totalPlayCount;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount()
    {
        Console.WriteLine($"User: {Username}");
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
        }
    }
}
