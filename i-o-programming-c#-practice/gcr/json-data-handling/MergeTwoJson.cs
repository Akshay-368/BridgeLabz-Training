using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class jsonMerge 
{
    public static void Main(string[] args)
    {
        /*
        4. Merge two JSON objects into one.
        */

        Console.WriteLine("Merge Two JSON Objects\n");

        string json1 = @"{
            ""name"": ""Aman"",
            ""age"": 22,
            ""city"": ""Mathura""
        }";

        string json2 = @"{
            ""marks"": 85,
            ""grade"": ""A"",
            ""school"": ""KV Mathura""
        }";

        try
        {
            JObject obj1 = JObject.Parse(json1);
            JObject obj2 = JObject.Parse(json2);

            obj1.Merge(obj2, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Merge
            });

            string mergedJson = obj1.ToString(Formatting.Indented);

            Console.WriteLine("Merged JSON : ");
            Console.WriteLine(mergedJson);
        }
        catch(Exception e)
        {
            Console.WriteLine(" error merging JSON : " + e.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
