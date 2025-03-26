using System;
using System.IO;
using Newtonsoft.Json;

public class Team
{
    public Member[] Members { get; set; }
}

public class Member
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string Nim { get; set; }
}

public class TeamMembers2211104019
{
    private const string FilePath = "jurnal7_2_2211104019.json"; 

    public static void ReadJSON()
    {
        try
        {
            string jsonData = File.ReadAllText(FilePath);
            Team team = JsonConvert.DeserializeObject<Team>(jsonData);

            Console.WriteLine("Team member list:");
            foreach (var member in team.Members)
            {
                Console.WriteLine($"{member.Nim} {member.FirstName} {member.LastName} ({member.Age} {member.Gender})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
        }
    }
}
