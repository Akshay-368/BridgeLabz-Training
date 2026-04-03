using System;
using Newtonsoft.Json.Linq;

public class jsonKeysValues
{
    public static void Main(string[] args)
    {
        /*
        11. Read a JSON file and print all keys and values.
        */

        Console.WriteLine("Read JSON & Print All Keys and Values\n");

        // Create dummy JSON content
        string jsonText = @"{
            ""name"": ""Rahul Kumar"",
            ""age"": 24,
            ""city"": ""Mathura"",
            ""isStudent"": true,
            ""marks"": [85, 92, 78],
            ""address"": {
                ""street"": ""Civil Lines"",
                ""pincode"": 281001
            }
        }";

        string filePath = "sample.json";
        System.IO.File.WriteAllText(filePath, jsonText);

        Console.WriteLine("Dummy JSON file created: " + filePath);

        try
        {
            string content = System.IO.File.ReadAllText(filePath);
            JToken token = JToken.Parse(content);

            Console.WriteLine("\nAll keys and values:");

            PrintJson(token, "");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading or parsing JSON : " + ex.Message);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    private static void PrintJson(JToken token, string indent)
    {
        if (token is JObject obj)
        {
            foreach (JProperty prop in obj.Properties())
            {
                Console.WriteLine(indent + prop.Name + ": ");
                PrintJson(prop.Value, indent + "  ");
            }
        }
        else if (token is JArray array)
        {
            Console.WriteLine(indent + "[");
            foreach (JToken item in array)
            {
                PrintJson(item, indent + "  ");
            }
            Console.WriteLine(indent + "]");
        }
        else
        {
            Console.WriteLine(indent + token.ToString());
        }
    }
}
