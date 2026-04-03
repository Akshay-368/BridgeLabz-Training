using System;

public class strUtil 
{
    public static string reverse(string s)
    {
        string rev = "";
        for(int i=s.Length-1; i>=0 ; i--)
        {
            rev += s[i];
        }
        return rev;
    }

    public static bool isPalindrome(string s)
    {
        string rev = reverse(s);
        return s.ToLower() == rev.ToLower();
    }

    public static string toUpper(string s)
    {
        string upper = "";
        for(int i=0; i<s.Length ; i++)
        {
            upper += char.ToUpper(s[i]);
        }
        return upper;
    }

    public static void testAll()
    {
        Console.WriteLine("String Utils Tests:\n");

        // test reverse
        string revTest = reverse("hello");
        if(revTest == "olleh")
        {
            Console.WriteLine("reverse('hello') - 'olleh' : PASS");
        }

        // test palindrome
        if(isPalindrome("radar"))
        {
            Console.WriteLine("isPalindrome('radar') : PASS");
        }
        if(!isPalindrome("hello"))
        {
            Console.WriteLine("isPalindrome('hello') : PASS (false)");
        }

        // test toUpper
        string upperTest = toUpper("hello world");
        if(upperTest == "HELLO WORLD")
        {
            Console.WriteLine("toUpper('hello world') - 'HELLO WORLD' : PASS");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. Testing String Utility Methods
        Problem:
        Create a StringUtils class with the following methods:
        * Reverse(string str): Returns the reverse of a given string.
        * IsPalindrome(string str): Returns true if the string is a palindrome.
        * ToUpperCase(string str): Converts a string to uppercase.
        Write NUnit or MSTest test cases to verify that these methods work correctly.
        */

        Console.WriteLine("String Utility Tests (manual)\n");

        testAll();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
