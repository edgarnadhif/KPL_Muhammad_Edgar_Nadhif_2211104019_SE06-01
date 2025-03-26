using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
public class Mahasiswa
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }
    public Course[] Courses { get; set; }
}

public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

public class Course
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class DataMahasiswa2211104019
{
    private const string FilePath = "jurnal7_1_2211104019.json";

    public static void ReadJSON()
    {
        try
        {
            string jsonData = File.ReadAllText(FilePath);
            Mahasiswa mahasiswa = JsonConvert.DeserializeObject<Mahasiswa>(jsonData);

            Console.WriteLine("Data Mahasiswa:");
            Console.WriteLine($"Nama: {mahasiswa.FirstName} {mahasiswa.LastName}");
            Console.WriteLine($"Jenis Kelamin: {mahasiswa.Gender}");
            Console.WriteLine($"Usia: {mahasiswa.Age}");
            Console.WriteLine($"Alamat: {mahasiswa.Address.StreetAddress}, {mahasiswa.Address.City}, {mahasiswa.Address.State}");
            Console.WriteLine("Mata Kuliah:");
            foreach (var course in mahasiswa.Courses)
            {
                Console.WriteLine($"- {course.Code}: {course.Name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
        }
    }
}