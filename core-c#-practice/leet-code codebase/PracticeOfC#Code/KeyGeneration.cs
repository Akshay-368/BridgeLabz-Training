/*

Question : Key Generation You are given N strings. Your task is to validate the input string and generate key-based transformation rules. 
Validation Rules The input string must satisfy all of the following conditions: ● The length of the string must be greater than or equal to 6.
 ● The string must contain only alphabets (uppercase or lowercase). ● It must not contain spaces, digits, or special characters.
  If not, print "Invalid Input" with the message. Examples: 
  ● Invalid Input (length < 6) 
  ● Invalid Input (contains space)
   ● Invalid Input (contains digits)
    ● Invalid Input (contains special character) 
    Key Generation Rules If the string is valid, 
    the key must be generated using the following steps:
     1. Convert the input string to lowercase. 
     2. Remove all characters having even ASCII values. 
     3. Reverse the remaining characters. 
     4. Convert characters at even positions (0-based index) in the reversed string to uppercase. 
     Return the generated key as: "The generated key is - <generated key>"
      If the method returns an empty string, return: "Invalid Input (empty string)"
     Function Description In the provided code snippet, implement the method to validate the input string and generate a key according to the rules. 
     CleanseAndInvert(string str) : validates the input string and generates the key. 
     You can write your code in the space below the phrase “WRITE YOUR LOGIC HERE”. 
     Input Format 
     ● The first line contains an integer N, denoting the number of input strings.
      ● The next N lines each contain a string. 
      Sample Input 
      10 
      Aeroplane 
      aabbc12 
      Sun
      Hello World 
      ValidKey 
      Alpha! 
      aaaaaa 
      bdflnp 
      Python3 
      ZebraZ 
      
      Output Format 
      The output contains the generated key as "The generated key is - <generated key>" if non-empty. 
      If the method returns an empty string, return "Invalid Input (empty string)". 
      Sample Output 
      The generated key is - EaOeA 
      Invalid Input (contains digits) 
      Invalid Input (length < 6) 
      Invalid Input (contains space) 
      The generated key is - YeKiA 
      Invalid Input (contains special character) 
      The generated key is - AaAaAa 
      Invalid Input (empty string) 
      Invalid Input (contains digits) 
      The generated key is - Ae 
      Explanation Aeroplane → Valid input. 
      After removing even ASCII characters, reversing, and capitalizing even positions → EaOeA.
       Remove characters with even ASCII values:
        ● a(97) → keep ● e(101) → keep ● r(114) → remove ● o(111) → keep ● p(112) → remove ● l(108) → remove ● a(97) → keep ● n(110) → remove ● e(101) → keep Remaining → 
        aeoae Reverse → eaoea Convert even index positions (0-based) to uppercase → EaOeA aabbc12 → Contains digits → Invalid Input (contains digits). 
        
        Sun → Length less than 6 → Invalid Input (length < 6). Hello World → Contains space → Invalid Input (contains space). ValidKey → Valid input. 
        After transformation → YeKiA. Alpha! → Contains special character → Invalid Input (contains special character). aaaaaa → All characters have odd ASCII values. 
        After processing → AaAaAa. → All characters have even ASCII values. After removal, string becomes empty → Invalid Input (empty string).
         Python3 → Contains digits → Invalid Input (contains digits). ZebraZ → Valid input. After transformation → Ae.
*/

namespace KeyGeneration;
using System;
using System.Text;
using System.Text.RegularExpressions;

public class KeyGeneration
{
    public  void Run(string s)
    {

        
        if (isShortLength(s) || isSpace(s) || isNumber(s) || isSpecialChar(s))
        {
            return ;
        }
        
        else
        {
            
            string ans  = new string (evenIndexUpper( Reverse ( removeEvenASCII(toLower(s)) ) ) );
            if ( isEmpty(ans))
            {
                return ;
            }
            else
            {
                Console.WriteLine ("The generated key is - " + ans) ;
            }
        }
    }

    /* public bool isOnlyLetter (string s)
    {
        foreach ( char c in s)
        {
            if ( c < 'a' || c > 'z' || c < 'A' || c > 'Z' ) return false ;
            if ( !char.IsLetter(c)) return false ;
        }
        return true ;
    } */

    public static bool isNumber (string s)
    {
        foreach (char c in s)
        {
            if ( char.IsDigit(c))
            {
                Console.WriteLine("Invalid Input (contains digits)");
                return true ;
            }
        }
        /* 
        // Alternative method with regex
        string pattern = @"[0-9]"
        if(Regex.IsMatch(s , pattern)){
        Console.WriteLine("Invalid Input (contains digits)");
        return true ;
        };
        */
        return false ;
    }

    public static  bool isSpace (string s)
    {
        foreach(char c in s)
        {
            if (char.IsWhiteSpace(c))
            {
                Console.WriteLine("Invalid Input (contains space)");
                return true ;
            }
        }
        /*
        // Alternative method with regex
        string pattern = @"\s";
        if (Regex.IsMatch(s , pattern)){
        Console.WriteLine("Invalid Input (contains space)");
        return true ;
        }
        */

        return false ;
    }

    public static  bool isSpecialChar(string s)
    {
        foreach(char c in s)
        {
            if (!char.IsLetterOrDigit(c))
            {
                Console.WriteLine("Invalid Input (contains special character)");
                return true;
            }
            
        }
        /*
        // Alternative way for this check
        string pattern = @"[^A-za-z\d]";
        if (Regex.IsMatch(s, pattern)){
        Console.WriteLine("Invalid Input (contains special character)");
        return true ;
        }
        */
        return false ;
    }

    public static bool isShortLength (string s)
    {
        if (s.Length < 6)
        {
            Console.WriteLine ("Invalid Input (length < 6)");
            return true ;
        }
        return false ;
    }

    public static bool isEmpty(string s)
    {
        if ( string.IsNullOrEmpty(s)) // instead of using s == null becaue it could be either null or "" ( which is empty )
        {
            Console.WriteLine ("Invalid Input (empty string)");
            return true ;
        }
        return false ;
    }
    public static string toLower (string s)
    {
        if (s == null )
        {
            Console.WriteLine("Invalid Input (null)");
            // since this is the first step after filtering so making sure if the edge case hit i print the right mesage and return empty
            return string.Empty;
        }
       return  s.ToLower();
    }

    public static  string Reverse(string s)
    {
        if ( s == null)
        {
            Console.WriteLine("Invalid Input (null)");
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        Array.Reverse(a);
        string ans = new string(a);
        return ans ;
    }

    public static string removeEvenASCII(string s)
    {
        if ( s == null)
        {
            Console.WriteLine("Invalid Input (null)");
            return string.Empty;
        }
        StringBuilder temp = new StringBuilder () ;
        foreach (char c in s)
        {
            if( (int)c % 2 != 0)
            {
               temp.Append(c)   ;
            }
        }
        string ans = temp.ToString();
       return ans ;
    }

    public static string evenIndexUpper (string s)
    {
        if (s == null)
        {
            Console.WriteLine("Invalid Input (null)");
            return string.Empty ;
        }
        StringBuilder temp = new StringBuilder() ;
        for ( int i = 0 ; i < s.Length ; i++)
        {
            if ( i % 2 == 0)
            {
                temp.Append( char.ToUpper(s[i]));
            }else
            {
                temp.Append(s[i]);
            }
        }
        string ans = temp.ToString();
        return ans;
    }


}