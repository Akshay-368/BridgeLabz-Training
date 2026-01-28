using System;
using System.IO;
using System.Collections.Generic;

public class csvToObj 
{
    // simple Student class
    public class Student
    {
        public int id;
        public string name;
        public int age;
        public int marks;

        public Student(int i,string n,int a,int m)
        {
            id = i;
            name = n;
            age = a;
            marks = m;
        }

        public void print()
        {
            Console.WriteLine(id + " | " + name + " | Age: " + age + " | Marks: " + marks);
        }
    }

    // create dummy CSV
    public static string createDummy()
    {
        string fname = "students_obj.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Age,Marks");

            w.WriteLine("101,Rahul,20,85");
            w.WriteLine("102,Priya,19,92");
            w.WriteLine("103,Aman,21,78");

            Console.WriteLine("Dummy CSV created: " + fname);
        }
        catch
        {
            Console.WriteLine("could not create file");
        }
        finally
        {
            if(w != null) w.Close();
        }

        return fname;
    }

    // read CSV and convert to List<Student>
    public static void convertCSVToObjects(string path)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found");
            return;
        }

        List<Student> students = new List<Student>();

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            string line;
            bool isHeader = true;

            while((line = r.ReadLine()) != null)
            {
                if(isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string[] cols = line.Split(',');

                if(cols.Length < 4) continue;

                int id   = int.Parse(cols[0]);
                string name = cols[1];
                int age  = int.Parse(cols[2]);
                int marks = int.Parse(cols[3]);

                Student s = new Student(id, name, age, marks);
                students.Add(s);
            }

            Console.WriteLine("\nConverted to Student objects:");
            foreach(Student s in students)
            {
                s.print();
            }
        }
        catch
        {
            Console.WriteLine("error converting CSV to objects");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        9. Convert CSV Data into Java Objects
        * Read a CSV file and convert each row into a Student C# object.
        * Store the objects in a List<Student> and print them.
        */

        Console.WriteLine("CSV to Student Objects\n");

        string dummy = createDummy();

        Console.WriteLine("\n Converting CSV to objects...\n");

        convertCSVToObjects(dummy);

        Console.WriteLine("\n Press any key to exit...");
        Console.ReadKey();
    }
}
