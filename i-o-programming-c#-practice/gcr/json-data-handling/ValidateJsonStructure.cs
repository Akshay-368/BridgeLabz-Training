using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

public class jsonValidate 
{
    public static void Main(string[] args)
    {
        /*
        5. Validate JSON structure using Newtonsoft.Json.Schema.
        */

        Console.WriteLine("JSON Schema Validation\n");

        string json = @"{
            ""name"": ""Sneha"",
            ""age"": 19,
            ""email"": ""sneha@gmail.com""
        }";

        string schemaJson = @"{
            ""type"": ""object"",
            ""properties"": {
                ""name"": { ""type"": ""string"" },
                ""age"": { ""type"": ""integer"", ""minimum"": 18 },
                ""email"": { ""type"": ""string"", ""format"": ""email"" }
            },
            ""required"": [""name"", ""age"", ""email""]
        }";

        try
        {
            JSchema schema = JSchema.Parse(schemaJson);
            JObject obj = JObject.Parse(json);

            bool isValid = obj.IsValid(schema, out IList<string> errors);

            if (isValid)
            {
                Console.WriteLine("JSON is VALID");
            }
            else
            {
                Console.WriteLine("JSON is INVALID");
                foreach (string error in errors)
                {
                    Console.WriteLine("- " + error);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("error validating JSON: " + e.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
