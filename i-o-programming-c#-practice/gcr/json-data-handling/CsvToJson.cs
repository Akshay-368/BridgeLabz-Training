using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

public class csvToJson
{
    // Simple class to represent one row
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Convert CSV Data to JSON\n");

        //  Create dummy CSV content (as if reading from file)
        string[] csvLines = new string[]
        {
            "ID,Name,Age,Marks",                    // header
            "101,Rahul Kumar,20,85",
            "102,Priya Sharma,19,92",
            "103,Aman Singh,21,78",
            "104,Sneha Verma,18,88",
            "105,Vikram Patel,22,65"
        };

        Console.WriteLine("Dummy CSV data (in memory):");
        foreach (string line in csvLines)
        {
            Console.WriteLine(line);
        }

        //  Parse CSV into List<Student>
        List<Student> students = new List<Student>();

        // Skip header (index 0)
        for (int i = 1; i < csvLines.Length; i++)
        {
            string[] columns = csvLines[i].Split(',');

            if (columns.Length == 4)
            {
                try
                {
                    Student s = new Student
                    {
                        Id    = int.Parse(columns[0]),
                        Name  = columns[1],
                        Age   = int.Parse(columns[2]),
                        Marks = int.Parse(columns[3])
                    };
                    students.Add(s);
                }
                catch
                {
                    Console.WriteLine("Skipping invalid row: " + csvLines[i]);
                }
            }
        }

        // Step 3: Convert list to JSON
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);

        Console.WriteLine("\nConverted JSON:");
        Console.WriteLine(json);

        //  save to file
        string outputFile = "students_from_csv.json";
        System.IO.File.WriteAllText(outputFile, json);
        Console.WriteLine($"\nSaved to file: {outputFile}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
