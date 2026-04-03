using System;
using System.IO;
using Newtonsoft.Json.Linq;

public class jsonMergeFiles
{
    public static void Main(string[] args)
    {
        /*
        2. Merge two JSON files into a single JSON object.
        */

        Console.WriteLine("Merge Two JSON Files\n");

        // Dummy JSON 1
        string json1 = @"{
            ""name"": ""Aman"",
            ""age"": 27,
            ""city"": ""Delhi""
        }";
        File.WriteAllText("person1.json", json1);

        // Dummy JSON 2
        string json2 = @"{
            ""marks"": 88,
            ""grade"": ""A"",
            ""school"": ""DPS Delhi""
        }";
        File.WriteAllText("person2.json", json2);

        Console.WriteLine("Dummy files created: person1.json & person2.json");

        try
        {
            string content1 = File.ReadAllText("person1.json");
            string content2 = File.ReadAllText("person2.json");

            JObject obj1 = JObject.Parse(content1);
            JObject obj2 = JObject.Parse(content2);

            obj1.Merge(obj2);

            string merged = obj1.ToString(Formatting.Indented);

            Console.WriteLine("\nMerged JSON:");
            Console.WriteLine(merged);

            File.WriteAllText("merged_person.json", merged);
            Console.WriteLine("\nSaved to: merged_person.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error merging JSON: " + ex.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
