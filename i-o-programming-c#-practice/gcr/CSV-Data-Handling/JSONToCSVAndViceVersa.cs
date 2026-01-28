using System;
using System.IO;

public class jsonCsv 
{
    // very simple JSON-like to CSV (manual parsing)
    public static void jsonToCsv(string jsonFile,string csvFile)
    {
        if(!File.Exists(jsonFile))
        {
            Console.WriteLine("json file not found: " + jsonFile);
            return;
        }

        string jsonContent = File.ReadAllText(jsonFile);

        // very naive JSON parsing - assumes simple format
        // example: [{"id":1,"name":"Rahul","age":20},{"id":2,"name":"Priya","age":19}]
        string cleaned = jsonContent.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "");

        string[] records = cleaned.Split(new string[] { "},{" }, StringSplitOptions.None);

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(csvFile);

            // header
            w.WriteLine("ID,Name,Age");

            for(int i=0; i<records.Length ; i++)
            {
                string rec = records[i];
                string[] fields = rec.Split(',');

                string id = "";
                string name = "";
                string age = "";

                for(int j=0; j<fields.Length ; j++)
                {
                    string[] kv = fields[j].Split(':');
                    if(kv.Length == 2)
                    {
                        string key = kv[0].Trim().Replace("\"", "");
                        string val = kv[1].Trim().Replace("\"", "");

                        if(key == "id") id = val;
                        if(key == "name") name = val;
                        if(key == "age") age = val;
                    }
                }

                w.WriteLine(id + "," + name + "," + age);
            }

            Console.WriteLine("JSON → CSV conversion done: " + csvFile);
        }
        catch(Exception e)
        {
            Console.WriteLine("error converting JSON to CSV: " + e.Message);
        }
        finally
        {
            if(w != null) w.Close();
        }
    }

    // simple CSV to JSON-like
    public static void csvToJson(string csvFile,string jsonFile)
    {
        if(!File.Exists(csvFile))
        {
            Console.WriteLine("csv file not found: " + csvFile);
            return;
        }

        StreamReader r = null;
        StreamWriter w = null;

        try
        {
            r = new StreamReader(csvFile);
            w = new StreamWriter(jsonFile);

            w.WriteLine("[");

            r.ReadLine(); // skip header

            string line;
            bool first = true;

            while((line = r.ReadLine()) != null)
            {
                if(!first) w.WriteLine(",");

                string[] cols = line.Split(',');
                if(cols.Length < 3) continue;

                w.WriteLine("  {");
                w.WriteLine("    \"id\": " + cols[0] + ",");
                w.WriteLine("    \"name\": \"" + cols[1] + "\",");
                w.WriteLine("    \"age\": " + cols[2]);
                w.WriteLine("  }");

                first = false;
            }

            w.WriteLine("]");

            Console.WriteLine("CSV → JSON conversion done: " + jsonFile);
        }
        catch(Exception e)
        {
            Console.WriteLine("error converting CSV to JSON: " + e.Message);
        }
        finally
        {
            if(r != null) r.Close();
            if(w != null) w.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        14. Convert JSON to CSV and Vice Versa
        * Read a JSON file containing a list of students.
        * Convert it into CSV format and save it.
        * Implement another method to read CSV and convert it back to JSON.
        */

        Console.WriteLine("JSON ↔ CSV Converter (simple student style)\n");

        // step 1: JSON to CSV
        Console.Write("Waiting , for user to enter input JSON file : ");
        string jsonIn = Console.ReadLine();

        if(string.IsNullOrEmpty(jsonIn))
        {
            jsonIn = "students.json";
        }

        string csvOut = "students_from_json.csv";
        jsonToCsv(jsonIn, csvOut);

        // step 2: CSV to JSON
        Console.Write("\nWaiting , for user to enter CSV file to convert back to JSON : ");
        string csvIn = Console.ReadLine();

        if(string.IsNullOrEmpty(csvIn))
        {
            csvIn = csvOut;
        }

        string jsonOut = "students_from_csv.json";
        csvToJson(csvIn, jsonOut);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
