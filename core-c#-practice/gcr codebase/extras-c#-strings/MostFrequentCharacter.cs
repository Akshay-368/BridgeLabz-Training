using System;
public static class MostFrequenctCharacter
{
    public static void Main()
    {
        /*9. Find the Most Frequent Character
        Problem:
        Write a C# program to find the most frequent character in a string.
        Example Input:
        String: "success"
        Expected Output:
        Most Frequent Character: 's'
        */

        Console.WriteLine ( "Enter a string  : ");
        string s = Console.ReadLine();

        int[] arr = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            arr [ s [i] - 'a'] ++ ;
        }

        int max = arr[0];
        char ch = 'a';
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                ch = (char)('a' + i);
            }
        }
        Console.WriteLine ( " Most Frequent Character : " + ch) ;// printing the output as question demands

        
        
        
    }
}
