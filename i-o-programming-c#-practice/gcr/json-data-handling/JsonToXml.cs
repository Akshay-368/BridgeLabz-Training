using System;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class jsonToXml
{
    public static void Main(string[] args)
    {
        /*
        3. Convert JSON to XML format.
        */

        Console.WriteLine("JSON -> XML Conversion\n");

        string json = @"{
            ""student"": {
                ""name"": ""Sneha"",
                ""age"": 19,
                ""marks"": [92, 88, 95],
                ""address"": {
                    ""city"": ""Vrindavan"",
                    ""pin"": 281121
                }
            }
        }";

        try
        {
            JObject obj = JObject.Parse(json);

            // Simple recursive conversion to XML
            XElement xml = JsonToXml(obj, "root");

            Console.WriteLine("Converted XML:");
            Console.WriteLine(xml.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error converting JSON to XML: " + ex.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    private static XElement JsonToXml(JToken token, string elementName)
    {
        XElement element = new XElement(elementName);

        if (token is JObject obj)
        {
            foreach (JProperty prop in obj.Properties())
            {
                element.Add(JsonToXml(prop.Value, prop.Name));
            }
        }
        else if (token is JArray array)
        {
            foreach (JToken item in array)
            {
                element.Add(JsonToXml(item, "item"));
            }
        }
        else
        {
            element.Value = token.ToString();
        }

        return element;
    }
}
