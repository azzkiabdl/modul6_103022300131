using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Contract.Requires(title != null, "Judul video tidak boleh null");
        Contract.Requires(title.Lenght <= 200, "Judul video maksimal 200 karakter");

        Random random = new Random();
        this.id = id;
        this.title = title;
        this.playCount = playCount;
    }

    public void IncreasePlayCount(int playCount)
    {
        Contract.Requires(count > 0, "Jumlah play count harus positif");
        Contract.Requires(count <= 25000000, "Maksimal play sound yang bisa ditambahkan adalah 25.000.000");
        try
        {
            checked
            {
                this.playCount = Count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count melebihi batas");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }

    public int GetPlayCount()
    {
        return this.playCount;
    }

    public string GetTitle()
    {
        return this.title;
    }
}

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string username)
    {
        Contract.Requires(username != null, "Username tidak boleh null");
        Contract.Requires(username.Lenght <= 100, "Username maksimal hanya 100 karakter");

        Random random = new Random();
        this.id = random.Next();
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        Contract.Requires(video != null, "Video tidak boleh null");
        Contract.Requires(video.GetPlayCount() < int.MaxValue, "Play count tidak boleh melebihi batas integer maksimun");
        uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach(var video in uploadedVideos)
        {
            total = video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {Username}");
        for (int i = 0; i < Math.Min(uploadedVideos.Count, 8); i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
        }
    }
}

class program
{
    static void main()
    {
        SayaTubeUser user = new SayaTubeUser("Nama Praktikan");

        for (int i = 1; i <= 10; i++)
        {
            SayaTubeVideo video = new SayaTubeVideo($"Review Film {i} oleh Nama Praktikan");
            video.IncreasePlayCount(100000);
            user.AddVideo(video);
        }

        user.PrintAllVideoPlaycount();
        Console.WriteLine($"Total play count semua video: {user.GetTotalVideoPlayCount()}");

        try
        {
            SayaTubeVideo videoError = new SayaTubeVideo(null);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        try
        {
            SayaTubeVideo videoOverflow = new SayaTubeVideo("Test Overflow");
            videoOverflow.IncreasePlayCount(int.MaxValue);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}