using System;

public class lexicalTwist
{
    public static void Main(string[] args)
    {
        /*
        Lexical Twist
        Leo loves puzzles and he enjoys creating challenges for his friends. Today, Leo has
        a new puzzle for his friend, involving two words. The task is to process the words
        and perform various transformations and analyses based on specific conditions.
        Requirements:
        1. Check if the second word is a reversed version of the first word:
           - The second word is considered the "reversed version" of the first word if the second
             word is the first word in reverse order (case insensitive).
        2. If the second word is the reversed version of the first word:
           - Step 1: Reverse the first word.
           - Step 2: Convert the reversed word to lowercase.
           - Step 3: Replace all vowels (a, e, i, o, u) in the reversed word with the character '@'.
           - Step 4: Then, print the transformed word.
        3. If the second word is not the reversed version of the first word:
           - Step 1: Combine the first and second words into a single word (first word + second word).
           - Step 2: Convert the combined word to uppercase.
           - Step 3: Count the number of vowels and consonants separately in the uppercase word.
           - Step 4: Based on the counts:
             ● If there are more vowels than consonants, print the first 2 vowels in the uppercase word, removing any duplicates.
             ● If there are more consonants than vowels, print the first 2 consonants in the uppercase word, removing any duplicates.
             ● If the vowel count equals consonant count, print "Vowels and consonants are equal".
        Validations:
        - If the input words contain more than one word, print "<string> is an invalid word"
          and terminate the program (Do not use System.exit(0)).
        */

        Console.WriteLine("Lexical Twist Puzzle\n");

        //  Get first word
        Console.Write("Enter the first word : ");
        string firstWord = Console.ReadLine().Trim();

        // Validation: single word only
        if (firstWord.Contains(" "))
        {
            Console.WriteLine(firstWord + " is an invalid word");
            goto EndProgram;
        }

        //  Get second word
        Console.Write("Enter the second word : ");
        string secondWord = Console.ReadLine().Trim();

        // Validation: single word only
        if (secondWord.Contains(" "))
        {
            Console.WriteLine(secondWord + " is an invalid word");
            goto EndProgram;
        }

        //  Check if second word is reverse of first (case insensitive)
        string firstReversed = ReverseString(firstWord.ToLower());
        string secondLower = secondWord.ToLower();

        if (firstReversed == secondLower)
        {
            // Case: second word is reverse of first
            string reversed = ReverseString(firstWord);
            string lowerReversed = reversed.ToLower();
            string transformed = ReplaceVowelsWithAt(lowerReversed);

            Console.WriteLine(transformed);
        }
        else
        {
            // Case: not reverse → combine and analyze
            string combined = firstWord + secondWord;
            string upperCombined = combined.ToUpper();

            int vowelCount = 0;
            int consonantCount = 0;

            string vowelsFound = "";
            string consonantsFound = "";

            for (int i = 0; i < upperCombined.Length; i++)
            {
                char c = upperCombined[i];

                if (char.IsLetter(c))
                {
                    if ("AEIOU".IndexOf(c) >= 0)
                    {
                        vowelCount++;
                        if (vowelsFound.IndexOf(c) == -1)
                            vowelsFound += c;
                    }
                    else
                    {
                        consonantCount++;
                        if (consonantsFound.IndexOf(c) == -1)
                            consonantsFound += c;
                    }
                }
            }

            if (vowelCount > consonantCount)
            {
                // more vowels - print first 2 unique vowels
                string result = "";
                int added = 0;
                for (int i = 0; i < vowelsFound.Length && added < 2; i++)
                {
                    result += vowelsFound[i];
                    added++;
                }
                Console.WriteLine(result);
            }
            else if (consonantCount > vowelCount)
            {
                // more consonants - print first 2 unique consonants
                string result = "";
                int added = 0;
                for (int i = 0; i < consonantsFound.Length && added < 2; i++)
                {
                    result += consonantsFound[i];
                    added++;
                }
                Console.WriteLine(result);
            }
            else
            {
                // equal count
                Console.WriteLine("Vowels and consonants are equal");
            }
        }

    EndProgram:
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // reverse a string
    private static string ReverseString(string s)
    {
        char[] chars = s.ToCharArray();
        int left = 0;
        int right = chars.Length - 1;

        while (left < right)
        {
            char temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;
            left++;
            right--;
        }

        return new string(chars);
    }

    // replace vowels aeiou with @
    private static string ReplaceVowelsWithAt(string s)
    {
        string result = "";
        string vowels = "aeiou";

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (vowels.IndexOf(c) >= 0)
            {
                result += '@';
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
}
