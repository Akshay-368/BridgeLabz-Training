using System;
using System.Reflection;
using System.Text;

public class jsonField 
{
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonFieldAttribute : Attribute
    {
        public string Name { get; set; }

        public JsonFieldAttribute(string name = null)
        {
            Name = name;
        }
    }

    public class User
    {
        [JsonField("full_name")]
        public string name = "Rahul Sharma";

        [JsonField]
        public int age = 28;

        public string password = "secret"; // not serialized
    }

    // simple JSON-like serializer using reflection
    public static string toJson(object obj)
    {
        Type t = obj.GetType();
        StringBuilder json = new StringBuilder("{\n");

        FieldInfo[] fields = t.GetFields();

        for(int i=0; i<fields.Length ; i++)
        {
            FieldInfo f = fields[i];

            object[] attrs = f.GetCustomAttributes(typeof(JsonFieldAttribute), false);

            string key = f.Name;

            if(attrs.Length > 0)
            {
                JsonFieldAttribute attr = (JsonFieldAttribute)attrs[0];
                if(!string.IsNullOrEmpty(attr.Name))
                {
                    key = attr.Name;
                }
            }
            else
            {
                // skip fields without attribute
                continue;
            }

            object value = f.GetValue(obj);

            json.Append("  \"" + key + "\": \"" + value + "\"");

            if(i < fields.Length-1) json.Append(",");
            json.Append("\n");
        }

        json.Append("}");
        return json.ToString();
    }

    public static void Main(string[] args) 
    {
        /*
        6️⃣ Implement a Custom Serialization Attribute JsonField
        Problem Statement: Define an attribute JsonField to mark fields for JSON serialization.
        Requirements:
        * [JsonField(Name = "user_name")] should map field names to custom JSON keys.
        * Apply it on a User class.
        * Write a method to convert an object to a JSON string by reading the attributes.
        */

        Console.WriteLine("Custom JSON Field Serialization\n");

        User u = new User();

        string json = toJson(u);

        Console.WriteLine("JSON output:");
        Console.WriteLine(json);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
