using System;
using System.IO;
using Newtonsoft.Json.Linq;

public class jsonFilter 
{
    public static void Main(string[] args)
    {
        /*
        7. Parse JSON and filter only those records where age > 25
        */

        Console.WriteLine("Parse JSON & Filter age > 25\n");

        // dummy JSON array
        string json = @"[
            {""name"": ""Rahul"", ""age"": 28, ""city"": ""Mathura""},
            {""name"": ""Priya"", ""age"": 22, ""city"": ""Agra""},
            {""name"": ""Aman"", ""age"": 31, ""city"": ""Delhi""},
            {""name"": ""Sneha"", ""age"": 19, ""city"": ""Vrindavan""},
            {""name"": ""Vikram"", ""age"": 27, ""city"": ""Lucknow""}
        ]";

        string filePath = "people.json";
        File.WriteAllText(filePath, json);

        Console.WriteLine("Dummy JSON file created : " + filePath);

        try
        {
            string content = File.ReadAllText(filePath);
            JArray array = JArray.Parse(content);

            Console.WriteLine("\nPeople with age > 25 : ");


            foreach (JObject person in array)
            {
                int age = (int)person["age"];
                if (age > 25)
                {
                    Console.WriteLine("Name : " + person["name"] + ", Age : " + age + ", City : " + person["city"]);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("error parsing JSON : " + e.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
