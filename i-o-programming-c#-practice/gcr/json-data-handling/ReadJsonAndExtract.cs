using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class jsonExtract 
{
    public static void Main(string[] args)
    {
        /*
        3. Read a JSON file and extract only specific fields (e.g., name, email).
        */

        Console.WriteLine("Read JSON & Extract name + email\n");

        // create dummy JSON file
        string dummyJson = @"{
            ""name"": ""Priya Sharma"",
            ""age"": 24,
            ""email"": ""priya.sharma@gmail.com"",
            ""city"": ""Mathura""
        }";

        string filePath = "student_extract.json";
        File.WriteAllText(filePath, dummyJson);

        Console.WriteLine("Dummy JSON file created : " + filePath);

        try
        {
            string jsonContent = File.ReadAllText(filePath);

            JObject obj = JObject.Parse(jsonContent);

            string name = (string)obj["name"];
            string email = (string)obj["email"];

            Console.WriteLine("\nExtracted fields:");
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Email: " + email);
        }
        catch(Exception e)
        {
            Console.WriteLine("error reading or parsing JSON : " + e.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
