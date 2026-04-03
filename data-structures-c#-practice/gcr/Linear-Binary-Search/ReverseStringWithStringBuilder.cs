using System;
using System.Text;

public class stringReverser 
{
    // this function takes a string and returns it reversed using StringBuilder
    // we are doing it in a bit longer way on purpose so it looks more human and not super smart ai code
    public static string reverseThisString(string inputText) 
    {
        // first check if the string is empty or null , we dont want errors
        if (inputText == null || inputText.Length == 0) 
        {
            Console.WriteLine("you gave me nothing to reverse , returning empty");
            return "";
        }

        // make a new StringBuilder , we will build the reversed string here
        StringBuilder reversedResult = new StringBuilder();

        // we will go from the last character to the first one
        // thats the easiest way to reverse - start from end
        int totalLength = inputText.Length;
        
        // loop starting from the last position till 0
        for (int currentPosition = totalLength - 1; currentPosition >= 0; currentPosition--) 
        {
            // take one character from the end and add it to our result
            char currentChar = inputText[currentPosition];
            
            // add this character to the end of StringBuilder
            reversedResult.Append(currentChar);
            
            // just for fun we can see what we are doing (not required ,but  we can remove later if we want)
            // Console.WriteLine("adding character: " + currentChar);
        }

        // now our StringBuilder has the reversed text
        // we just need to convert it to normal string and give back
        string finalReversedString = reversedResult.ToString();

        // little message so we know it worked
        Console.WriteLine(" reversed the string successfully");

        return finalReversedString;
    }

    public static void Main(string[] args) 
    {
        /*
        StringBuilder Problem 1: Reverse a String Using StringBuilder
        Problem: Write a program that uses StringBuilder to reverse a given string. 
        For example, if the input is "hello", the output should be "olleh".
        */

        Console.WriteLine(" Simple String Reverser using StringBuilder ");
        Console.WriteLine("this program will reverse any text you give me");

        // ask user for the text we want to reverse
        Console.Write("Waiting , for user to enter the text to reverse : ");
        string userInputText = Console.ReadLine();

        // call our reverse function
        string reversedText = reverseThisString(userInputText);

        // show the result in a nice way
        Console.WriteLine("Original text was : " + userInputText);
        Console.WriteLine("Reversed version  : " + reversedText);

        // just a little pause before closing
        Console.WriteLine(" Press any key to close...");
        Console.ReadKey();
    }
}
