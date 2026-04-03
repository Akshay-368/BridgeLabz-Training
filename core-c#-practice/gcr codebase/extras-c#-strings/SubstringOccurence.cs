using System;
public static class SubstringOccurrence
{
    public static void Main()
    {
        /*6. Find Substring Occurrences
        Problem:
        Write a C# program to count how many times a given substring occurs in a string.
        */

        Console.WriteLine ( "Enter a string  : ");
        string s = Console.ReadLine();
        Console.WriteLine ( " Enter a substring now that you want to get the count of , from the string above : " );
        string sub = Console.ReadLine();
        int c = 0; // initializng the count variable that will keep track of the count of the substring occurance in the string
        int i = s.IndexOf(sub); // IndexOf() is a method of the string class that belongs to System namespace and returns the index of the given substring from the string
        // Looping till the IndexOf() method returns -1
        // We are looping because the IndexOf() method returns the first occurence of the entered substring and thus we need to traverse till the end of the string to have proper count
        while (i != -1)
        {
            // -1 means that the substring that is entered does not exists and thus IndexOf() returned -1
            c++;
            i = s.IndexOf(sub, i + 1); // updating i further
        }
        Console.WriteLine("The substring {0} occurs {1} times in the string.", sub, c);
        
        
    }
}
