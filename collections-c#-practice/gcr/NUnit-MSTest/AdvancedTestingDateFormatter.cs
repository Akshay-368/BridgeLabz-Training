using System;

public class dateFmt 
{
    // convert yyyy-MM-dd to dd-MM-yyyy
    public static string FormatDate(string inputDate)
    {
        // check basic format
        if(inputDate.Length != 10 || inputDate[4] != '-' || inputDate[7] != '-')
        {
            Console.WriteLine("invalid format - use yyyy-MM-dd");
            return "";
        }

        string year = inputDate.Substring(0,4);
        string month = inputDate.Substring(5,2);
        string day = inputDate.Substring(8,2);

        // simple check - not full validation
        if(month == "00" || day == "00")
        {
            Console.WriteLine("invalid month or day");
            return "";
        }

        string formatted = day + "-" + month + "-" + year;
        Console.WriteLine("formatted date: " + formatted);
        return formatted;
    }

    public static void testDateFormatter()
    {
        Console.WriteLine("Date Formatter Tests:\n");

        string test1 = "2023-12-25";
        string res1 = FormatDate(test1);
        if(res1 == "25-12-2023")
        {
            Console.WriteLine("2023-12-25 → PASS");
        }

        string test2 = "1999-01-01";
        string res2 = FormatDate(test2);
        if(res2 == "01-01-1999")
        {
            Console.WriteLine("1999-01-01 → PASS");
        }

        string invalid1 = "2023/12/25";
        string res3 = FormatDate(invalid1);
        if(res3 == "")
        {
            Console.WriteLine("Invalid separator test: PASS");
        }

        string invalid2 = "2023-13-01";
        string res4 = FormatDate(invalid2);
        if(res4 != "")
        {
            Console.WriteLine("Invalid month test: FAIL");
        }
    }

    public static void Main(string[] args)
    {
        /*
        4. Testing Date Formatter
        Problem:
        Create a DateFormatter class with:
        * FormatDate(string inputDate): Converts yyyy-MM-dd format to dd-MM-yyyy.
          ✅ Write unit test cases for valid and invalid dates.
        */

        Console.WriteLine("Date Formatter Tests (manual)\n");

        testDateFormatter();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
