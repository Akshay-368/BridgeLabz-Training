using System;
using System.IO;

public class csvCrypt 
{
    // very simple Caesar cipher for demo 
    public static string encrypt(string text)
    {
        string result = "";

        for(int i=0; i<text.Length ; i++)
        {
            char c = text[i];

            if(char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                c = (char)((((c - baseChar) + 3) % 26) + baseChar);
            }
            else if(char.IsDigit(c))
            {
                c = (char)((((c - '0') + 3) % 10) + '0');
            }

            result += c;
        }

        return result;
    }

    public static string decrypt(string text)
    {
        string result = "";

        for(int i=0; i<text.Length ; i++)
        {
            char c = text[i];

            if(char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                c = (char)((((c - baseChar) - 3 + 26) % 26) + baseChar);
            }
            else if(char.IsDigit(c))
            {
                c = (char)((((c - '0') - 3 + 10) % 10) + '0');
            }

            result += c;
        }

        return result;
    }

    // create dummy CSV with sensitive fields
    public static string createDummyEncryptedCSV()
    {
        string fname = "employees_encrypted.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Department,EncryptedSalary");

            // encrypt salary before writing
            w.WriteLine("101,Rahul,IT," + encrypt("65000"));
            w.WriteLine("102,Priya,HR," + encrypt("52000"));
            w.WriteLine("103,Aman,Sales," + encrypt("48000"));

            Console.WriteLine("Dummy encrypted CSV created: " + fname);
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

    // read encrypted CSV and decrypt salary
    public static void readAndDecryptCSV(string path)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found");
            return;
        }

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            r.ReadLine(); // skip header

            Console.WriteLine("\nDecrypted employee data:");
            Console.WriteLine("ID   Name     Dept     Salary");

            string line;
            while((line = r.ReadLine()) != null)
            {
                string[] cols = line.Split(',');

                if(cols.Length < 4) continue;

                string id   = cols[0];
                string name = cols[1];
                string dept = cols[2];
                string encSal = cols[3];

                string decSal = decrypt(encSal);

                Console.WriteLine(id + "  " + name.PadRight(8) + "  " + dept.PadRight(8) + "  " + decSal);
            }
        }
        catch
        {
            Console.WriteLine("error decrypting file");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        15. Encrypt and Decrypt CSV Data
        * Encrypt the sensitive fields (e.g., Salary, Email) while writing to a CSV file.
        * Decrypt them when reading the file.
        */

        Console.WriteLine("Simple CSV Encryption & Decryption (Caesar shift demo)\n");

        string dummy = createDummyEncryptedCSV();

        Console.WriteLine("\nNow reading and decrypting...\n");

        readAndDecryptCSV(dummy);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
