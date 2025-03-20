using System;
using System.Collections.Generic;


class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    private string username;

    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 100)
            throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter");

        this.id = new Random().Next(10000, 99999);
        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null || video.GetPlayCount() >= int.MaxValue)
            throw new ArgumentException("Video tidak boleh null dan play count tidak boleh melebihi batas");

        uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {username}");
        for (int i = 0; i < Math.Min(uploadedVideos.Count, 8); i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
        }
    }
}
