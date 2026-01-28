using System;
using System.IO;
using System.Text.RegularExpressions;

public class csvValid 
{
    // create dummy CSV with some invalid rows
    public static string createDummyCSV()
    {
        string fname = "students_valid.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Email,Phone,Marks");

            w.WriteLine("101,Rahul,rahul@example.com,9876543210,85");      // valid
            w.WriteLine("102,Priya,priya@invalid,9123456789,92");         // invalid email
            w.WriteLine("103,Aman,aman@test.com,98765,78");               // invalid phone
            w.WriteLine("104,Sneha,sneha@gmail.com,9876543210,88");       // valid
            w.WriteLine("105,Vikram,vikram@company.com,987654321,65");    // invalid phone

            Console.WriteLine("Dummy CSV created: " + fname);
        }
        catch
        {
            Console.WriteLine("could not create dummy file");
        }
        finally
        {
            if(w != null) w.Close();
        }

        return fname;
    }

    public static void validateCSV(string path)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found: " + path);
            return;
        }

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            string line;
            bool isHeader = true;
            int rowNum = 0;

            Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            Regex phoneRegex = new Regex(@"^\d{10}$");

            Console.WriteLine("\nValidating CSV rows...\n");
            Console.WriteLine("Invalid rows:");

            while((line = r.ReadLine()) != null)
            {
                rowNum++;

                if(isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string[] cols = line.Split(',');

                if(cols.Length < 5) continue;

                string id    = cols[0].Trim();
                string name  = cols[1].Trim();
                string email = cols[2].Trim();
                string phone = cols[3].Trim();
                string marks = cols[4].Trim();

                bool emailValid = emailRegex.IsMatch(email);
                bool phoneValid = phoneRegex.IsMatch(phone);

                if(!emailValid || !phoneValid)
                {
                    Console.WriteLine("Row " + rowNum + ":");
                    Console.WriteLine("  ID: " + id + "  Name: " + name);
                    Console.WriteLine("  Email: " + email + " → " + (emailValid ? "OK" : "INVALID"));
                    Console.WriteLine("  Phone: " + phone + " → " + (phoneValid ? "OK" : "INVALID"));

                }
            }
        }
        catch
        {
            Console.WriteLine("error validating CSV");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        8. Validate CSV Data Before Processing
        * Ensure that the "Email" column follows a valid email format using regex.
        * Ensure that "Phone Numbers" contain exactly 10 digits.
        * Print any invalid rows with an error message.
        */

        Console.WriteLine("Validate CSV - Email & Phone\n");

        string dummy = createDummyCSV();

        Console.WriteLine("\nValidating dummy file...\n");

        validateCSV(dummy);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
