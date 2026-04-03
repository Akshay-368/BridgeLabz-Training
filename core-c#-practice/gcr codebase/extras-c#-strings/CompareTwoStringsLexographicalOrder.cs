using System;

public class CompareTwoStringsLexographicalOrder
{
  
  public static int mycompare (string a, string b)
  {
    // this compares two strings letter by letter without any built in compare
    // returns negative if a before b, positive if a after b, zero if same
    
    int len1 = 0;
    int len2 = 0;
    
    // count length of first string manual way
    char[] ch1 = a.ToCharArray();
    for(int i=0; i<ch1.Length; i++)
    {
      len1++;
    }
    
    // same for second
    char[] ch2 = b.ToCharArray();
    for(int j=0; j<ch2.Length; j++)
    {
      len2++;
    }
    
    // now loop thru shortest length
    int minlen = len1;
    if(len2 < len1) minlen = len2;
    
    for(int k=0; k<minlen; k++)
    {
      char c1 = a[k];
      char c2 = b[k];
      
      // if chars different, return difference in ascii
      if(c1 != c2)
      {
        return c1 - c2;   // like 'a'-'b' = negative so a before b
      }
      // if same, keep going to next char
    }
    
    // if we reach here, one string is prefix of other
    // shorter one comes first
    if(len1 < len2) return -1;
    if(len2 < len1) return 1;
    
    // exact same strings
    return 0;
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    8. Compare Two Strings 
    Problem: 
    Write a C# program to compare two strings lexicographically (dictionary order) without using built-in compare methods. 
    Example Input: 
    String 1: "apple" 
    String 2: "banana" 
    Expected Output: 
    "apple" comes before "banana" in lexicographical order
    
    */
    
    Console.WriteLine("waiting for user to enter first string...");
    string s1 = Console.ReadLine();
    
    if(s1 == null) s1 = "";
    
    Console.WriteLine("now waiting for second string...");
    string s2 = Console.ReadLine();
    
    if(s2 == null) s2 = "";
    
    Console.WriteLine();
    
    int result = mycompare (s1, s2);
    
    Console.WriteLine("comparing \"" + s1 + "\" and \"" + s2 + "\"");
    
    if(result < 0)
    {
      Console.WriteLine("\"" + s1 + "\" comes before \"" + s2 + "\" in lexicographical order");
    }
    else if(result > 0)
    {
      Console.WriteLine("\"" + s1 + "\" comes after \"" + s2 + "\" in lexicographical order");
    }
    else
    {
      Console.WriteLine("both strings are exactly same");
    }
    
    Console.WriteLine();
    Console.WriteLine("press enter to finish program...");
    Console.ReadLine();
    
  }
}
