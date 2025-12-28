using System;

public class ReturnCharacters
{
    public static void Main(string[] args)
    {
        /*
        3. Return All Characters Without Using ToCharArray()

        Hint => 

        - Write a method to return characters of a string without using ToCharArray() (loop through string[index]).

        - Compare the result with the built-in ToCharArray() method.

        4. Demonstrate NullReferenceException

        Hint => 

        - Write a method to demonstrate NullReferenceException by accessing a method on a null string.

        - Use a try-catch block to handle the exception.
        */

        // first part , get chars without ToCharArray
        Console.WriteLine("Enter a string for char test:");
        string inp = Console.ReadLine();

        char[] mych = getc(inp);   // calling our own fun
        char[] real = inp.ToCharArray();  // the built in one

        Console.WriteLine("My way chars:");
        prnt(mych);

        Console.WriteLine("Real ToCharArray way:");
        prnt(real);

        // check if same
        bool sam = true;
        if (mych.Length == real.Length)
        {
            for (int i = 0;i<mych.Length ; i++)
            {
                if (mych[i] != real[i])
                {
                    sam = false;
                    break;
                }
            }
        }
        else
        {
            sam = false;
        }

        if (sam)
            Console.WriteLine("Both are same ! good");
        else
            Console.WriteLine("Not same , somethng wrong");

        Console.WriteLine("\nNow for null ref exception demo");

        demn();
    }

    public static char[] getc(string s)
    {
        // this fun loops thru index and makes char array
        // no ToCharArray used here , as asked
        char[] res = new char[s.Length];

        for (int i=0; i < s.Length ;i ++)
        {
            res[i] = s[i];   // direct index access
        }

        return res;
    }

    public static void prnt(char[] ar)
    {
        // printing each char with space
        for (int i = 0; i< ar.Length ; i++)
        {
            Console.Write(ar[i] + " ");
        }
        Console.WriteLine();
    }

    public static void demn()
    {
        string nul = null;

        try
        {
            // trying to call Length on null string
            // this will throw NullReferenceException for sure
            int len = nul.Length;
            Console.WriteLine("Length is " + len);  // wont reach here
        }
        catch (NullReferenceException ex)
        {
            // catching the null ref error
            Console.WriteLine("Got NullReferenceException as expected !");
            Console.WriteLine("Message: " + ex.Message);
        }
        catch (Exception ex)
        {
            // just in case some other error
            Console.WriteLine("Some other error: " + ex.Message);
        }

        Console.WriteLine("Program still running after catch");
    }
}
