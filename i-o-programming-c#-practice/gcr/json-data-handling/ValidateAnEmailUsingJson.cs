using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

public class jsonEmailValidate
{
    public static void Main(string[] args)
    {
        /*
         Validate an email field using JSON Schema.
        */

        Console.WriteLine("JSON Schema Validation - Email Field\n");

        string json = @"{
            ""name"": ""Priya"",
            ""email"": ""priya.sharma@gmail.com"",
            ""age"": 24
        }";

        string schemaJson = @"{
            ""type"": ""object"",
            ""properties"": {
                ""name"": { ""type"": ""string"" },
                ""email"": { ""type"": ""string"", ""format"": ""email"" },
                ""age"": { ""type"": ""integer"", ""minimum"": 18 }
            },
            ""required"": [""name"", ""email"", ""age""]
        }";

        try
        {
            JSchema schema = JSchema.Parse(schemaJson);
            JObject obj = JObject.Parse(json);

            bool valid = obj.IsValid(schema, out IList<string> errors);

            if (valid)
            {
                Console.WriteLine("JSON is VALID");
                Console.WriteLine("Email: " + obj["email"]);
            }
            else
            {
                Console.WriteLine("JSON is INVALID");
                foreach (string error in errors)
                {
                    Console.WriteLine("-> " + error);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine( " Error : " + ex.Message);
        }

        Console.WriteLine("\n Press any key...");
        Console.ReadKey();
    }
}
